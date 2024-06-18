import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth/auth.service';
import { FormsModule } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  firstName!: string;
  lastName!: string;
  email!: string;
  phoneNumber!: string;
  password!: string;
  confirmPassword!: string;

  constructor(private router: Router, private authService: AuthService) { }

  onRegister(): void {
    const data = {
      firstName: this.firstName,
      lastName: this.lastName,
      email: this.email,
      phoneNumber: this.phoneNumber,
      password: this.password,
      confirmPassword: this.confirmPassword
    };

    this.authService.onRegister(data).subscribe(
      (response: any) => {
        console.log('Register successful', response);
        this.router.navigate(['/personal-area']);
      },
      (error: HttpErrorResponse) => {
        console.error('Register failed', error);
      }
    );
  }
}