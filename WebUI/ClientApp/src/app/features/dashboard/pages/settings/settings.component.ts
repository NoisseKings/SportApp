import { Component, OnInit, SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';
import { RepositoryService } from '../../../../share/services/repository.service';
import { AddressViewModel } from '../../../account/model/address-view-model';
import { AccountService } from '../../../account/services/account-service';
import { AccountViewModel } from '../../models/account-view-model';
import { DashboardService } from '../../services/dashboard-service';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.css']
})
export class SettingsComponent implements OnInit {

  public user: any;
  public addressVM: AddressViewModel;
  public accountVM: AccountViewModel;
  private _dashboardService: DashboardService;
  private _accountService: AccountService;

  constructor(public router: Router, private _repository: RepositoryService) { }

  async ngOnInit() {

    this._dashboardService = new DashboardService(this.router, this._repository);
    this._accountService = new AccountService(this.router, this._repository);
    this.addressVM = new AddressViewModel();
    this.accountVM = new AccountViewModel();

    const _localStorageToken = localStorage.getItem("atk");
    const _sessionStorageToken = sessionStorage.getItem("atk");

    debugger;
    this.accountVM = await this._dashboardService.GetCustomerValuesByToken(_localStorageToken);
    //console.log(this.accountVM);

  }

  onClickSubmit() {
    debugger;
    this._accountService.UpdateUserInfo(this.accountVM);
  }

  onChangeInputValue() {

  }

  ngOnChanges(changes: SimpleChanges) {
    console.log(changes)
  }

}
