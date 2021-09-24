
import { Page404Component } from './components/page404/page404.component';
import { Page401Component } from './components/page401/page401.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ErrorPagesRoutingModule } from './error-pages.routing.module';
import { ButtonModule } from 'primeng/button';

@NgModule({
  declarations: [
    Page404Component,
    Page401Component
  ],
  imports: [
    CommonModule,
    ErrorPagesRoutingModule,
    ButtonModule
  ]
})
export class ErrorPagesModule { }
