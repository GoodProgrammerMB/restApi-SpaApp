import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrderListComponent } from './components/order-list/order-list.component';
import { MenuComponent } from './components/menu/menu.component';
import { OrderFormComponent } from './components/order-form/order-form.component';
import { RomTableComponent } from './components/rom-table/rom-table.component';
import { AddTableComponent } from './components/add-table/add-table.component';

const routes: Routes = [
  { path: '', redirectTo: 'menu', pathMatch: 'full' },
  { path: 'activeOrders', data: { breadcrumb: 'orders.ordersList', module: 'orders' }, component: OrderListComponent},
  {path: 'order-list', component : OrderListComponent},
  {path: 'menu', component : MenuComponent},
  {path: 'create', component : OrderFormComponent},
  {path: 'tables', component: RomTableComponent},
  {path: 'table-add', component: AddTableComponent}
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
exports: [RouterModule]
})
export class OrdersRoutingModule {}
