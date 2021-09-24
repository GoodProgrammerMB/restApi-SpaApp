import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuComponent } from './components/menu/menu.component';
import { OrderListComponent } from './components/order-list/order-list.component';
import { OrdersRoutingModule } from './orders-routing.module';
import { MenuService } from './service/menu.service';
import { TableModule } from 'primeng/table';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MultiSelectModule } from 'primeng/multiselect';
import { DropdownModule } from 'primeng/dropdown';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { CalendarModule } from 'primeng/calendar';
import { AutoCompleteModule } from 'primeng/autocomplete';
import { OrderListModule } from 'primeng/orderlist';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { ScrollPanelModule } from 'primeng/scrollpanel';
import { OverlayPanelModule } from 'primeng/overlaypanel';
//import { ChartModule } from 'primeng/chart';
import { InputSwitchModule } from 'primeng/inputswitch';
import { SliderModule } from 'primeng/slider';
import { SelectButtonModule } from 'primeng/selectbutton';
import { CheckboxModule } from 'primeng/checkbox';
import {DataViewModule} from 'primeng/dataview';
import {TabViewModule} from 'primeng/tabview';
import {InplaceModule} from 'primeng/inplace';
import { DynamicDialogModule } from 'primeng/dynamicdialog';
import { DialogService } from 'primeng/dynamicdialog';
import { PickListModule } from 'primeng/picklist';
import { ConfirmationService } from 'primeng/api';
import { ListboxModule } from 'primeng/listbox';
import { ToggleButtonModule } from 'primeng/togglebutton';
import { PanelModule } from 'primeng/panel';
import { LightboxModule } from 'primeng/lightbox';
import { GalleriaModule } from 'primeng/galleria';
import { AccordionModule } from 'primeng/accordion';
import {DialogModule} from 'primeng/dialog';
import { DataTableComponent } from 'src/app/components/data-table/custom-data-table.component';
import { OrderFormComponent } from './components/order-form/order-form.component';
import {InputNumberModule} from 'primeng/inputnumber';
import {ConfirmPopupModule} from 'primeng/confirmpopup';
import { RomTableComponent } from './components/rom-table/rom-table.component';
import { AddTableComponent } from './components/add-table/add-table.component';

//
const ngPrime = [
  CommonModule,
  PickListModule,
  MultiSelectModule,
  TableModule,
  DropdownModule,
  FormsModule,
  ReactiveFormsModule,
  ConfirmDialogModule,
  //CalendarModule,
  AutoCompleteModule,
  LightboxModule,
  GalleriaModule,
  OrderListModule,
  ListboxModule,
  InputTextareaModule,
  DynamicDialogModule,
  InputNumberModule,
  ConfirmPopupModule,
  //DialogModule,
  ScrollPanelModule,
 // OverlayPanelModule,
  //ChartModule,
  InputSwitchModule,
  SliderModule,
  //FullCalendarModule,
  SelectButtonModule,
  CheckboxModule,
  ToggleButtonModule,
  AccordionModule,
  PanelModule,
  DataViewModule,
  TabViewModule,
  InplaceModule,
];

@NgModule({
  declarations: [MenuComponent, OrderListComponent, DataTableComponent, OrderFormComponent, RomTableComponent, AddTableComponent],
  imports: [
    CommonModule,
    OrdersRoutingModule,
    ...ngPrime
  ],
  providers: [ConfirmationService, MenuService]
})
export class OrdersModule { }
