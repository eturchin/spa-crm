import { CanActivateFn, Router } from '@angular/router';
import { constants } from '../constants/constants';
import { inject } from '@angular/core';

export const authGuard: CanActivateFn = (route, state) => {
  const router = inject(Router);
  const accessToken = localStorage.getItem(constants.ACCESS_TOKNE); 
  
  if (accessToken != null)
  {
      return true;
  } 
  else
  {
    router.navigateByUrl('/login');
    return false;
  }
};
