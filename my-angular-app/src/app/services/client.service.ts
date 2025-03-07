import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ClientService {
  private apiUrl = 'http://localhost:5253/api';

  constructor(private http: HttpClient) {}

  getLedgers(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/Company`);
  }

  getClients(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/Client`);
  }

  deleteClient(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/Client/${id}`);
  }
}
