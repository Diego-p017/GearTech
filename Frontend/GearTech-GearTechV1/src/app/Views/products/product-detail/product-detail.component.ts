import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductsI } from 'src/app/Models/Products.interface';
import { ProductsService } from 'src/app/Services/Products/products.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
  image : any;
  dataItem:any;
  products:ProductsI;
  
  public product = {
    idProduct: 0,
    imageProduct: [],
    productName: "",
    descripcion: "",
    productPrice: "",
  };
  public fotoSeleccionada: string;
  public indiceSeleccionado = 0;
  public yaExiste: boolean;
  constructor(
    private activeRouter:ActivatedRoute, 
    private router:Router, 
    private apiProducts: ProductsService,
    public dialogRef: MatDialogRef<ProductDetailComponent>,
    @Inject(MAT_DIALOG_DATA)
    public data: ProductsI,
    ) {
      this.dataItem = this.data;
     }
  ngOnInit(): void {    
    this.apiProducts.getSingleProduct(this.dataItem).subscribe(pro => {
      this.products = pro;
      console.log('this.products',this.products);
    })
  }

  buyProduct(){
  }
}
