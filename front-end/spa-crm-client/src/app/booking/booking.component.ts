import { Component, OnInit } from '@angular/core';
import { apiEndpoint, constants } from '../constants/constants';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-booking',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './booking.component.html',
  styleUrl: './booking.component.css'
})
export class BookingComponent implements OnInit {
  services: any[] = [];
  selectedService: any;
  selectedSpecialist: any;
  specialists: any[] = [];
  step: number = 1;
  bookingDate: string = '';
  bookingTime: string = '';
  selectedServiceId: string = '';
  selectedSpecialistId: string = '';

  minBookingDate: string;
  minBookingTime: string;
  maxBookingTime: string;

  constructor(private http: HttpClient) {
    const currentDateTime = new Date();

    this.minBookingDate = currentDateTime.toISOString().split('T')[0];
    this.minBookingTime = '09:00';
    this.maxBookingTime = '21:00';
   }

  ngOnInit(): void {
    this.getServices();
  }

  getServices(): void {
    this.http.get<any>(apiEndpoint.ServiceEndpoint.getServices)
      .subscribe((data: any) => {
        this.services = data.elements;
      });
  }

  getSpecialists(serviceId: string): void {
    const url = `${apiEndpoint.SpecialistEndpoint.getSpecialists}?ServiceId=${serviceId}`;
    this.http.get<any>(url)
      .subscribe((data: any) => {
        this.specialists = data.elements;
      });
  }

  onSelectService(): void {
    if (this.selectedServiceId) {
      this.selectedService = this.services.find(service => service.id === this.selectedServiceId);
    }
  }

  onSelectSpecialist(): void {
    if (this.selectedSpecialistId) {
      this.selectedSpecialist = this.specialists.find(specialist => specialist.id === this.selectedSpecialistId);
    }
  }

  submitBooking(): void {
    const bookingData = {
      ServiceId: this.selectedServiceId,
      SpecialistId: this.selectedSpecialistId,
      Date: new Date(),
      ClientName: '', 
      PhoneNumber: ''
    };

    const accessToken = localStorage.getItem(constants.ACCESS_TOKNE);
    
    this.http.post(apiEndpoint.BookingEndpoint.createBooking, bookingData, { 
      headers: {
        Authorization: `Bearer ${accessToken}`
      }
      })
      .subscribe(
        response => {
          console.log('Бронирование успешно отправлено:', response);
        },
        error => {
          console.error('Ошибка при отправке бронирования:', error);
        }
      );
  }

  nextStep(): void {
    if (this.step < 3) {
      this.step++;
      if (this.step == 2)
        {
          this.getSpecialists(this.selectedServiceId);
        }
    }
  }

  prevStep(): void {
    if (this.step > 1) {
      this.step--;
      if (this.step == 1)
        {
          this.selectedServiceId = '';
        }
    }
  }
}
