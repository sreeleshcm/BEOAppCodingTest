import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
@Component({
  selector: 'app-appointmentList',
  templateUrl: './appointmentList.component.html',
  styleUrls:['./appointment.component.scss']
})
export class AppointmentListComponent {
  appointments: any = [];
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    
  }

  ngOnInit() {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    };
    this.http.get(this.baseUrl + 'api/Appointment', httpOptions).subscribe((result: any) => {
      this.appointments = result;
    }, error => console.error(error));
  }

  confirm(appId,confirmed) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    };
    var inputData = {
      AppointmentId: appId,
      Comfirmed: confirmed  
    }
    this.http.post(this.baseUrl + 'api/Passenger/UpdateStatus', inputData, httpOptions).subscribe((result: any) => {
      this.appointments = result;
      alert("Success");
    }, error => console.error(error));
  }
}
