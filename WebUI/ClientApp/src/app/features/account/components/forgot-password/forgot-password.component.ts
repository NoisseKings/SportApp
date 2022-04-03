import { HttpClient, HttpParams } from '@angular/common/http';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, HostListener, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { async, Observable } from 'rxjs';
import { Customer } from '../../../../core/entity/customer/customer';
import { RepositoryService } from '../../../../share/services/repository.service';
import { AccountService } from '../../services/account-service';

@Component({
  selector: 'app-forgot-password',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent implements OnInit {

  public customer: Customer;
  private accountService: AccountService;
  public observable: Observable<any>;
  public status: boolean = false
  public showError: boolean = false;
  code = '';

  constructor(private http: HttpClient, private router: Router,
    private repo: RepositoryService) {


  }

  ngOnInit() {

    this.customer = new Customer();
    this.accountService = new AccountService(this.router, this.repo);

  }
  onClickSubmit() {
    debugger;
    var checkEmail = this.accountService.Forgotpassword(this.customer)

    if (checkEmail) {

      this.status = true;

    } else {

      this.showError = true;

    }
  }
  onSubmitCode() {
    if (this.code == '123') {

      alert('OK');

    }
  }

}
