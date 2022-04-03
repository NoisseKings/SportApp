import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { RepositoryService } from '../../../../share/services/repository.service';
import { AccountViewModel } from '../../models/account-view-model';
import { DashboardService } from '../../services/dashboard-service';

@Component({
  selector: 'app-header-user',
  templateUrl: './header-user.component.html',
  styleUrls: ['./header-user.component.css']
})
export class HeaderUserComponent implements OnInit {

  public accountVM: AccountViewModel;
  private _dashboardService: DashboardService;
  public switchUrl: any;
  public isVisible: boolean = false;
  public courtCustomer: number;

  constructor(public router: Router, private _repository: RepositoryService, private actRoute: ActivatedRoute) {}

  async ngOnInit() {
    this._dashboardService = new DashboardService(this.router, this._repository);
    this.switchUrl = this.router.url.search('courtView');
    const courtId = this.actRoute.snapshot.params.courtId;

    const _localStorageToken = localStorage.getItem("atk");
    const _sessionStorageToken = sessionStorage.getItem("atk");
    const _localStorageTokenCourt = localStorage.getItem("atkC");
    const _sessionStorageTokenCourt = sessionStorage.getItem("atkC");

    if (this.switchUrl != -1) {
      this.accountVM = await this._dashboardService.GetCourtById(courtId);
    } else {
      if (_localStorageTokenCourt != "" || _sessionStorageTokenCourt != "") {
        if (_sessionStorageTokenCourt != "") {
          this.accountVM = await this._dashboardService.GetCourtValueByToken(_sessionStorageTokenCourt);
          this.courtCustomer = 1;
        } else {
          this.accountVM = await this._dashboardService.GetCourtValueByToken(_localStorageTokenCourt);
          this.courtCustomer = 1;
        }
      } else {
        this.accountVM = await this._dashboardService.GetCustomerValuesByToken(_localStorageToken);
        this.courtCustomer = 2;
      }

    }
  }
  openReservationPanel() {
    this.isVisible = true;
  }

}
