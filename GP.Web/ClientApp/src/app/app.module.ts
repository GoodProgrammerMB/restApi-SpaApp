import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MegaMenuModule } from 'primeng/megamenu';
import { HomePageComponent } from './components/home-page/home-page.component';
import { HttpErrorInterceptor } from './interceptors/http-error.interceptor';
import { MainLayoutComponent } from './components/main-layout/main-layout.component';
import { LeftMenuComponent } from './components/left-menu/left-menu.component';
import { EmptyLayoutComponent } from './components/empty-layout/empty-layout.component';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ToastModule } from 'primeng/toast';
import { HeaderComponent } from './components/header/header.component';
import { MessageService } from 'primeng/api';
import { DataTableComponent } from './components/data-table/custom-data-table.component';
import { TableModule } from 'primeng/table';
import { MultiSelectModule } from 'primeng/multiselect';

const components = [
  MegaMenuModule,
  CommonModule,
  RouterModule,
   ToastModule,
   TableModule,
   MultiSelectModule
  // TooltipModule,
  // TranslateModule,
  // TableModule,
];
@NgModule({
  declarations: [
    AppComponent,
    MainLayoutComponent,
    HeaderComponent,
    LeftMenuComponent,
  //  FooterComponent,
    HomePageComponent,

    MainLayoutComponent,
    EmptyLayoutComponent,
    LeftMenuComponent,
    //BreadcrumbComponent,
    //LoaderComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    ...components,

  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: HttpErrorInterceptor, multi: true },
    MessageService,
  ],
  bootstrap: [AppComponent],
  exports: []
})
export class AppModule { }
