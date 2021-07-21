import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginI } from 'src/app/Models/Login.interface';
import { ResponseI } from 'src/app/Models/Response.interface';
import { AuthService } from 'src/app/Services/Authentication/auth.service';
import {MatSnackBar, MatSnackBarConfig} from '@angular/material/snack-bar';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SignInComponent implements OnInit {

  durationInSeconds = 5;

  loginForm = new FormGroup({
    UserName : new FormControl('',Validators.required),
    Password : new FormControl('',Validators.required)
  })

  constructor(
    private apiAuth:AuthService
    ,private router:Router
    ,private snackBar: MatSnackBar
  ) { }

  errorStatus: boolean = false;
  errorMsj: string = "";
  colorSnakBar : any;
  
  ngOnInit(): void {
  }

//validar si el token existe
  checkLocalStorage(){
    if(localStorage.getItem('token')){
      this.router.navigate(['Dashboard']);
    }
  }
//login y recibir token
  onLogin(form: LoginI){
    this.apiAuth.LoginByEmail(form).subscribe(data =>{
      console.log(data)

      const helper = new JwtHelperService();
      const decodedToken = helper.decodeToken(data.token);
      // let isAdmin = decodedToken.Email
      // console.log('isAdmin ' ,decodedToken.Email)
      console.log('isAdmin ' ,decodedToken.email)
      let dataResponse:ResponseI = data;       
      if(dataResponse.status == "Ok"){
       console.log(dataResponse.error)
        localStorage.setItem("token",data.token);
        this.colorSnakBar= 'mat-accent';
        this.errorMsj=dataResponse.response;
        this.openSnackBar(this.errorMsj,this.colorSnakBar);
       // this.router.navigate(['Products']);
       
        if(decodedToken.email === "ADMIN"){
          this.router.navigate(['Home']);
        }else{
          this.router.navigate(['Products']);
        }
      }else{
        this.colorSnakBar= 'mat-warn';
        this.errorStatus = true;
        this.errorMsj=dataResponse.response;
        this.openSnackBar(this.errorMsj,this.colorSnakBar);
      }
    })
 }
 openSnackBar(message: string, colorSnakBar: any) {
  this.snackBar.open(message, '',{
    duration: 1500,
    panelClass: ['mat-toolbar',colorSnakBar]
  });
}


}


