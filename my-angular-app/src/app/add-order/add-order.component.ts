import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { OrderService } from '../services/order.service';
import { ClientService } from '../services/client.service';

@Component({
  selector: 'app-add-order',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './add-order.component.html',
  styleUrls: ['./add-order.component.css'],
})
export class AddOrderComponent implements OnInit {
  newOrder: any = {
    ClientOrderNo: '',
    ClientId: null,
    OrderDate: '',
    ReleaseDate: '',
    StartDate: '',
    EndDate: '',
    Remarks: '',
    Status: '',
    InvoicingTerms: '',
    ContactName: '',
    ContactNo: '',
    ContactEmail: '',
    ContactFaxNo: '',
    OtherRemarks: '',
  };

  clients: any[] = [];

  constructor(
    private orderService: OrderService,
    private router: Router,
    private clientService: ClientService
  ) {}

  ngOnInit() {
    this.fetchClients();
  }

  fetchClients() {
    this.clientService.getClients().subscribe({
      next: (data) => {
        this.clients = data;
        console.log(data);
      },
      error: (error) => {
        console.error('Failed to fetch clients:', error);
      },
    });
  }

  // Submit the form
  onSubmit() {
    // Call the API to add the order
    this.orderService.addOrder(this.newOrder).subscribe({
      next: () => {
        alert('Order added successfully!');
        this.router.navigate(['/order-dashboard']); // Redirect to order dashboard
      },
      error: (error) => {
        console.error('Failed to add order:', error); // Log the error
        alert('Failed to add order. Please try again.');
      },
    });
  }

  // Cancel and go back to the admin dashboard
  onCancel() {
    this.router.navigate(['/admin-dashboard']);
  }
}
