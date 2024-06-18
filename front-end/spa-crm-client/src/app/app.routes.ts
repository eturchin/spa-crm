import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { AboutComponent } from './about/about.component';
import { NotfoundComponent } from './not-found/not-found.component';
import { PersonalAreaComponent } from './personal-area/personal-area.component';
import { authGuard } from './guard/auth.guard';
import { RegisterComponent } from './register/register/register.component';
import { guestGuard } from './guard/guest.guard';
import { HomeComponent } from './home/home.component';
import { BookingComponent } from './booking/booking.component';
import { AppointmentsComponent } from './appointments/appointments.component';

export const routes: Routes = [
    { path: 'appointments', component: AppointmentsComponent, canActivate:[authGuard] },
    { path: 'home', component: HomeComponent },
    { path: "about", component: AboutComponent },
    { path: "login", component: LoginComponent, canActivate:[guestGuard] },
    { path: "register", component: RegisterComponent, canActivate:[guestGuard] },
    { path: 'not-found', component: NotfoundComponent },
    { path: 'personal-area', component: PersonalAreaComponent, canActivate:[authGuard] },
    { path: 'booking', component: BookingComponent, canActivate:[authGuard] },
    { path: "", component: HomeComponent },
    { path: '**', redirectTo: 'not-found' },
];