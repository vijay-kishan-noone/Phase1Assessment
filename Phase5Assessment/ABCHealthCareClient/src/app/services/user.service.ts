import { environment } from './../../environments/environment';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { User } from './../models/user';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private url = environment.serverURL;

  constructor(private http: HttpClient) {
  }
  getAllUsers(){
    return this.http.get<User[]>(this.url + 'users/');
  }
  getUser(userName:string){
    return this.http.get<User>(this.url + 'users/' + userName);
  }
  addUser(user:User){
    return this.http.post<User>(this.url+'users',user,{
      headers : new HttpHeaders({
        'Content-Type':'application/json'
      })
    });
  }
}
