import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard.component';
import { HomeDashboardComponent } from './pages/home-dashboard/home-dashboard.component';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { SidenavComponent } from './components/sidenav/sidenav.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { HeaderUserComponent } from './components/header-user/header-user.component';
import { ProfileInformationComponent } from './components/profile-information/profile-information.component';
import { ChatComponent } from './components/chat/chat.component';
import { LastMinuteDealsComponent } from './components/last-minute-deals/last-minute-deals.component';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { SettingsComponent } from './pages/settings/settings.component';
import { ScheduleModule, RecurrenceEditorModule, DayService, WeekService, WorkWeekService, MonthService, MonthAgendaService } from '@syncfusion/ej2-angular-schedule';
import { UserCourtViewComponent } from './pages/user-court-view/user-court-view.component';
import { ListOfCourtsComponent } from './components/list-of-courts/list-of-courts.component';
import { ReservationPanelComponent } from './components/reservation-panel/reservation-panel.component';



@NgModule({
  declarations: [
    DashboardComponent,
    HomeDashboardComponent,
    SidenavComponent,
    NavBarComponent,
    HeaderUserComponent,
    ProfileInformationComponent,
    ChatComponent,
    LastMinuteDealsComponent,
    SettingsComponent,
    UserCourtViewComponent,
    ListOfCourtsComponent,
    ReservationPanelComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    FormsModule,
    HttpClientModule,
    DashboardRoutingModule,
    ScheduleModule,
    RecurrenceEditorModule
  ],
  providers: [ DayService, WeekService, WorkWeekService, MonthService, MonthAgendaService ]
})
export class DashboardModule { }
