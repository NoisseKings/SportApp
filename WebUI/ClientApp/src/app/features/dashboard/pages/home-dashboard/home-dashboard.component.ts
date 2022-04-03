import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home-dashboard',
  templateUrl: './home-dashboard.component.html',
  styleUrls: ['./home-dashboard.component.css']
})
export class HomeDashboardComponent implements OnInit {
  public court: number = 0;
  constructor() { }

  ngOnInit() {
    const _localStorageTokenCourt = localStorage.getItem("atkC");
    const _sessionStorageTokenCourt = sessionStorage.getItem("atkC");
    if (_localStorageTokenCourt || _sessionStorageTokenCourt) {
      this.court = 1;
    }
  }

}
