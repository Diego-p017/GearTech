import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { PurchaseDetailI } from 'src/app/Models/PurchaseDetail.interface';
import { PurchaseDetailService } from 'src/app/Services/Purchase/purchase-detail.service';

@Component({
  selector: 'app-shopping-car',
  templateUrl: './shopping-car.component.html',
  styleUrls: ['./shopping-car.component.css']
})
export class ShoppingCarComponent implements OnInit {
  dataItem:any;
  constructor(
    private apiPurchase: PurchaseDetailService,
    public dialogRef: MatDialogRef<ShoppingCarComponent>,
    public dialog:MatDialog,
    @Inject(MAT_DIALOG_DATA)
    public data: PurchaseDetailI,
    ) {
      this.dataItem = this.data;
     }

  ngOnInit(): void {
    console.log('dataprucahrse',this.dataItem)
  }

}
