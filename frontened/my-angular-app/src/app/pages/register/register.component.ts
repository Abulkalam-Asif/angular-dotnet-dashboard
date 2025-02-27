import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms'; // Import FormsModule
import { CommonModule } from '@angular/common';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { CompanyService } from '../../services/company.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule, CommonModule], // Add FormsModule here
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent {
  email = '';
  password = '';
  companyId: number | null = null;
  role = 'CompanyEmployee'; // Default role
  companies: any[] = []; // List of companies
  errorMessage = '';

  constructor(
    private authService: AuthService,
    private companyService: CompanyService,
    private router: Router
  ) {}

  ngOnInit() {
    // Fetch companies for the dropdown
    this.companyService.getCompanies().subscribe({
      next: (data) => {
        this.companies = data;
      },
      error: (error) => {
        console.error('Failed to fetch companies:', error);
      },
    });
  }

  onRegister() {
    if (!this.companyId) {
      this.errorMessage = 'Please select a company.';
      return;
    }

    this.authService
      .register(this.email, this.password, this.companyId, this.role)
      .subscribe({
        next: () => {
          alert('Registration successful!');
          this.router.navigate(['/login']);
        },
        error: (error) => {
          this.errorMessage =
            error.message || 'Registration failed. Please try again.';
        },
      });
  }
}
