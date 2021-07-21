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
  getSingleShoppingCart(idShoppingCart):Observable<ShoppingCartI>{
    let direccion = this.url + "ShoppingCarts/" + idShoppingCart;
    return this.http.get<ShoppingCartI>(direccion); 
  }

  getAllShoppingCart():Observable<ShoppingCartI[]>{
    let direccion = this.url + "ShoppingCarts";
    return this.http.get<ShoppingCartI[]>(direccion);
  }

  AddShoppingCart(form:ShoppingCartI):Observable<ResponseI>{
    let direccion = this.url + "ShoppingCarts";
    return this.http.post<ResponseI>(direccion,form);
  }

  deleteShoppingCart(idShoppingCart){
    let direccion = this.url + "ShoppingCarts/"+ idShoppingCart;
    return this.http.delete(direccion);
  }
  
  
}
