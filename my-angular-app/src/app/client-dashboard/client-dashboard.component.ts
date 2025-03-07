import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { ClientService } from '../services/client.service'; // Import ClientService

@Component({
  selector: 'app-client-dashboard',
  standalone: true,
  imports: [CommonModule, RouterModule, MatIconModule],
  templateUrl: './client-dashboard.component.html',
  styleUrls: ['./client-dashboard.component.css'],
})
export class ClientDashboardComponent implements OnInit {
  clients: any[] = []; // Define clients array

  constructor(private clientService: ClientService) {}

  ngOnInit(): void {
    this.fetchClients();
  }

  fetchClients(): void {
    this.clientService.getClients().subscribe((data: any[]) => {
      this.clients = data;
    });
  }

  deleteClient(id: number): void {
    this.clientService
      .deleteClient(id)
      .subscribe(() => {
        this.clients = this.clients.filter((client) => client.id !== id);
      })
      .add(() => {
        this.fetchClients();
      });
  }
}
