import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AppLayoutComponent } from './layout/layout.component';
import { AppRoutingModule } from './app-routing.module';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { AddCompanyComponent } from './add-company/add-company.component';
import { ClientDashboardComponent } from './client-dashboard/client-dashboard.component';
import { AddClientComponent } from './add-client/add-client.component';
import { OrderDashboardComponent } from './order-dashboard/order-dashboard.component';
import { AddOrderComponent } from './add-order/add-order.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { AppSidebarComponent } from './sidebar/sidebar.component';

@NgModule({
  declarations: [
    AppComponent,
    AppLayoutComponent,
    AdminDashboardComponent,
    AddCompanyComponent,
    ClientDashboardComponent,
    AddClientComponent,
    OrderDashboardComponent,
    AddOrderComponent,
    LoginComponent,
    RegisterComponent,
    AppSidebarComponent,
  ],
  imports: [BrowserModule, RouterModule, AppRoutingModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
