import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PurchaseDetail } from 'src/app/Models/PurchaseDetail.interface';
import { ResponseI } from 'src/app/Models/Response.interface';

@Injectable({
  providedIn: 'root'
})
export class PurchaseDetailService {
  url:string = "https://localhost:44346/api/"

  constructor(private http: HttpClient) { }
  getSingleProduct(idProduct):Observable<PurchaseDetail>{
    let direccion = this.url + "Products/" + idProduct;
    return this.http.get<PurchaseDetail>(direccion); 
  }

  getAllProduct():Observable<PurchaseDetail[]>{
    let direccion = this.url + "Products";
    return this.http.get<PurchaseDetail[]>(direccion);
  }

  AddProduct(form:PurchaseDetail):Observable<ResponseI>{
    let direccion = this.url + "Products";
    return this.http.post<ResponseI>(direccion,form);
  }

  deleteProduct(idProduct){
    let direccion = this.url + "Products/"+ idProduct;
    return this.http.delete(direccion);
  }
}
