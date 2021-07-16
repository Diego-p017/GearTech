import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductsI } from 'src/app/Models/Products.interface';
import { ProductsService } from 'src/app/Services/Products/products.service';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { AddProductComponent } from '../add-product/add-product.component';
import { DomSanitizer } from '@angular/platform-browser';
import { EditProductComponent } from '../edit-product/edit-product.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  dialogRef: MatDialogRef<AddProductComponent,EditProductComponent>;
  image : any;
  products:ProductsI[] ;
  public columnas = ['nombre', 'categoria','cantidad', 'precio','imagen','eliminar','editar'];
  
  constructor(
    public apiPro:ProductsService 
    ,private router:Router
    ,public dialog:MatDialog
    ,private sanitizer: DomSanitizer
  ) { }

  ngOnInit(): void {
    this.apiPro.getAllProducts().subscribe(pro =>{
     // this.image = pro[0].imageProduct;
      this.products = pro;    
      this.sanitizer.bypassSecurityTrustResourceUrl(this.image);  
      console.log(pro) 
    })
  }
  openAdd(){
    let dialogRef = this.dialog.open(AddProductComponent);

     dialogRef.afterClosed().subscribe(result =>{
       console.log('Dialog result: ${result}');
     });
  }
  delete(Product){
    console.log('deleteProduct',Product.idProduct)
    this.apiPro.deleteProducts(Product.idProduct).subscribe(del =>{
      console.log('deleteApiProduct',del)
      this.ngOnInit();
    })
}
  edit(idProduct){
    this.dialog.open(EditProductComponent,{
      data: idProduct
    }).afterClosed().subscribe(item => {
      this.ngOnInit();
    })
    console.log('editProduct',this.dialogRef)
}

}
