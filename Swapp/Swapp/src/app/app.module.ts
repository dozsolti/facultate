import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from './app.component';
import { BookComponent } from './components/book/book.component';
import { HomeComponent } from './pages/home/home.component';
import { HeaderComponent } from './components/header/header.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ViewBookComponent } from './pages/Books/view-book/view-book.component';
import { ViewOfferComponent } from './pages/Offers/view-offer/view-offer.component';
import { MyOffersComponent } from './pages/Offers/my-offers/my-offers.component';
import { SignupComponent } from './pages/signup/signup.component';
import { LoginComponent } from './pages/login/login.component';
import { CreateOfferComponent } from './pages/Offers/create-offer/create-offer.component';

import { MatTabsModule } from '@angular/material/tabs';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { NotAuthorizedComponent } from './pages/errors/not-authorized/not-authorized.component';
import { NotFoundComponent } from './pages/errors/not-found/not-found.component';
import { UserProfileComponent } from './pages/user-profile/user-profile.component';

@NgModule({
  declarations: [
    AppComponent,
    BookComponent,
    HomeComponent,
    HeaderComponent,
    ViewBookComponent,
    ViewOfferComponent,
    MyOffersComponent,
    SignupComponent,
    LoginComponent,
    CreateOfferComponent,
    NotAuthorizedComponent,
    NotFoundComponent,
    UserProfileComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    FormsModule,
    MatTabsModule, MatInputModule, MatButtonModule,MatCardModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
