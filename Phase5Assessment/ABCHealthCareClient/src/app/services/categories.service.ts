import { environment } from './../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Categories } from '../models/categories';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  private url = environment.serverURL;
  constructor(private http:HttpClient) { }
  getAllCategories(){
    return this.http.get<Categories[]>(this.url + 'categories/');
  }
  addCategory(cat:Categories){
    return this.http.post<Categories>(this.url+'categories',cat,{
      headers : new HttpHeaders({
        'Content-Type':'application/json'
      })
    });
  }
}
