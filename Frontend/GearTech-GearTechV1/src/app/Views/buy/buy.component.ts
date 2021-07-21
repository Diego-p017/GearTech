import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';

@Component({
  selector: 'app-buy',
  templateUrl: './buy.component.html',
  styleUrls: ['./buy.component.css']
})
export class BuyComponent implements OnInit {

  constructor(
    private router:Router
    ,public dialogRef: MatDialogRef<BuyComponent>
  ) { }

  ngOnInit(): void {
  }

  fin(){
    console.log('fin')
    this.dialogRef.close();
    this.router.navigate(['Products']);
  }
}
