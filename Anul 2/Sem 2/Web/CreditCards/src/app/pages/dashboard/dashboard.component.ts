import { Component, OnInit } from '@angular/core';
import { CardService } from 'src/app/services/card.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  cards = [];
  errorMessage = "";
  currentCard: any;
  constructor(private cardService: CardService) { }

  ngOnInit() {
    this.GetAllCards();
  }
  GetAllCards() {
    this.errorMessage = "";
    this.cardService.GetMyCards().subscribe(response => {
      if (response.status === "error")
        this.errorMessage = response.message;
      else
        this.cards = response.cards;
    });
  }
  DeleteCurrentCard() {
    this.cardService.DeleteCardById(this.currentCard.id).subscribe(response => {
      if (response.status === "error")
        this.errorMessage = response.message;
      else
        this.GetAllCards();
    });
  }
}
