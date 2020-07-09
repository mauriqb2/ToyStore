import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Enterprise } from '../models/enterprise';


const httpOptions = {
  headers : new HttpHeaders({
    'Content-Type':'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class EnterpriseService {
  url = "http://localhost:50162/api/Enterprise"

  constructor(private http:HttpClient) { }

  getenterprises():Observable<Enterprise[]> {
    return this.http.get<Enterprise[]>(this.url);
  }

  getenterprise(enterprise:Enterprise):Observable<Enterprise> {
    return this.http.get<Enterprise>(this.url+`/${enterprise.id}`);
  }

  addenterprise(enterprise:Enterprise):Observable<Enterprise>{
    return this.http.post<Enterprise>(this.url, enterprise, httpOptions);
  }

  deleteenterprise(enterprise:Enterprise):Observable<Enterprise>{
    return this.http.delete<Enterprise>(this.url+`/${enterprise.id}`);
  }

  updateenterprise(enterprise:Enterprise):Observable<any>{
    return this.http.put(this.url+`/${enterprise.id}`, enterprise);
  }

  deleteenterprises(enterprises:Number[]){
    return this.http.post(this.url+'/BatchDelete', enterprises, httpOptions);

  }

}