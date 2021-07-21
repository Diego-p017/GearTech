import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ProductsI } from 'src/app/Models/Products.interface';
import { ProductsService } from 'src/app/Services/Products/products.service';
import { ProductDetailComponent } from './product-detail/product-detail.component';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  dialogRef: MatDialogRef<ProductDetailComponent>;
  products:ProductsI[] ;
  public columnas = ['nombre', 'descripcion', 'precio', 'eliminar'];
  
  constructor(
     public apiPro:ProductsService 
    ,private router:Router
    ,public dialog:MatDialog
  ) { }

  ngOnInit(): void {
    this.apiPro.getAllProducts().subscribe(pro =>{
      this.products = pro;
      console.log(pro) 
    })
  }
eliminar(product){

}
details(idProduct,productPrice){
  this.dialog.open(ProductDetailComponent,{
    data: idProduct
  }).afterClosed().subscribe(item => {
    this.ngOnInit();
  })
  console.log('deatilsProduct',this.dialogRef)
  }
}
