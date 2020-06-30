import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AppointmentComponent } from './appointment/appointment.component';
import { PassengerComponent } from './passenger/passenger.component';
import { LoginComponent } from './Login/Login.component';
import { AppointmentListComponent } from './appointment/appointmentList.component';
import { ReactiveFormsModule } from '@angular/forms';
import { PassengerListComponent } from './passenger/passengerList.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AppointmentComponent,
    PassengerComponent,
    AppointmentListComponent,
    PassengerListComponent,
    LoginComponent 
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: LoginComponent, pathMatch: 'full' },
      { path: 'appointment', component: AppointmentListComponent },
      { path: 'home', component: HomeComponent },
      { path: 'passenger', component: PassengerListComponent },
      { path: 'addpassenger/:id', component: PassengerComponent },
      { path: 'addappointment/:id', component: AppointmentComponent },
      { path: 'addpassenger', component: PassengerComponent },
      { path: 'addappointment', component: AppointmentComponent },
      
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
