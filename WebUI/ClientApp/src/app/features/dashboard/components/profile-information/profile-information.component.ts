import { Component, DoCheck, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RepositoryService } from '../../../../share/services/repository.service';
import { AccountViewModel } from '../../models/account-view-model';
import { DashboardService } from '../../services/dashboard-service';

@Component({
  selector: 'app-profile-information',
  templateUrl: './profile-information.component.html',
  styleUrls: ['./profile-information.component.css']
})
export class ProfileInformationComponent implements OnInit {

  public accountVM: AccountViewModel;
  private _dashboardService: DashboardService;
  public switchUrl: any;
  public courtCustomer: number;
  constructor(public router: Router, private _repository: RepositoryService, private actRoute: ActivatedRoute) {
    debugger;
    this.switchUrl = this.router.url.search('courtView');
  }

  async ngOnInit() {
    this._dashboardService = new DashboardService(this.router, this._repository);
    this.accountVM = new AccountViewModel();

    const params = new URLSearchParams(window.location.search);
    const _localStorageToken = localStorage.getItem("atk");
    const _sessionStorageToken = sessionStorage.getItem("atk");
    const _localStorageTokenCourt = localStorage.getItem("atkC");
    const _sessionStorageTokenCourt = sessionStorage.getItem("atkC");

    const courtId = this.actRoute.snapshot.params.courtId;

    debugger;
    if (this.switchUrl != -1) {
      this.accountVM = await this._dashboardService.GetCourtById(courtId);
    } else {
      if (_localStorageTokenCourt != "") {
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
    //console.log(this.accountVM);
  }
  ngOnChanges(changes: SimpleChanges) {
    console.log(changes)
  }
}
