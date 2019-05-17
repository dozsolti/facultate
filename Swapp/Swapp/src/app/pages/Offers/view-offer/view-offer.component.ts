import { Component, OnInit } from '@angular/core';
import { BookService } from 'src/app/services/book.service';
import { HttproModel } from 'src/app/services/httpro/httpro.model';
import { ActivatedRoute } from '@angular/router';
import { OfferService } from 'src/app/services/offer.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-view-offer',
  templateUrl: './view-offer.component.html',
  styleUrls: ['./view-offer.component.scss']
})
export class ViewOfferComponent implements OnInit {
  bookModel = new HttproModel();
  book = null;

  offerId = null;
  offerModel = new HttproModel();

  rejectMessage = "";

  constructor(private route: ActivatedRoute, private bookService: BookService, private offerService: OfferService, private userService: UserService) {
    /* this.offer = {
      id: new Date().valueOf(), 
      status: "pending", //ready | pending | asking | rejected | running | closed
      created: new Date(),
      description: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Veritatis perspiciatis at fugit quaerat voluptatem! Quidem!",
      user: {
        picture: "",
        name: "Lorem ipsum",
        truths: "Necunoscut"
      },
      rejectedMessage: "Fara motiv."
    }; */

  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.offerId = params.id;
      this.GetOffer();
    })
  }
  async GetOffer() {
    await this.offerService.GetOfferById(this.offerModel, this.offerId);
    if (this.offerModel.isGood() === false)
      return;
    await this.bookService.getBookByISBN(this.bookModel, this.offerModel.value.isbn);

    try {
      this.book = this.bookService.PipeFullBook(this.bookModel.value.items[0]);
    } catch (ex) {
      this.offerModel.message = "Cartea nu exista.";
      this.offerModel.hasError = true;
      this.book = null;
    }

  }
  isMine() {
    return this.userService.GetLogginedUserId() === this.offerModel.value.fromUser.id;
  }
  GetRejectedMessage() {
    try {
      return this.offerModel.value.rejects.find(reject => reject.user.id === this.userService.GetLogginedUserId()).message;
    } catch (ex) {
      return null;
    }
  }

  //#region Updates
  Accept() {
    let acceptModel = new HttproModel();
    this.offerService.AcceptOffer(acceptModel, this.offerId).then(hasError => {
      if (hasError === false)
        this.offerModel.value.status = "pending";// this.GetOffer();
      else {
        alert(acceptModel.message);
      }
    })

  }

  Aprove() {
    let aproveModel = new HttproModel();
    this.offerService.AproveOffer(aproveModel, this.offerId).then(hasError => {
      if (hasError === false)
        this.offerModel.value.status = "running";// this.GetOffer();
      else {
        alert(aproveModel.message);
      }
    })
  }
  Reject() {
    let rejectModel = new HttproModel();
    this.offerService.RejectOffer(rejectModel, this.offerId, this.rejectMessage).then(hasError => {
      if (hasError === false)
        this.offerModel.value.status = "ready";// this.GetOffer();
      else {
        alert(rejectModel.message);
      }
    })
  }

  Close() {
    let closeModel = new HttproModel();
    this.offerService.CloseOffer(closeModel, this.offerId).then(hasError => {
      if (hasError === false)
        this.offerModel.value.status = "closed";// this.GetOffer();
      else {
        alert(closeModel.message);
      }
    })
  }
  //#endregion
}
