import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import {OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
//import { Observable } from 'rxjs/Observable';
@Component({
  selector: 'app-passenger',
  templateUrl: './PassengerList.component.html',
  styleUrls: ['./passenger.component.scss']
})
export class PassengerListComponent implements OnInit  {
  public passengers: any[] = [];

  constructor(private http: HttpClient,@Inject('BASE_URL') private baseUrl: string) {
       
  }

  ngOnInit() {
        const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    };
    this.http.get(this.baseUrl + 'api/Passenger', httpOptions).subscribe((result: any) => {      
      this.passengers = result;
    }, error => console.error(error));
  }



}


