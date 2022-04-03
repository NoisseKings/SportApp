import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Court } from '../../../../core/entity/court/court';
import { Customer } from '../../../../core/entity/customer/customer';
import { RepositoryService } from '../../../../share/services/repository.service';
import { AccountService } from '../../services/account-service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  public customer: Customer;
  public court: Court;
  private _accountService: AccountService;

  constructor(private router: Router, private repo: RepositoryService) {
    this.customer = new Customer();
    this.court = new Court();
    this._accountService = new AccountService(this.router, this.repo);
  }

  ngOnInit() {
  }

  onClickSubmit() {
    this._accountService.Registration(this.customer);
  }
  onClickSubmitCourt() {
    this._accountService.RegistrationCourt(this.court);
  }
}
