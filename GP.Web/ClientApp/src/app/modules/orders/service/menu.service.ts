import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { BaseService } from "src/app/services/base.service";
import { Menu } from "../models/menu";

@Injectable({
  providedIn: 'root'
})
export class MenuService extends BaseService {


  constructor(protected httpClient: HttpClient) {
    super();
  }

  GetMenu(): Observable<Array<Menu>> {
    return this.httpClient.get<Array<Menu>>(this.baseUrl + 'Menu')
    .pipe();
  }
}
