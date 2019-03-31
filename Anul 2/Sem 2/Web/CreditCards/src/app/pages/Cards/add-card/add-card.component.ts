import { Component, OnInit } from '@angular/core';
import { CardService } from 'src/app/services/card.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-card',
  templateUrl: './add-card.component.html',
  styleUrls: ['./add-card.component.scss']
})
export class AddCardComponent implements OnInit {
  
  cardNumber = "";
  errorMessage = "";
  constructor(private router:Router,
    private cardService: CardService) { }

  ngOnInit() { }

  Salveaza() {
    this.errorMessage = "";
    this.cardService.CreateCard(this.cardNumber).subscribe(response => {
      if(response.status==="error")
        this.errorMessage =  response.message;
      else
        this.router.navigateByUrl('/dashboard');
    });
  }
}
