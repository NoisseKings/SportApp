import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from './components/login/login.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { AccountComponent } from './account.component';
import { ForgotPasswordComponent } from './components/forgot-password/forgot-password.component';
import { JwtModule } from '@auth0/angular-jwt';
import { AuthGuard } from '../../core/guards/auth.guard';

export function getToken() {
  return localStorage.getItem("atk");
}
const accountRoutes: Routes = [
  {
    path: 'auth', component: AccountComponent, children: [
      { path: 'login', component: LoginComponent},
      { path: 'registration', component: RegistrationComponent },
      { path: 'forgotPassword', component: ForgotPasswordComponent }
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(accountRoutes),
    JwtModule.forRoot({
      config: {
        tokenGetter: getToken,
      }
    })
  ],
  providers: [AuthGuard],
  exports: [RouterModule]
})
export class AccountRoutingModule { }
