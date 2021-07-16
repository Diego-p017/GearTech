import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginI } from 'src/app/Models/Login.interface';
import { RegisterI } from 'src/app/Models/Register.interface';
import { ResponseI } from 'src/app/Models/Response.interface';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  url:string = "https://localhost:44346/api/"

  constructor(private http:HttpClient) { }

  LoginByEmail(form:LoginI):Observable<ResponseI>{
    let direccion = this.url + "Auth";    
    return this.http.post<ResponseI>(direccion,form);
  }
  RegisterUserAut(form:RegisterI):Observable<ResponseI>{   
    return this.http.post<ResponseI>("https://localhost:44346/api/User",form);
  }
}
