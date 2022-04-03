import { Component, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard.component';
import { HomeDashboardComponent } from './pages/home-dashboard/home-dashboard.component';
import { JwtModule } from '@auth0/angular-jwt';
import { AuthGuard } from '../../core/guards/auth.guard';


import { SettingsComponent } from './pages/settings/settings.component';
import { UserCourtViewComponent } from './pages/user-court-view/user-court-view.component';

export function getToken() {
  return localStorage.getItem("atk");
}

const dashboardRoutes: Routes = [
  {
    path: 'dashboard', component: DashboardComponent, children: [
      { path: 'home', component: HomeDashboardComponent, canActivate: [AuthGuard] },
      { path: 'settings', component: SettingsComponent },
      { path: 'courtView/:courtId', component: UserCourtViewComponent }
    ]
  },
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(dashboardRoutes),
    JwtModule.forRoot({
      config: {
        tokenGetter: getToken,
      }
    })
  ],
  providers: [AuthGuard],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }
