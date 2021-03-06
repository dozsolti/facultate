import { Component } from '@angular/core';
import { UserService } from './services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Credit Cards';
  constructor(private router: Router,public userService: UserService){
    
  }
  Logout(){
    this.userService.Logout();
    this.router.navigateByUrl('/');
  }
}
