import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductsI } from 'src/app/Models/Products.interface';
import { PurchaseDetailI } from 'src/app/Models/PurchaseDetail.interface';
import { ProductsService } from 'src/app/Services/Products/products.service';
import { PurchaseDetailService } from 'src/app/Services/Purchase/purchase-detail.service';
import { ShoppingCartService } from 'src/app/Services/ShoppingCar/shopping-cart.service';
import { PurchaseCartComponent } from '../../purchase-cart/purchase-cart.component';
import { ShoppingCarComponent } from '../../shopping-car/shopping-car.component';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
  image : any;
  dataItem:any;
  products:ProductsI;
  total:any;
  mostrar=false;
  
  public product = {
    idProduct: 0,
    imageProduct: [],
    productName: "",
    descripcion: "",
    productPrice: 0,
  };
  public fotoSeleccionada: string;
  public indiceSeleccionado = 0;
  public yaExiste: boolean;

  addForm = new FormGroup({
    purchasePrice: new FormControl(0),
    purchaseAmount: new FormControl(1),
    idProduct: new FormControl(0)
  
});
  constructor(
    private apiProducts: ProductsService,
    private apiPurchase: PurchaseDetailService,
    public dialogRef: MatDialogRef<ProductDetailComponent>,
    public dialog:MatDialog,
    @Inject(MAT_DIALOG_DATA)
    public data: ProductsI,
    ) {
      this.dataItem = this.data;
     }
  ngOnInit(): void {    
    this.apiProducts.getSingleProduct(this.dataItem).subscribe(pro => {
      this.products = pro;
    })
  }

  buyProduct(form:PurchaseDetailI){ 
   
    form.idProduct = this.dataItem;     
    form.purchasePrice = this.products.productPrice;
    console.log('this.products form',form);
    // this.total = form.purcharseAmount * this.product.productPrice;
    // console.log('total',this.total);
    // form.purchasePrice = this.total;
    //form.purchasePrice = this.product.productPrice; 
    
    this.apiPurchase.AddCart(form).subscribe(data => {
        console.log('Addcart',data)
        this.dialog.open(PurchaseCartComponent,{
          data: data
        }).afterClosed().subscribe(item => {
          this.ngOnInit();
        })
        console.log('deatilsProduct',this.dialogRef)        
    })
  }
}
