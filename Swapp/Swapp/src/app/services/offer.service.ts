import { Injectable } from '@angular/core';
import { Httpro, BodyTypes } from './httpro/httpro.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OfferService {

  constructor(private httpro: Httpro) { }

  GetMyOffers(model) {
    return this.httpro
      .get(`${environment.baseURL}/private/offers`)
      .useToken()
      .to(model)
      .exec()
  }
  getLatest(model) {
    return this.httpro
      .get(`${environment.baseURL}/public/offers/latest`)
      .useToken()
      .to(model)
      .exec()
  }
  CreateOffer(model, isbn, description) {
    return this.httpro
      .post(`${environment.baseURL}/private/offers`)
      .useToken()
      .body({
        isbn,
        description
      })
      .to(model)
      .exec()
  }

  GetOfferByIsbn(model, isbn) {
    return this.httpro
      .get(`${environment.baseURL}/public/offers/book/${isbn}`)
      .to(model)
      .exec()
  }
  GetOfferById(model, offerId) {
    return this.httpro
      .get(`${environment.baseURL}/private/offers/${offerId}`)
      .useToken()
      .to(model)
      .exec()
  }

  UpdateOffer(model, offerId, body) {
    return this.httpro
      .put(`${environment.baseURL}/private/offers/${offerId}`)
      .useToken()
      .bodyType(BodyTypes.FORMDATA)
      .body(body)
      .to(model)
      .exec()
  }
  AcceptOffer(model, offerId) {
    return this.UpdateOffer(model, offerId, { action: 'accept' });
  }

  AproveOffer(model, offerId) {
    return this.UpdateOffer(model, offerId, { action: 'aprove' });
  }

  RejectOffer(model, offerId, message) {
    return this.UpdateOffer(model, offerId, { action: 'reject', message });
  }

  CloseOffer(model, offerId) {
    return this.UpdateOffer(model, offerId, { action: 'close' });

  }
}
