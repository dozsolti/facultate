import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  username = "abc";
  password = "123";

  message = "";
  constructor(private router: Router,
    private userservice: UserService) { }

  ngOnInit() {
  }
  Login() {
    this.userservice.Login(this.username,this.password).subscribe(response=>{
      if(response.status==="error")
        this.message = response.message;
      else
        this.router.navigateByUrl('/dashboard');
    });
  }
}
