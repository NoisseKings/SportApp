import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';

import { AccountRoutingModule } from './account-routing.module';
import { LoginComponent } from './components/login/login.component';
import { AccountComponent } from './account.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { ForgotPasswordComponent } from './components/forgot-password/forgot-password.component';



@NgModule({
  declarations: [LoginComponent, AccountComponent, RegistrationComponent, ForgotPasswordComponent],
  imports: [
    CommonModule,
    RouterModule,
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AccountRoutingModule
    //RouterModule.forRoot([
    //  { path: '', redirectTo: '/login', pathMatch: 'full' },
    //  { path: 'login', component: LoginComponent },
    //  { path: 'registration', component: RegistrationComponent },
    //  //{ path: 'counter', component: CounterComponent },
    //  //{ path: 'fetch-data', component: FetchDataComponent },
    //])
  ]
})
export class AccountModule { }
