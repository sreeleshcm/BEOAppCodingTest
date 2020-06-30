import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, ParamMap } from '@angular/router';
import {OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
//import { Observable } from 'rxjs/Observable';
@Component({
  selector: 'app-passenger',
  templateUrl: './Passenger.component.html'
})
export class PassengerComponent implements OnInit  {
  public appointments: any[] = [];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private route: ActivatedRoute) {
       
  }


  SignupForm: FormGroup;
  progress = false;
  status = 0;
  update = false;
  ngOnInit() {
    this.SignupForm = new FormGroup({      
      'firstName': new FormControl(null, [Validators.required]),
      'lastName': new FormControl(null, [Validators.required]),
      'weight': new FormControl(null, [Validators.required]),
      'appointmentId': new FormControl(null),
      'id': new FormControl(0)
    });

    this.SignupForm.setValue({
      'firstName': '',
      'lastName': '',
      'weight': 0,
      'appointmentId': 0,
      'id':0
    })

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    };
    this.http.get(this.baseUrl + 'api/Appointment', httpOptions).subscribe((result: any) => {      
      this.appointments = result;
    }, error => console.error(error));

    if (this.route.snapshot.params.id) {
      this.update = true;
      const httpOptions = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json',
        })
      };

      this.http.get(this.baseUrl + 'api/Passenger/' + this.route.snapshot.params.id, httpOptions).subscribe((result: any) => {
        this.progress = false;
        this.status = result.status;
        this.SignupForm.reset({
          'firstName': result.firstName,
          'lastName': result.lastName,
          'weight': result.weight,
          'appointmentId': result.appointmentId,
          'id': result.id
        })
      }, error => console.error(error));
    }
  }

  onSubmit() {
    this.progress = true;
    this.SignupForm.value.appointmentId = +this.SignupForm.value.appointmentId;
    this.SignupForm.value.weight = +this.SignupForm.value.weight; 
    let FormData: any = JSON.stringify(this.SignupForm.value);
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    };
    if (!this.update) {
      this.http.post(this.baseUrl + 'api/Passenger', FormData, httpOptions).subscribe(result => {
        this.progress = false;
        this.SignupForm.reset({
          'firstName': '',
          'lastName': '',
          'weight': 0,
          'appointmentId': 0
        })
      }, error => console.error(error));
    }
    else {
      this.http.put(this.baseUrl + 'api/Passenger', FormData, httpOptions).subscribe(result => {
        this.progress = false;
        this.SignupForm.reset({
          'firstName': '',
          'lastName': '',
          'weight': 0,
          'appointmentId': 0
        })
      }, error => console.error(error));
    }
   
  }

}

interface Passenger {
  firstname: string;
  lastname: number;
  weight: number;
}
