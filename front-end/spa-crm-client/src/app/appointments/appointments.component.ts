`import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { apiEndpoint, constants } from '../constants/constants';
import { CommonModule, DatePipe } from '@angular/common';

@Component({
  selector: 'app-appointments',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './appointments.component.html',
  styleUrl: './appointments.component.css',
  providers: [DatePipe]
})
export class AppointmentsComponent implements OnInit {
  appointmentData: any[] = [];

  constructor(private http: HttpClient, private datePipe: DatePipe) { }

  ngOnInit(): void {
    this.getAppointments();
  }

  getAppointments(): void {
    const accessToken = localStorage.getItem(constants.ACCESS_TOKNE);

    if (accessToken) {
      const headers = new HttpHeaders().set('Authorization', `Bearer ${accessToken}`);
      const url = `${apiEndpoint.BookingEndpoint.getMyAppointments}`;
      this.http.get<any>(url, { headers: headers })
        .subscribe((data: any) => {
          this.appointmentData = data.elements.map((appointment: any) => ({
            ...appointment,
            formattedDate: this.datePipe.transform(appointment.date, 'dd.MM.yyyy'),
            formattedTime: this.datePipe.transform(appointment.date, 'HH:mm:ss')
          }));
        });
    }
  }
}
`