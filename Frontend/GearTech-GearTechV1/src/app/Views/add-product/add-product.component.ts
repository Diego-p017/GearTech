import { FormControl, FormGroup } from '@angular/forms';
import { Component, ElementRef, OnInit, ViewChild, Inject } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ProductsC, ProductsI } from 'src/app/Models/Products.interface';
import { ProductsService } from 'src/app/Services/Products/products.service';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
 productNew : ProductsI;
 image : any;
 @ViewChild("foto", {
   read: ElementRef
 }) foto: ElementRef;

 addForm = new FormGroup({
    idProduct: new FormControl(0),
    productName: new FormControl(''),
    productPrice: new FormControl(''),
    productStock: new FormControl(''),
    imageProduct: new FormControl(''),
    idCategory: new FormControl('')
  //token: new FormControl('')
  
});
  constructor(
    private apiProducts: ProductsService
    , private snackBar: MatSnackBar
    ,public dialogRef: MatDialogRef<AddProductComponent>
  ) { }

  public cargando = false;

  
  // async add(){
  //   if(!this.productNew.productName){
  //     return alert("Ingresa Nombre del prodcuto");
  //   }
  //   if(!this.productNew.productPrice){
  //     return alert("Ingresa Precio del prodcuto");
  //   }
  //   if(!this.productNew.productStock){
  //     return alert("Ingresa Cantidad del prodcuto");
  //   }
  //   if(!this.productNew.idCategory){
  //     return alert("Ingresa Categoria del prodcuto");
  //   }
  //   let archiv = this.foto.nativeElement.files;
  //   if(!archiv.length){
  //     return alert("Ingresa Imagen del producto");
  //   }
  //   this.cargando = true;
  //   // guarda prodcuto
    
    
  //   const fd = new FormData();
  //   for (let x = 0; x < archiv.length; x++){
  //     fd.append(`foto_${x}`, archiv[x])
  //   }
  //   console.log('fb',fd)

  //   this.apiProducts.AddProducts(this.productNew);
  //   this.snackBar.open("Producto guardado", "", {
  //     duration: 1500,
  //     horizontalPosition: "start",
  //     verticalPosition: "top",
  //   });

  //   this.cargando = false;
  //   this.productNew = new ProductsC();
  //   this.foto.nativeElement.value = "";
  // }

  ngOnInit(): void {
   
  }

  onUploadFinish(event) {
    console.log('event',event);
   this.image = event.src;
    // try {
    //   if (event.FileHolder.file && event.FileHolder.files.length > 0) {

    //     const file = event.FileHolder.file[0];
    //     const reader = new FileReader();
    //     if (file.type.indexOf("image") < 0) {
    //       this.snackBar.open('Solo se permite la carga de imagenes en formato JPG y PNG.');
    //       return;
    //     }

    //     const extension = file.name.split('.').pop();
    //     if (extension !== "JPG" && extension !== "jpg" && extension !== "PNG" && extension !== "png") {
    //       this.snackBar.open('Solo se permite la carga de imagenes en formato JPG y PNG.');
    //       return;
    //     }

    //     console.log(file);
    //     if (file.size > 100000) {
    //       this.snackBar.open('Por favor carga una imagen que no exceda de 100KB.');
    //       return;
    //     }
    //     reader.readAsDataURL(file);
    //     reader.onloadend = () => {
    //       this.image = (reader.result as string);
    //       //this.formTemplateMail.controls['logo'].setValue(reader.result as string);
    //     };
    //   }
    // }
    // catch (ex) {
    //   console.log(ex);
    // }
    
   }
  addProduct(form:ProductsI){
    form.imageProduct = this.image;
    console.log("addForm",form);
    this.apiProducts.AddProducts(form).subscribe(data=>{
      console.log('addProducts',data)
    })
  }
  cancel(){
    this.dialogRef.close();
  }
  

}
