import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';

import { AppRoutingModule } from './app-routing.module';
import { AccountModule } from './features/account/account.module';
import { DashboardModule } from './features/dashboard/dashboard.module';
import { AsyncClickDirective } from './share/directives/async-click/async-click';
import { SpinnerComponent } from './share/components/spinner/spinner.component';


@NgModule({
  declarations: [
    AppComponent,
    AsyncClickDirective,
    SpinnerComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AccountModule,
    DashboardModule,
    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
