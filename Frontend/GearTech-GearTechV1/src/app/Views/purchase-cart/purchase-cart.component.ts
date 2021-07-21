import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PurchaseDetailI } from 'src/app/Models/PurchaseDetail.interface';
import { PurchaseDetailService } from 'src/app/Services/Purchase/purchase-detail.service';

@Component({
  selector: 'app-purchase-cart',
  templateUrl: './purchase-cart.component.html',
  styleUrls: ['./purchase-cart.component.css']
})
export class PurchaseCartComponent implements OnInit {
  purchases:PurchaseDetailI[];
  public columnas = ['nombre','cantidad','precio',];

  constructor(
    public apiCart:PurchaseDetailService
    ,public dialog:MatDialog
  ) { }

  ngOnInit(): void {
    this.apiCart.getAllCart().subscribe(car =>{
      this.purchases = car;
      console.log('cart',this.purchases)
    })
  }

}
