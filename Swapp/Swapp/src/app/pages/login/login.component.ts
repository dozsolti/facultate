import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserService } from 'src/app/services/user.service';
import { HttproModel } from 'src/app/services/httpro/httpro.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  user = new FormGroup({
    username: new FormControl('', [Validators.required, Validators.min(3)]),
    password: new FormControl('', [Validators.required, Validators.min(3)]),
  });

  loginModel = new HttproModel('');

  constructor(private userService:UserService, private router:Router) { }

  ngOnInit() {
  }

  ForgotPassword(){
    alert("Pacat");
  }

  Login(){
    let username = this.user.value.username;
    let password = this.user.value.password;
    this.userService.Login(this.loginModel, username, password)
    .then((wasError)=>{
      
      if(wasError===false){
        this.userService.SetLogin(this.loginModel.value);
        this.router.navigate(['/offers'])
      }
    });
  }
}
