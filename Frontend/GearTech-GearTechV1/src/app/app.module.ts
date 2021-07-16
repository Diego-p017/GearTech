import { AngularMaterialModule } from './angular-material.module';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA  } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import {HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DashboardComponent } from './Views/dashboard/dashboard.component';
import { NavbarComponent } from './Templates/navbar/navbar.component';
import { SignInComponent } from './Views/signin/signin.component';
import { RegisterComponent } from './Views/register/register.component';
import { FooterComponent } from './Templates/footer/footer.component';
import { MAT_SNACK_BAR_DEFAULT_OPTIONS } from '@angular/material/snack-bar';
import { HomeComponent } from './Views/home/home.component';
import { ProductsComponent } from './Views/products/products.component';
import { IvyCarouselModule } from 'angular-responsive-carousel';
import { AddProductComponent } from './Views/add-product/add-product.component';
import { ImageUploadModule } from 'angular2-image-upload';
import { EditProductComponent } from './Views/edit-product/edit-product.component';
import { ProductDetailComponent } from './Views/products/product-detail/product-detail.component';
import { NosotrosComponent } from './Views/nosotros/nosotros.component';
import { CarouselComponent } from './Templates/carousel/carousel.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent
    ,DashboardComponent
    ,NavbarComponent
    ,SignInComponent
    ,RegisterComponent
    ,FooterComponent
    ,HomeComponent
    ,ProductsComponent
    ,AddProductComponent
    ,EditProductComponent
    ,ProductDetailComponent
    ,NosotrosComponent
    ,CarouselComponent
  ],
  imports: [
    AngularMaterialModule
    ,BrowserModule
    ,AppRoutingModule
    ,BrowserAnimationsModule
    ,FormsModule 
    ,ReactiveFormsModule
    ,FlexLayoutModule 
    ,HttpClientModule
    ,IvyCarouselModule 
    ,ImageUploadModule.forRoot()
    ,NgbModule
  ],
  providers:[],
  //providers: [{provide: MAT_SNACK_BAR_DEFAULT_OPTIONS, useValue: {duration: 1500}}],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
