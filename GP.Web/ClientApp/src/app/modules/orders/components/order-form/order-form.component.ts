import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Order } from '../../models/order';
import { Table } from 'primeng/table';
import { TableService } from '../../service/table.service';
import { Menu } from '../../models/menu';
import { MenuService } from '../../service/menu.service';
import { DropdownItem } from '../../models/dropdown-item';
import { SelectItem } from 'primeng/api/selectitem';
import { OrderService } from '../../service/order.service';
import { OrderItem } from '../../models/order-item';
import { ToastsService } from 'src/app/services/toasts.service';


@Component({
  selector: 'app-order-form',
  templateUrl: './order-form.component.html',
  styleUrls: ['./order-form.component.scss']
})
export class OrderFormComponent implements OnInit {

  creatOrEditForm = new FormGroup ({ tableNumber: new FormControl(), totalAmount: new FormControl()});
  tables: SelectItem[] = [];
  products: Menu[] = [];
  productWithMenu: SelectItem[] = [];

  unavailability: any;
  selected: any = null;

  constructor(private tableService: TableService,
              private menuService: MenuService,
              private fB: FormBuilder,
              private orderService: OrderService,
              protected toastsService: ToastsService) {

  }

  ngOnInit(): void {
    this.initForm();
    this.initData();
  }

  private initData(): void{
    this.getActiveTables();
    this.getProducts();
  }

  private initForm(): void {
    this.creatOrEditForm = new FormGroup({
      tableNumber: new FormControl(null, Validators.required),
      totalAmount: new FormControl(''),
      products: new FormArray([]),
    });
  }

  get productsRowArray(): FormArray {
    return this.creatOrEditForm.get('products') as FormArray;
 }

  getActiveTables(): void {
    this.tableService.GetActiveTables().subscribe(
      result => {
        this.tables = result
        .map(p => ({
            label: `${p.number} ${p.name}`,
            value: p.id
      }));

    });
  }

  getProducts(): void  {
    this.menuService.GetMenu().subscribe(
      result => {
        this.productWithMenu = result
        .map(p => ({
            label: `${p.position} ${p.productName}`,
            value: p.id
      }));

    });
  }

  onAddItemToOrder(): void {
    const orderItem = new FormGroup({
      id: new FormControl(1),
      name: new FormControl(null, Validators.required),
      quantity: new FormControl(null, Validators.required)
    });
    (this.creatOrEditForm.controls.products as FormArray).push(orderItem);
  }
  onDeleteItemFromOrder(index: number): void  {
    (this.creatOrEditForm.controls.products as FormArray).removeAt(index);

  }

  onSave(): void {
    if (this.creatOrEditForm.invalid) {
      this.toastsService.showError('Formularz zawiera błędy');
      return;
    }

    const model: Order = this.creatOrEditForm.getRawValue() as Order;
    model.tableNumber = this.creatOrEditForm.controls.tableNumber.value;
    model.totalAmount = null;
    const orderItems: OrderItem[] = [];

    (this.creatOrEditForm.controls.products as FormArray).controls.forEach((x, i) => {
        const prod: OrderItem = {
          productId: (x as FormGroup).controls.name.value,
          quantity: (x as FormGroup).controls.quantity.value,
          productName: '',
          id: 0
        };
        orderItems.push(prod);
      });
    model.items = orderItems;

    this.orderService.Add(model).subscribe(x => {
      this.initData();
      this.initForm();
      this.toastsService.showSuccess(`Zamówienie zostało dodane`);
      }, error => this.toastsService.showError(error));
  }
}
