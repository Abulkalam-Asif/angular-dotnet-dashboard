import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { AddCompanyComponent } from './add-company/add-company.component';
import { ClientDashboardComponent } from './client-dashboard/client-dashboard.component';
import { AddClientComponent } from './add-client/add-client.component';
import { OrderDashboardComponent } from './order-dashboard/order-dashboard.component';
import { AddOrderComponent } from './add-order/add-order.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'admin-dashboard', component: AdminDashboardComponent },
  { path: 'add-company', component: AddCompanyComponent },
  { path: 'client-dashboard', component: ClientDashboardComponent },
  { path: 'add-client', component: AddClientComponent },
  { path: 'order-dashboard', component: OrderDashboardComponent },
  { path: 'add-order', component: AddOrderComponent },
  { path: '**', redirectTo: '/login' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
