import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Court } from '../../../../core/entity/court/court';
import { Customer } from '../../../../core/entity/customer/customer';
import { RepositoryService } from '../../../../share/services/repository.service';
import { AccountService } from '../../services/account-service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public customer: Customer;
  public court: Court;
  private _accountService: AccountService;

  constructor(public router: Router, private repo: RepositoryService) {
    const _localStorageToken = localStorage.getItem("atk");
    const _sessionStorageToken = sessionStorage.getItem("atk");

    if (_localStorageToken || _sessionStorageToken) {
      this.router.navigate(['dashboard/home'])
    }
    //this.court.account.email
    this._accountService = new AccountService(this.router,this.repo);

  }

  ngOnInit() {
    this.customer = new Customer();
    this.court = new Court();
  }

  onClickSubmit() {
    this._accountService.Login(this.customer);
  }
  onClickSubmitCourt() {
    this._accountService.LoginCourt(this.court);
  }
}
