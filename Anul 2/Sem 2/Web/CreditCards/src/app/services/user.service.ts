import { Injectable } from '@angular/core';
import { ResponseContentType, Http } from '@angular/http';
import { environment } from 'src/environments/environment';
import { map, tap } from "rxjs/operators";
@Injectable({
  providedIn: 'root'
})
export class UserService {

  token = "";

  constructor(private http: Http) { }

  ngOnInit() { }

  isLoggined(): boolean {
    return this.token !== "";
  }
  Logout(){
    this.token = "";
  }
  Login(username, password) {
    let body = new FormData()
    body.append('username', username);
    body.append('password', password);

    let httpOptions = {
      responseType: ResponseContentType.Text
    }

    return this.http.post(`${environment.baseUrl}/users/login`, body, httpOptions).pipe(
      map(response => response.json()),
      tap(response => {
        if (response.status === "success")
          this.token = response.token;
        return response;
      }));
  }
}
