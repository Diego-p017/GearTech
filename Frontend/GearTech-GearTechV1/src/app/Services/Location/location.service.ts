import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LocationI } from 'src/app/Models/Location.interface';

@Injectable({
  providedIn: 'root'
})
export class LocationService {

  url:string = "https://localhost:44346/api/"

  constructor(private http:HttpClient) { }

  getLocation():Observable<LocationI[]>{
    let dir = this.url + "Location";
    return this.http.get<LocationI[]>(dir)
  }
}
