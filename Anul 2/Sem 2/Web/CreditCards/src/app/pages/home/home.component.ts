import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  date=[];
  constructor() { }

  ngOnInit() {
    for(let i= 0;i<6;i++){
      this.date.push({
        title:"Titlu #"+i,
        text: "text"
      })
    }
  }

}
