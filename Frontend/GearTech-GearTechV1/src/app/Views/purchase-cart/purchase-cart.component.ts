import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { PurchaseDetailI } from 'src/app/Models/PurchaseDetail.interface';
import { ProductsService } from 'src/app/Services/Products/products.service';
import { PurchaseDetailService } from 'src/app/Services/Purchase/purchase-detail.service';
import { BuyComponent } from '../buy/buy.component';

@Component({
  selector: 'app-purchase-cart',
  templateUrl: './purchase-cart.component.html',
  styleUrls: ['./purchase-cart.component.css']
})
export class PurchaseCartComponent implements OnInit {
  total:number;
  purchases:PurchaseDetailI[];
  dialogRefe: MatDialogRef<PurchaseCartComponent>;
  public columnas = ['nombre','cantidad','precio','eliminar'];

  constructor(
    public apiCart:PurchaseDetailService
    ,public apiPro:ProductsService
    ,public dialog:MatDialog
    ,private router:Router
    
  ) { }

  ngOnInit(): void {
    this.apiCart.getAllCart().subscribe(car =>{
      this.purchases = car;
      console.log('cart',this.purchases)
      this.total = this.purchases.reduce((
        acc,
        obj,
      ) => acc +(obj.purchasePrice * obj.purchaseAmount),
      0);
      console.log("Total: ", this.total)
    })
    
    
  }

  delete(pruchase){
    console.log('deleteProduct',pruchase.idPurchase)
    this.apiCart.deleteCart(pruchase.idPurchase).subscribe(del =>{
      console.log('deleteApiProduct',del)
      this.ngOnInit();
    })    
  }

buy(){
  //this.dialogRefe.close();
  let dialogRef = this.dialog.open(BuyComponent);
  
     dialogRef.afterClosed().subscribe(result =>{
      this.router.navigate(['Ptoducts']);
       console.log('Dialog result: ${result}');
     });
  // this.dialog.open(BuyComponent,{
  // }).afterClosed().subscribe(item => {  
  //   this.router.navigate(['Products']);
  //   this.ngOnInit();
  // })       

 }
}
