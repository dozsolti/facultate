import { Component, OnInit } from '@angular/core';
import { BookService } from 'src/app/services/book.service';
import { ActivatedRoute } from '@angular/router';
import { HttproModel } from 'src/app/services/httpro/httpro.model';
import { OfferService } from 'src/app/services/offer.service';

@Component({
  selector: 'app-view-book',
  templateUrl: './view-book.component.html',
  styleUrls: ['./view-book.component.scss']
})
export class ViewBookComponent implements OnInit {
  bookModel = new HttproModel();
  book = null;

  offersModel = new HttproModel([]);

  constructor(private route: ActivatedRoute,
    private bookService: BookService, private offerService: OfferService) {
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.bookService.getBookByISBN(this.bookModel, params.isbn).then(hasError => {
        if (hasError === false) {
          try {
            this.book = this.bookService.PipeFullBook(this.bookModel.value.items[0]);
          } catch (ex) {
            this.bookModel.message = "Cartea nu exista.";
            this.bookModel.hasError = true;
            this.book = null;
          }
          this.offerService.GetOfferByIsbn(this.offersModel, params.isbn);
        }
      })
    })
  }

}
