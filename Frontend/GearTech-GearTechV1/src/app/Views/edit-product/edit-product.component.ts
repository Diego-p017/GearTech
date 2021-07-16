import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductsI } from 'src/app/Models/Products.interface';
import { ProductsService } from 'src/app/Services/Products/products.service';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent implements OnInit {

  image : any;
  dataItem:any;
  dataProduct:ProductsI;
  
  editForm = new FormGroup({
    idProduct: new FormControl(0),
    productName: new FormControl(''),
    productPrice: new FormControl(''),
    productStock: new FormControl(''),
    imageProduct: new FormControl(''),
    idCategory: new FormControl('')
  //token: new FormControl('')
  
});

  constructor( 
    private activeRouter:ActivatedRoute, 
    private router:Router, 
    private apiProducts: ProductsService,
    public dialogRef: MatDialogRef<EditProductComponent>,
    @Inject(MAT_DIALOG_DATA)
    public data: ProductsI,
    ) {
      this.dataItem = this.data;
     }
  

  ngOnInit(): void {
    this.apiProducts.getSingleProduct(this.dataItem).subscribe(data =>{
      this.dataProduct = data;
      console.log("this.dataProduct",this.dataProduct)
      this.editForm.setValue({
        'productName' : this.dataProduct.productName,
        'idProduct'   : this.dataProduct.idCategory,
        'productPrice': this.dataProduct.productPrice,
        'productStock': this.dataProduct.productStock,
        'imageProduct': this.dataProduct.imageProduct,
        'idCategory'  : this.dataProduct.idCategory
        //'token' : this.dataProduct.token
      });
  })
  }
  editProduct(form:ProductsI){      
    form.idProduct = this.dataItem 
    form.imageProduct = this.image
    this.apiProducts.putProduct(form).subscribe(data => {
      console.log("putProduts",data);
    })
  }
  cancel() {
    this.dialogRef.close();
  }

  onUploadFinish(event) {
    console.log('event',event);
   this.image = event.src;
  }
}
