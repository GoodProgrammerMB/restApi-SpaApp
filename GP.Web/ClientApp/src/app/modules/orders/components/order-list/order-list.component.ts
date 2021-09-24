import { Component, OnInit } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { ToastsService } from 'src/app/services/toasts.service';
import { OrderReceipt } from '../../models/order-receipt';
import { OrderService } from '../../service/order.service';
import { Order } from './../../models/order';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.scss']
})
export class OrderListComponent implements OnInit {
  orders: OrderReceipt[] = [];
  selectedItemId: number | undefined;

  constructor(private orderService: OrderService,
              private confirmationService: ConfirmationService,
              protected toastsService: ToastsService) { }

  cols = [
    { field: 'id', header: 'Numer zamówienia' , width: '200px' },
    { field: 'tableNumber', header: 'Stolik nr.', width: '200px' },
    { field: 'orderItems', header: 'Szczegóły zamówienia' },
    { field: 'totalAmount', header: 'Do zapłaty' , width: '200px' },
    { field: 'action', header: '', width: '180px' },
  ];

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void{
    this.orders = [];
    this.orderService.GetActive().subscribe(result => {
      result.forEach((r) => {

      let description = '';
      r.items.forEach((i) => {
        description += `${i.quantity} x ${i.productName}\n`;
      });
      description.replace('\n', '<br>');
      this.orders.push( {id: r.id, tableNumber: r.tableNumber, totalAmount: r.totalAmount, orderItems : description });
      });
    });
  }

  onAdd(): void {}
  onPay( model: OrderReceipt): void  {
    this.confirmationService.confirm({
      message: `Potwierdzasz zapłatę kwoty ${model.totalAmount}`,
      accept: () => {
        this.orderService.Close({id: model.id, amount: model.totalAmount}).subscribe(x => {
          this.toastsService.showSuccess(`Zamówienie zostało zamknięte`);
          this.loadData();
            }, error => this.toastsService.showError(error));
      }
  });
  }
  onSave(): void  {}
  onDelete(): void  {}
  onSaveOrder(): void  {}
  onReorderDown(item: any): void  {  }

  onReorderUp(item: any): void  {  }

  onReorder(): void  {  }
}
