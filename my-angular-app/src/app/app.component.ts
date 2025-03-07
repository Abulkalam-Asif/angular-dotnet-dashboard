import { Component } from '@angular/core';
import { AppLayoutComponent } from './layout/layout.component';

@Component({
  selector: 'app-root',
  imports: [AppLayoutComponent], // Include AppLayoutComponent
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'], // Corrected property name
})
export class AppComponent {
  title = 'my-angular-app';
}
