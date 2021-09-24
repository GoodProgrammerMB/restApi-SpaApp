import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { finalize, map } from 'rxjs/operators';
import { BaseService } from 'src/app/services/base.service';
import { OrderPay } from '../models/order-pay';
import { Order } from './../models/order';

@Injectable({
  providedIn: 'root'
})
export class OrderService extends BaseService {


  constructor(protected httpClient: HttpClient) {
    super();
  }

  GetActive(): Observable<Array<Order>> {
    return this.httpClient.get<Array<Order>>(this.baseUrl + 'Order/active')
    .pipe();
  }

  Add(order: Order): Observable<boolean> {
    return this.httpClient.post(this.baseUrl + 'Order/submit', order, { observe: 'response' })
    .pipe(map(response => this.isStatusSucceed(response.status)));
  }

  Close(order: OrderPay): Observable<boolean> {
    return this.httpClient.put(this.baseUrl + 'Order/pay-and-close', order, { observe: 'response' })
    .pipe(map(response => this.isStatusSucceed(response.status)));
  }
/*
  AddOrEdit(driver: Driver, loader: string): Observable<boolean> {
    if (driver.id == null || driver.id === 0) {
      return this.Add(driver, loader);
    } else {
      return this.Edit(driver, loader);
    }
  }

  Add(driver: Driver, loader: string): Observable<boolean> {
    this.loadersService.show(loader);
    return this.http.post(this.baseUrl + 'drivers', driver, { observe: 'response' }).pipe(
      map(response => this.isStatusSucceed(response.status)),
      finalize(() => this.loadersService.hide(loader)));
  }

  Edit(driver: Driver, loader: string): Observable<boolean> {
    this.loadersService.show(loader);
    return this.http.put(this.baseUrl + 'drivers', driver, { observe: 'response' }).pipe(
      map(response => this.isStatusSucceed(response.status)),
      finalize(() => this.loadersService.hide(loader)));
  }

  Delete(id: number, loader: string): Observable<boolean> {
    this.loadersService.show(loader);
    return this.http.delete(this.baseUrl + 'drivers/' + id, { observe: 'response' }).pipe(
      map(response => this.isStatusSucceed(response.status)),
      finalize(() => this.loadersService.hide(loader)));
  }
  */
}
function driver(arg0: string, driver: any, arg2: { observe: "response"; }) {
  throw new Error('Function not implemented.');
}

