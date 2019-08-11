import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { AppLayoutComponent } from './layouts/app-layout/app-layout.component';
import { HomeGuard } from './services/guards/home.guard';
import { HomeComponent } from './home/home.component';
import { EventVoucherComponent } from './events/event-voucher/event-voucher.component';


const routes: Routes = [
  { path: 'login', component: LoginComponent },
  {
    path: '',
    component: AppLayoutComponent,
    children: [
      { path: '', redirectTo: 'home', pathMatch: 'full', canActivate: [HomeGuard] },
      { path: 'home', component: HomeComponent, canActivate: [HomeGuard] },
      { path: 'voucher/:id/:email', component: EventVoucherComponent, canActivate: [HomeGuard] },
      { path: 'voucher', component: EventVoucherComponent, canActivate: [HomeGuard] },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
