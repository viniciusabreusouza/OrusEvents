import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { AppLayoutComponent } from './layouts/app-layout/app-layout.component';
import { LocalStorageService } from './services/local-storage.service';
import { HomeGuard } from './services/guards/home.guard';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { EventVoucherComponent } from './events/event-voucher/event-voucher.component';
import { EventsService } from './services/event-control/events.service';
import { NgxQRCodeModule } from 'ngx-qrcode2';
import { ConfirmVoucherComponent } from './events/confirm-voucher/confirm-voucher.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    AppLayoutComponent,
    HeaderComponent,
    HomeComponent,
    SidebarComponent,
    EventVoucherComponent,
    ConfirmVoucherComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgxQRCodeModule
  ],
  providers: [LocalStorageService, HomeGuard, EventsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
