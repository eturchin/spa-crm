import { Component } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  phoneNumber!: string;
  password!: string;

  constructor(private router: Router, private authService: AuthService) { }

  onLogin(): void {
    const credentials = {
      phoneNumber: this.phoneNumber,
      password: this.password
    };

    this.authService.onLogin(credentials).subscribe(
      (response: any) => {
        console.log('Login successful', response);
        this.router.navigate(['/personal-area']);
      },
      (error: HttpErrorResponse) => {
        console.error('Login failed', error);
      }
    );
  }
}