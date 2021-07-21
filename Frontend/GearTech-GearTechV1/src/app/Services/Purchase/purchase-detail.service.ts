import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PurchaseDetailI } from 'src/app/Models/PurchaseDetail.interface';
import { ResponseI } from 'src/app/Models/Response.interface';

@Injectable({
  providedIn: 'root'
})
export class PurchaseDetailService {
  url:string = "https://localhost:44346/api/"

  constructor(private http: HttpClient) { }
  getSingleCart(idProduct):Observable<PurchaseDetailI>{
    let direccion = this.url + "PurchaseDetail/" + idProduct;
    return this.http.get<PurchaseDetailI>(direccion); 
  }

  getAllCart():Observable<PurchaseDetailI[]>{
    let direccion = this.url + "PurchaseDetail";
    return this.http.get<PurchaseDetailI[]>(direccion);
  }

  AddCart(form:PurchaseDetailI):Observable<ResponseI>{
    let direccion = this.url + "PurchaseDetail";
    return this.http.post<ResponseI>(direccion,form);
  }

  deleteCart(idProduct){
    let direccion = this.url + "PurchaseDetail/"+ idProduct;
    return this.http.delete(direccion);
  }
}
