import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { PurchaseDetailI } from 'src/app/Models/PurchaseDetail.interface';
import { PurchaseDetailService } from 'src/app/Services/Purchase/purchase-detail.service';
import { ShoppingCartService } from 'src/app/Services/ShoppingCar/shopping-cart.service';
import { PurchaseCartComponent } from 'src/app/Views/purchase-cart/purchase-cart.component';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  purchases:PurchaseDetailI[];
  constructor(
    public apiCart:PurchaseDetailService
    ,public dialog:MatDialog
  ) { }

  ngOnInit(): void {
    this.apiCart.getAllCart().subscribe(car =>{
      this.purchases = car;
    })
  }
  

  cart(){
    let dialogRef = this.dialog.open(PurchaseCartComponent);

    dialogRef.afterClosed().subscribe(result =>{
      console.log('Dialog result: ${result}');
    });
  }

}
