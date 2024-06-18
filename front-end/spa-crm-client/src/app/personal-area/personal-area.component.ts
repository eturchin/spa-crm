import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { apiEndpoint, constants } from '../constants/constants';
import { IUser } from '../models/auth.models';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-personal-area',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './personal-area.component.html',
  styleUrl: './personal-area.component.css'
})
export class PersonalAreaComponent implements OnInit {
  userData!: IUser;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getUserInfo();
  }

  getUserInfo(): void {
    const accessToken = localStorage.getItem(constants.ACCESS_TOKNE);
    if (accessToken) {
      this.http.get<IUser>(apiEndpoint.UserEndpoint.getMe, {
        headers: {
          Authorization: `Bearer ${accessToken}`
        }
      }).subscribe((data: any) => {
        this.userData = data.item;
      }, (error) => {
        console.error('Failed to fetch user info:', error);
      });
    } else {
      console.error('Access token not found');
    }
  }
}
