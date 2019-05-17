import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { HttproModel } from 'src/app/services/httpro/httpro.model';
import { UserService } from 'src/app/services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  newUser = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.min(3)]),
    email: new FormControl('', [Validators.required, Validators.min(3)]),
    username: new FormControl('', [Validators.required, Validators.min(3)]),
    password: new FormControl('', [Validators.required, Validators.min(3)]),
    telephone: new FormControl('', [Validators.required])
  });

  signUpModel  = new HttproModel('');

  constructor(private userService: UserService, private router:Router) { }

  ngOnInit() {
  }

  Signup(){
    
    this.userService.Signup(this.signUpModel,this.newUser.value)
    .then((successed)=>{
      if(successed)
        this.router.navigate(['/login'])
    });
  }
}
