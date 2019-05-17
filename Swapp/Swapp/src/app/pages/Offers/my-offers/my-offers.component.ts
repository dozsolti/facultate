import { Component, OnInit } from '@angular/core';
import { OfferService } from 'src/app/services/offer.service';
import { HttproModel } from 'src/app/services/httpro/httpro.model';

@Component({
  selector: 'app-my-offers',
  templateUrl: './my-offers.component.html',
  styleUrls: ['./my-offers.component.scss']
})
export class MyOffersComponent implements OnInit {
  offersModel = new HttproModel([]);

  tabs = [
    { id: "waiting", name: "In asteptare" },
    { id: "running", name: "In derulare" },
    { id: "ready", name: "Puse de tine" },
    { id: "closed", name: "Completate" }
  ]
  constructor(private offerService: OfferService) {

    /*for (let i = 0; i < 5; i++)
      this.offers.push({
        id: new Date().valueOf(),
        created: new Date(),
        description: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Veritatis perspiciatis at fugit quaerat voluptatem! Quidem!",
        user: {
          picture: "",
          name: "Lorem ipsum"
        }
      });*/
  }


  ngOnInit() {
    this.offerService.GetMyOffers(this.offersModel).then(hasError => {
      if (hasError === false)
        for (let i = 0; i < this.tabs.length; i++)
          this.tabs[i].name += ` (${this.GetOffers(this.tabs[i].id).length})`;
    });
  }

  GetOffers(status) {
    return this.offersModel.value.filter(v => v.status === status);
  }
}
