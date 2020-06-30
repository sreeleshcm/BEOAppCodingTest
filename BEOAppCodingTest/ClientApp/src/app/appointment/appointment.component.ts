import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { ActivatedRoute, ParamMap } from '@angular/router';
@Component({
  selector: 'app-appointment',
  templateUrl: './appointment.component.html'
})
export class AppointmentComponent {
  confirmation = [
    {
      id: true,
      name: 'Confirmed'
    },
    {
      id: false,
      name: 'Not-Confirmed'
    }
  ];
  progress = false;
  update = false;
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private route: ActivatedRoute) {
    
  }

  SignupForm: FormGroup;
  ngOnInit() {
    this.SignupForm = new FormGroup({
      'releaseDate': new FormControl(null, [Validators.required]),
      //'confirmed': new FormControl(null, [Validators.required]),
      'capacity': new FormControl(null, [Validators.required]),
      'id': new FormControl(0),
    });

    this.SignupForm.setValue({
      'releaseDate': new Date(),
      //'confirmed': true,
      'capacity': 0,
      'id':0
    })
    if (this.route.snapshot.params.id) {
      this.update = true;
      const httpOptions = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json',
        })
      };

      this.http.get(this.baseUrl + 'api/Appointment/' + this.route.snapshot.params.id, httpOptions).subscribe((result:any) => {
        this.progress = false;
        this.SignupForm.reset({
          'releaseDate': result.releaseDate,
          //'confirmed': result.confirmed,
          'capacity': result.capacity,
          'id': result.id
        })
      }, error => console.error(error));
    }
  }

  onSubmit() {
    this.progress = true;
    
    let FormData:any = JSON.stringify(this.SignupForm.value);
    //FormData.confirmed = FormData.confirmed == 0 ? false : true;
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    };
    if (!this.update) {
      this.http.post(this.baseUrl + 'api/Appointment', FormData, httpOptions).subscribe(result => {
        this.progress = false;
        this.SignupForm.reset({
          'releaseDate': new Date(),
          //'confirmed': true,
          'capacity': 0
        })
      }, error => console.error(error));
    }
    else {
      this.http.put(this.baseUrl + 'api/Appointment', FormData, httpOptions).subscribe(result => {
        this.progress = false;
        this.SignupForm.reset({
          'releaseDate': new Date(),
          //'confirmed': true,
          'capacity': 0,
        })
      }, error => console.error(error));
    }
    
  }
}
