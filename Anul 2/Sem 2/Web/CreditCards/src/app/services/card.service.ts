import { Injectable } from '@angular/core';
import { ResponseContentType, Http } from '@angular/http';
import { environment } from 'src/environments/environment';
import { UserService } from './user.service';
import { map } from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class CardService {

  constructor(private http: Http,
    private userService: UserService) { }


  CreateCard(number) {
    let body = new FormData()
    body.append('value', number);
    let httpOptions = {
      responseType: ResponseContentType.Text
    }

    return this.http.post(`${environment.baseUrl}/cards/${this.userService.token}`, body, httpOptions).pipe(
      map(response => response.json())
    );
  }
  DeleteCardById(id) {
    let httpOptions = {
      responseType: ResponseContentType.Text
    }

    return this.http.delete(`${environment.baseUrl}/cards/${id}/${this.userService.token}`, httpOptions).pipe(
      map(response => response.json())
    );
  }
  GetMyCards() {

    let httpOptions = {
      responseType: ResponseContentType.Text
    }
    return this.http.get(`${environment.baseUrl}/cards/${this.userService.token}`, httpOptions)
      .pipe(
        map(response => response.json())
      );
  }
}
