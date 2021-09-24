import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { BaseService } from 'src/app/services/base.service';
import { TableRestaurant } from '../models/table-restaurant';

@Injectable({
  providedIn: 'root'
})
export class TableService extends BaseService {


  constructor(protected httpClient: HttpClient) {
    super();
  }

  GetActiveTables(): Observable<Array<TableRestaurant>> {
    return this.httpClient.get<Array<TableRestaurant>>(this.baseUrl + 'Table/active')
    .pipe();
  }

  GetAll(): Observable<Array<TableRestaurant>> {
    return this.httpClient.get<Array<TableRestaurant>>(this.baseUrl + 'Table/all')
    .pipe();
  }

  ChangeStatut(id: number): Observable<boolean> {
    return this.httpClient.put(this.baseUrl + 'Table/chang-status', id, { observe: 'response' })
    .pipe(map(response => this.isStatusSucceed(response.status)));
  }
}
