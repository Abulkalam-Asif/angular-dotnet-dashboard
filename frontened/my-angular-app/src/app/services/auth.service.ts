import { Injectable } from '@angular/core';
import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root', // This ensures the service is provided at the root level
})
export class AuthService {
  private apiUrl = 'http://localhost:5253/api'; // Replace with your actual API URL

  constructor(private http: HttpClient) {}

  // Login API call
  login(email: string, password: string): Observable<any> {
    return this.http
      .post(`${this.apiUrl}/Auth/login`, { email, password })
      .pipe(catchError(this.handleError));
  }

  // Register API call
  register(
    email: string,
    password: string,
    companyId: number,
    role?: string
  ): Observable<any> {
    return this.http
      .post(`${this.apiUrl}/Auth/register`, {
        email,
        password,
        companyId,
        role,
      })
      .pipe(catchError(this.handleError));
  }

  // Add Client API call
  addClient(client: any): Observable<any> {
    const token = localStorage.getItem('token'); // Get the JWT token from localStorage
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`); // Add the token to the headers
    console.log(client, `${this.apiUrl}/Client`, headers);
    return this.http
      .post(`${this.apiUrl}/Client`, client, { headers })
      .pipe(catchError(this.handleError));
  }

  // Fetch Companies API call

  // Handle HTTP errors
  private handleError(error: HttpErrorResponse) {
    let errorMessage = 'An unknown error occurred!';
    if (error.error instanceof ErrorEvent) {
      // Client-side error
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // Server-side error
      errorMessage = error.error.message || error.message;
    }
    console.error(errorMessage);
    return throwError(() => new Error(errorMessage));
  }
}
