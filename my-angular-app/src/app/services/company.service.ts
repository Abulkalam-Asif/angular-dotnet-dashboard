import { Injectable } from '@angular/core';
import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CompanyService {
  private apiUrl = 'http://localhost:5253/api';

  constructor(private http: HttpClient) {}

  // Add Company API call
  addCompany(company: any): Observable<any> {
    const token = localStorage.getItem('token'); // Get the JWT token from localStorage
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`); // Add the token to the headers

    return this.http
      .post(`${this.apiUrl}/Company`, company, { headers })
      .pipe(catchError(this.handleError));
  }

  getCompanies(): Observable<any[]> {
    return this.http
      .get<any[]>(`${this.apiUrl}/Company`)
      .pipe(catchError(this.handleError));
  }

  deleteCompany(id: number): Observable<any> {
    const token = localStorage.getItem('token'); // Get the JWT token from localStorage
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`); // Add the token to the headers

    return this.http
      .delete(`${this.apiUrl}/Company/${id}`, { headers, responseType: 'text' })
      .pipe(catchError(this.handleError));
  }

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
