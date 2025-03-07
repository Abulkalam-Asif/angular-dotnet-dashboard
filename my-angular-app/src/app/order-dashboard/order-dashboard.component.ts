import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { OrderService } from '../services/order.service'; // Import LedgerService

@Component({
  selector: 'app-order-dashboard',
  standalone: true,
  imports: [CommonModule, RouterModule, MatIconModule],
  templateUrl: './order-dashboard.component.html',
  styleUrls: ['./order-dashboard.component.css'],
})
export class OrderDashboardComponent implements OnInit {
  orders: any[] = []; // Define orders array

  constructor(private orderService: OrderService) {}

  ngOnInit(): void {
    this.fetchOrders();
  }

  fetchOrders(): void {
    this.orderService.getOrders().subscribe((data: any[]) => {
      this.orders = data;
    });
  }

  deleteOrder(id: number): void {
    this.orderService
      .deleteOrder(id)
      .subscribe(() => {
        this.orders = this.orders.filter((order) => order.id !== id);
      })
      .add(() => {
        this.fetchOrders();
      });
  }
}
