import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddProductComponent } from './Views/add-product/add-product.component';
import { DashboardComponent } from './Views/dashboard/dashboard.component';
import { HomeComponent } from './Views/home/home.component';
import { NosotrosComponent } from './Views/nosotros/nosotros.component';
import { ProductDetailComponent } from './Views/products/product-detail/product-detail.component';
import { ProductsComponent } from './Views/products/products.component';
import { RegisterComponent } from './Views/register/register.component';
import { SignInComponent } from './Views/signin/signin.component';

const routes: Routes = [
  { path: '', redirectTo: '/Dashboard', pathMatch:'full' },
  { path: 'Home', component:HomeComponent},
  { path: 'Dashboard', component:DashboardComponent},
  { path: 'SignIn', component: SignInComponent },
  { path: 'Register', component: RegisterComponent },
  { path: 'Products', component: ProductsComponent },
  { path: 'Products/Detail/:id', component: ProductDetailComponent },
  { path: 'Nosotros', component: NosotrosComponent }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
