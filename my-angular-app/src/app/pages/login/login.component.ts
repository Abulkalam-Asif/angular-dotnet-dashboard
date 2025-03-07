import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common'; // Import CommonModule

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, MatIconModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  email = '';
  password = '';
  errorMessage = '';

  constructor(private authService: AuthService, private router: Router) {}

  onLogin() {
    this.authService.login(this.email, this.password).subscribe({
      next: (response: { token: string; role: string }) => {
        console.log(response);
        localStorage.setItem('token', response.token);
        alert('Login Successful!');

        if (response.role === 'SuperAdmin') {
          this.router.navigate(['/admin-dashboard']); // Redirect to admin dashboard
        } else if (response.role === "CompanyEmployee") {
          this.router.navigate(['/client-dashboard']); // Redirect to employee dashboard
        } else {
          this.router.navigate(['/dashboard']); // Default dashboard
        }
      },
      error: () => {
        this.errorMessage = 'Invalid email or password';
      },
    });
  }
}