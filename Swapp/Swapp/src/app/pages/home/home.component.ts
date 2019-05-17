import { Component, OnInit } from '@angular/core';
import { BookService } from 'src/app/services/book.service';
import { HttproModel } from 'src/app/services/httpro/httpro.model';
import { OfferService } from 'src/app/services/offer.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  latestOffersModel = new HttproModel([]);
  latestOffers = []
  constructor(private bookService: BookService, private offerService: OfferService) { }

  ngOnInit() {
    this.offerService.getLatest(this.latestOffersModel).then(hasError => {
      if (hasError == false) {
        this.LoadLatestBooks();

      }
    });
  }
  async LoadLatestBooks() {
    this.latestOffersModel.message = "Se incarca...";
    for (let offer of this.latestOffersModel.value) {
      let bookModel = new HttproModel({});
      await this.bookService.getBookByISBN(bookModel, offer.isbn)
      try {
        this.latestOffers.push(this.bookService.PipeSmallBook(bookModel.value.items[0]));
      } catch (ex) {

      }
    }
    this.latestOffersModel.message = "";
  }

}
