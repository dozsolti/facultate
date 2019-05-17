import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { ViewBookComponent } from './pages/Books/view-book/view-book.component';
import { ViewOfferComponent } from './pages/Offers/view-offer/view-offer.component';
import { MyOffersComponent } from './pages/Offers/my-offers/my-offers.component';
import { SignupComponent } from './pages/signup/signup.component';
import { LoginComponent } from './pages/login/login.component';
import { CreateOfferComponent } from './pages/Offers/create-offer/create-offer.component';
import { AuthGuard } from './services/auth.guard';
import { NotAuthorizedComponent } from './pages/errors/not-authorized/not-authorized.component';
import { NotFoundComponent } from './pages/errors/not-found/not-found.component';
import { UserProfileComponent } from './pages/user-profile/user-profile.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'book/:isbn', component: ViewBookComponent },

  { path: 'offers', component: MyOffersComponent, canActivate: [AuthGuard] },
  { path: 'offer/:id', component: ViewOfferComponent, canActivate: [AuthGuard] },
  { path: 'offers/create', component: CreateOfferComponent, canActivate: [AuthGuard] },

  { path: 'signup', component: SignupComponent },
  { path: 'login', component: LoginComponent },
  { path: 'user/:username', component: UserProfileComponent },


  { path: '403', component: NotAuthorizedComponent },
  { path: '404', component: NotFoundComponent },
  { path: '**', redirectTo: '404' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
