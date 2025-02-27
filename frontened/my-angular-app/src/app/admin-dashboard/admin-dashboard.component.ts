import { Component, OnInit } from '@angular/core';
import { CompanyService } from '../services/company.service';
import { Router } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-admin-dashboard',
  standalone: true,
  imports: [
    CommonModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    FormsModule,
  ],
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css'],
})
export class AdminDashboardComponent implements OnInit {
  companies: any[] = []; // List of companies
  displayedColumns: string[] = ['name', 'profit']; // Columns for the table
  newCompany: any = { name: '', profit: 0 }; // New company data

  constructor(private companyService: CompanyService, private router: Router) {}

  ngOnInit() {
    this.fetchCompanies();
  }

  fetchCompanies() {
    this.companyService.getCompanies().subscribe({
      next: (data: any[]) => {
        this.companies = data;
      },
      error: (error: any) => {
        console.error('Failed to fetch companies:', error);
      },
    });
  }

  onAddCompany() {
    this.companyService.addCompany(this.newCompany).subscribe({
      next: () => {
        alert('Company added successfully!');
        this.fetchCompanies(); // Refresh the list of companies
        this.newCompany = { name: '', profit: 0 }; // Reset the form
      },
      error: (error: any) => {
        console.error('Failed to add company:', error);
        alert('Failed to add company. Please try again.');
      },
    });
  }

  deleteCompany(id: number) {
    this.companyService.deleteCompany(id).subscribe({
      next: () => {
        this.companies = this.companies.filter((company) => company.id !== id);
        alert('Company deleted successfully!');
      },
      error: (error: any) => {
        console.error('Failed to delete company:', error);
        alert('Failed to delete company. Please try again.');
      },
    });
  }

  openAddCompanyForm() {
    this.router.navigate(['/add-company']); // Redirect to the add company form
  }
}
