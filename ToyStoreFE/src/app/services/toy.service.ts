import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Toy } from '../models/toy';


const httpOptions = {
  headers : new HttpHeaders({
    'Content-Type':'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class ToyService {
  url = "http://localhost:50162/api/Toy"

  constructor(private http:HttpClient) { }

  getToys():Observable<Toy[]> {
    return this.http.get<Toy[]>(this.url);
  }

  getToy(toy:Toy):Observable<Toy> {
    return this.http.get<Toy>(this.url+`/${toy.id}`);
  }

  addToy(toy:Toy):Observable<Toy>{
    return this.http.post<Toy>(this.url, toy, httpOptions);
  }

  deleteToy(toy:Toy):Observable<Toy>{
    return this.http.delete<Toy>(this.url+`/${toy.id}`);
  }

  updateToy(toy:Toy):Observable<any>{
    return this.http.put(this.url+`/${toy.id}`, toy);
  }

  deleteToys(toys:Number[]){
    return this.http.post(this.url+'/BatchDelete', toys, httpOptions);

  }

}
