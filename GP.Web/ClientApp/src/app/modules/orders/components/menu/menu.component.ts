import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HeaderInputType } from 'src/app/models/data-table/header-input-type.enum';
import { ToastsService } from 'src/app/services/toasts.service';
import { Menu } from '../../models/menu';
import { MenuService } from '../../service/menu.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {

  constructor(private menuService: MenuService, private router: Router, protected toastsService: ToastsService) { }
  restaurantMenu: Array<Menu> = [];
  selectedItemId: number | undefined;
  cols = [
    { field: 'position', header: 'Nr.', width: '80px' },
    { field: 'imageBase64', header: 'Podgląd', width: '200px' },
    { field: 'productName', header: 'Nazwa', width: '200px' },
    { field: 'description', header: 'Opis', width: '350px' },
    { field: 'amount', header: 'Cena' , width: '80px' },
    { field: 'action', header: '', width: '180px' }
  ];

  //
  // columnsDefinition = [
  //   { field: 'imageBase64', header: 'management.username', inputType: HeaderInputType.Filter },
  //   { field: 'productName', header: 'management.drivingLicences', inputType: HeaderInputType.Filter},
  //   { field: 'description', header: 'description', inputType: HeaderInputType.Filter },
  //   { field: 'amount', header: 'amount', inputType: HeaderInputType.Filter },
  //   { field: 'position', header: 'position', inputType: HeaderInputType.Filter }
  // ];
  //


  ngOnInit(): void {
    this.menuService.GetMenu().subscribe(x => {
      this.restaurantMenu = x;
    });
  }

  onAdd(): void {
    this.toastsService.showSuccess(`Brak czasu na implementacje`);
  }
  onEdit(model: any): void  {}
  onSave(): void  {}
  onDelete(): void  {}
  onSaveOrder(): void  {}
  onReorderDown(item: any): void  {  }

  onReorderUp(item: any): void  {  }

  onReorder(): void  {  }
  onCreatOrderRedirect(): void  {
    this.router.navigate(['/orders/create']);
  }
}
