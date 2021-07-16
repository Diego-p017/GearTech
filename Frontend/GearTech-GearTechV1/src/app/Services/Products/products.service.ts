import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductsI } from 'src/app/Models/Products.interface';
import { ResponseI } from 'src/app/Models/Response.interface';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  url:string = "https://localhost:44346/api/"

  constructor(private http:HttpClient) { }

  getSingleProduct(idProduct):Observable<ProductsI>{
    let direccion = this.url + "Products/" + idProduct;
    return this.http.get<ProductsI>(direccion); 
  }

  getAllProducts():Observable<ProductsI[]>{
    let direccion = this.url + "Products";
    return this.http.get<ProductsI[]>(direccion);
  }

  AddProducts(form:ProductsI):Observable<ResponseI>{
    let direccion = this.url + "Products";
    return this.http.post<ResponseI>(direccion,form);
  }

  deleteProducts(idProduct){
    let direccion = this.url + "Products/"+ idProduct;
    return this.http.delete(direccion);
  }
  
  putProduct(form:ProductsI):Observable<ResponseI>{
    let direccion = this.url + "Products/" + form.idProduct;
    return this.http.put<ResponseI>(direccion,form); 
   
  }
}

