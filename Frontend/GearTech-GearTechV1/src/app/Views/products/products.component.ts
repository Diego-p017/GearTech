import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductsI } from 'src/app/Models/Products.interface';
import { ProductsService } from 'src/app/Services/Products/products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  products:ProductsI[] ;
  public columnas = ['nombre', 'descripcion', 'precio', 'eliminar'];
  
  constructor(
     public apiPro:ProductsService 
    ,private router:Router
  ) { }

  ngOnInit(): void {
    this.apiPro.getAllProducts().subscribe(pro =>{
      this.products = pro;
      console.log(pro) 
    })
  }
eliminar(product){

}
details(value){
  this.router.navigate(["Products/Detail",value])
}
}
