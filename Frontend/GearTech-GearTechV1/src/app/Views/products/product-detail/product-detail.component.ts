import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
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
  constructor() { }

  ngOnInit(): void {
  }

  buyProduct(){
  }
}
