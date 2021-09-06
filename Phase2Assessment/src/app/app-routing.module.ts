import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AdminLoginComponent } from './admin-login/admin-login.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { OrderSummaryComponent } from './order-summary/order-summary.component';
import { PaymentComponent } from './payment/payment.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  },
  {
    path: 'login',
    component:LoginComponent,
    pathMatch: 'full'
  },
  {
    path: 'home',
    component:HomeComponent,
    pathMatch:'full'
  },
  {
    path: 'payment',
    component:PaymentComponent,
    pathMatch:'full'
  },
  {
    path: 'register',
    component:RegisterComponent,
    pathMatch: 'full'
  },
  {
    path: 'order',
    component:OrderSummaryComponent,
    pathMatch: 'full'
  },
  {
    path: 'admin-login',
    component:AdminLoginComponent,
    pathMatch: 'full'
  },
  {
    path: 'admin-home',
    component:AdminHomeComponent,
    pathMatch: 'full'
  },
  { path: '**', redirectTo: '/login', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
