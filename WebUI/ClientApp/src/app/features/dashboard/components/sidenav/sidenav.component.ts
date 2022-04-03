import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RepositoryService } from '../../../../share/services/repository.service';
import { DashboardService } from '../../services/dashboard-service';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.css']
})
export class SidenavComponent implements OnInit {
  private _dashboardService: DashboardService;
  public isExist: boolean = false;

  constructor(public router: Router, private _repository: RepositoryService) { }

  async ngOnInit() {
    this._dashboardService = new DashboardService(this.router, this._repository);
    debugger;
    const _localStorageTokenCourt = localStorage.getItem("atkC");
    const _sessionStorageTokenCourt = sessionStorage.getItem("atkC");

    if (_localStorageTokenCourt != "") {
      this.isExist = true;
    } else {
      var session = await this._dashboardService.GetCustomerSession().then((data) => {
        this.isExist = true;
      });
    }
  }

}
