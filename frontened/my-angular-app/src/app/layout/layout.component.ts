import { Component } from '@angular/core';
import { AppSidebarComponent } from '../sidebar/sidebar.component';
import { RouterOutlet, Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-layout',
  imports: [RouterOutlet, AppSidebarComponent, CommonModule],
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css'],
})
export class AppLayoutComponent {
  constructor(public router: Router) {}
}
