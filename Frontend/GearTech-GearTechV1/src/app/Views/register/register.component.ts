import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { RegisterI } from 'src/app/Models/Register.interface';
import { ResponseI } from 'src/app/Models/Response.interface';
import { AuthService } from 'src/app/Services/Authentication/auth.service';
import { LocationService } from 'src/app/Services/Location/location.service';
import { RegisterService } from 'src/app/Services/User/register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  Location: any = [];

  registerForm = new FormGroup({
     documentNumber   : new FormControl('')
    ,firstName        : new FormControl('')
    ,lastName         : new FormControl('')
    ,email            : new FormControl('')
    ,confirmedEmail   : new FormControl('')
    ,phone            : new FormControl('')
    ,locationId       : new FormControl('')
    ,password         : new FormControl('')
    ,confirmedPassword: new FormControl('')
    ,address          : new FormControl('')
  })

  constructor(
     private apiReg:RegisterService
    ,private apiLoc:LocationService
    ,private router:Router
    ,private snackBar: MatSnackBar
  ) { }

  errorStatus: boolean = false;
  errorMsj: string = "";
  colorSnakBar : any;

  ngOnInit(): void {
    this.apiLoc.getLocation().subscribe(loc =>{
      this.Location= loc
      console.log(this.Location)
    })
  }
  
  postRegisterForm(form:RegisterI){
    this.apiReg.RegisterUser(form).subscribe(data =>{
      form.role= "USER";
      let dataResponse:ResponseI = data;       
      if(dataResponse.status == "Ok"){
       console.log(dataResponse.error)
        localStorage.setItem("token",data.token);
        this.colorSnakBar= 'mat-accent';
        this.errorMsj=dataResponse.response;
        this.openSnackBar(this.errorMsj,this.colorSnakBar);
        this.router.navigate(['SignIn']);
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
