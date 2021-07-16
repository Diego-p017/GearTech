import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ResponseI } from 'src/app/Models/Response.interface';
import { ShoppingCartI } from 'src/app/Models/ShoppingCart.interface';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {
  url:string = "https://localhost:44346/api/"

  constructor(private http: HttpClient) { }
  getSingleProduct(idProduct):Observable<ShoppingCartI>{
    let direccion = this.url + "Products/" + idProduct;
    return this.http.get<ShoppingCartI>(direccion); 
  }

  getAllProduct():Observable<ShoppingCartI[]>{
    let direccion = this.url + "Products";
    return this.http.get<ShoppingCartI[]>(direccion);
  }

  AddProduct(form:ShoppingCartI):Observable<ResponseI>{
    let direccion = this.url + "Products";
    return this.http.post<ResponseI>(direccion,form);
  }

  deleteProduct(idProduct){
    let direccion = this.url + "Products/"+ idProduct;
    return this.http.delete(direccion);
  }
  
  
}
