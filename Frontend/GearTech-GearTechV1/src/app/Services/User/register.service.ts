import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RegisterI } from 'src/app/Models/Register.interface';
import { ResponseI } from 'src/app/Models/Response.interface';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  url:string = "https://localhost:44346/api/User"

  constructor(private http:HttpClient) { }

  RegisterUser(form:RegisterI):Observable<ResponseI>{
    let dir = this.url;
    return this.http.post<ResponseI>(dir,form);
  }
}
