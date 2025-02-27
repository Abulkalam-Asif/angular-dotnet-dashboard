import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { CompanyService } from '../services/company.service';

@Component({
  selector: 'app-add-company',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './add-company.component.html',
  styleUrls: ['./add-company.component.css'],
})
export class AddCompanyComponent implements OnInit {
  newCompany: any = {
    Name: '',
    RegDate: '',
    RegNo: '',
    PANNo: '',
    TANNo: '',
    TINNo: '',
    CINNo: '',
    ServiceTaxNo: '',
    ISORemark: '',
    GSTNo: '',
    GSTDate: '',
    LicenseStartDate: '',
    LicenseEndDate: '',
    Address: '',
    AddressHtml: '',
    BranchAddress: '',
    LogoUrl: '',
  };

  constructor(private companyService: CompanyService, private router: Router) {}

  ngOnInit() {}

  // Submit the form
  onSubmit() {
    console.log('Payload being sent:', this.newCompany); // Log the payload

    // Call the API to add the company
    this.companyService.addCompany(this.newCompany).subscribe({
      next: () => {
        alert('Company added successfully!');
        this.router.navigate(['/admin-dashboard']); // Redirect to admin dashboard
      },
      error: (error) => {
        console.error('Failed to add company:', error); // Log the error
        alert('Failed to add company. Please try again.');
      },
    });
  }
}
