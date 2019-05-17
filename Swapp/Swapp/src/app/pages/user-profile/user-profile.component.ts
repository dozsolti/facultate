import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttproModel } from 'src/app/services/httpro/httpro.model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss']
})
export class UserProfileComponent implements OnInit {
  username = null;
  userModel = new HttproModel({});
  constructor(private route: ActivatedRoute,private userService: UserService) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.username = params.username;
      this.GetUser();
    })
  }
  GetUser(){
    this.userService.GetUser(this.userModel ,this.username);
  }

}
