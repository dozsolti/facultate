import { Component, OnInit } from '@angular/core';
import { BookService } from 'src/app/services/book.service';
import { OfferService } from 'src/app/services/offer.service';
import { HttproModel } from 'src/app/services/httpro/httpro.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-offer',
  templateUrl: './create-offer.component.html',
  styleUrls: ['./create-offer.component.scss']
})
export class CreateOfferComponent implements OnInit {
  books = new HttproModel([]);

  searchQuery = "";

  selectedBook = { isbn: null };
  description = "";

  createOfferModel = new HttproModel("");

  constructor(private router:Router,
    private bookService: BookService, private offerService: OfferService) { }


  ngOnInit() {
    this.Search();
  }

  Search() {
    this.selectedBook = { isbn: null };
    this.bookService.Search(this.books, this.searchQuery === "" ? "a" : this.searchQuery).then(hasError => {
      if (hasError === false) {
        for (let i = 0; i < this.books.value.items.length; i++)
          this.books.value.items[i] = this.bookService.PipeSmallBook(this.books.value.items[i]);
      }
    })
  }
  CreateOffer() {
    window.scrollTo(0, 0);
    this.offerService.CreateOffer(this.createOfferModel, this.selectedBook.isbn, this.description)
      .then(hasError => {
        if(hasError === false )
          this.router.navigate(['offer',this.createOfferModel.value]);
      })
  }
}
