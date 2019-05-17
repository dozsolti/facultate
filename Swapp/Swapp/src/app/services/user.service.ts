import { Injectable } from '@angular/core';
import { Httpro, BodyTypes } from './httpro/httpro.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {


  constructor(private httpro: Httpro) { }

  SetLogin(token) {
    localStorage.setItem('token', token);
  }
  isLoggined() {
    return (localStorage.getItem('token') || "").length > 0;
  }
  GetLogginedUserId() {
    if (this.isLoggined() === false)
      return "";
    return localStorage.getItem('token').split('_')[1];
  }
  Logout() {
    localStorage.removeItem('token');

  }
  Login(model, username, password) {
    return this.httpro
      .post(`${environment.baseURL}/public/users/login`)
      .bodyType(BodyTypes.FORMDATA)
      .body({ username, password })
      .to(model)
      .exec()
  }

  Signup(model, body) {
    return this.httpro
      .post(`${environment.baseURL}/public/users/signup`)
      .body(body)
      .to(model)
      .exec();
  }

  GetUser(model, username){
    return this.httpro
      .get(`${environment.baseURL}/public/users/${username}`)
      .to(model)
      .exec();
  }
}
