import { HttpInterceptorFn } from '@angular/common/http';
import { SpinnerloadingService } from '../../shared/services/spinnerloading.service';
import { inject } from '@angular/core';
import { catchError, finalize, throwError } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

// Define the Auth Interceptor as an HttpInterceptorFn
export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const spinnerloadingService = inject(SpinnerloadingService); // Inject SpinnerloadingService
  const toastr = inject(ToastrService); // Inject ToastrService

  const token = localStorage.getItem('token') ?? ''; // Retrieve the token from Local Storage or any other source

  spinnerloadingService.show(); // Show spinner

  if (token || true) {

    // Clone the request and add the Authorization header with the token
    //const clonedRequest = req.clone({
    //  setHeaders: {
    //    Authorization: `Bearer ${token}`, // Add the Bearer token to the request headers
    //  },
    //});
    const clonedRequest = req.clone();

    return next(clonedRequest).pipe(
      finalize(() => spinnerloadingService.hide()), // Hide spinner when the request completes (success or failure)
      catchError((error) => {
        debugger
        // Show an error notification
        toastr.error(error.error || 'An error occurred while processing the request')
        return throwError(() => error);
      })
    );
  }

  return next(req).pipe(
    finalize(() => spinnerloadingService.hide()) // Ensure the spinner is hidden if there's no token or request fails
  );
};
