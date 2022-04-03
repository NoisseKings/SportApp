import { HttpClient, HttpParams } from "@angular/common/http";
import { Router } from "@angular/router";
import { Court } from "../../../core/entity/court/court";
import { Customer } from "../../../core/entity/customer/customer";
import { RepositoryService } from "../../../share/services/repository.service";
import { AccountViewModel } from "../../dashboard/models/account-view-model";

export class AccountService {
  public customer: Customer;

  constructor(
    public router: Router,
    private repo: RepositoryService
  ) { }

  Login(customer: Customer) {
    const userParameters = new HttpParams().set(
      "UserName", customer.username
    ).set(
      "Password", customer.account.password
    );
    try {
      this.repo.getData('api/Account/LoginCustomer', userParameters)
        .subscribe(res => {
          console.log(res);
          if (customer.rememberMe) {
            const token = (<any>res).token;
            localStorage.setItem("atk", token);
            this.router.navigate(["/dashboard/home"])
          } else {
            const token = (<any>res).token;
            sessionStorage.setItem("atk", token);
            this.router.navigate(["/dashboard/home"])
          }
        },
          (error) => {
            console.log(error);
            //this.handleErrors(error);
          });

    } catch (e) {
      console.log(e);
    }
  }
  LoginCourt(court: Court) {
    const userParameters = new HttpParams().set(
      "Email", court.account.email
    ).set(
      "Password", court.account.password
    );
    try {
      this.repo.getData('api/Account/LoginCourt', userParameters)
        .subscribe(res => {
          console.log(res);
          if (court.rememberMe) {
            const token = (<any>res).token;
            localStorage.setItem("atkC", token);
            this.router.navigate(["/dashboard/home"])
          } else {
            const token = (<any>res).token;
            sessionStorage.setItem("atkC", token);
            this.router.navigate(["/dashboard/home"])
          }
        },
          (error) => {
            console.log(error);
            //this.handleErrors(error);
          });

    } catch (e) {
      console.log(e);
    }
  }
  Registration(customer: Customer) {
    const body = JSON.stringify({ "Customer": customer });
    debugger;
    this.repo.create('api/Account/CreateUserCommand', body).subscribe((data:any) => {
      var token = data.customer.account.token.title;
      sessionStorage.setItem("atk", token);
      this.router.navigate(["/dashboard/home"])
    });
  }
  RegistrationCourt(court: Court) {
    const body = JSON.stringify({ "Court": court });
    debugger;
    this.repo.create('api/Account/CreateUserCommand', body).subscribe((data:any) => {
      var token = data.court.account.token.title;
      sessionStorage.setItem("atkC", token);
      this.router.navigate(["/dashboard/home"]);
    });
  }
  async Forgotpassword(user: Customer) {
    const userParameters = new HttpParams().set(
      "Email", this.customer.account.email
    );
    var status = false;
    try {
      await this.repo.getData('api/Account/UserForgotPassword', userParameters).toPromise().then(data => {

        if ((<any>data).checkEmail == true) {
          status = true;
        }
      })
      //.subscribe(res => {
      //  debugger;
      //  //res = {checkEmail: true}
      //  console.log(res);
      //  if ((<any>res).checkEmail == true) {
      //    status = true;
      //  }
      //},
      //  (error) => {
      //    console.log(error);
      //    //this.handleErrors(error);
      //  });

    } catch (e) {
      console.log(e);
    }
    return status;
  }

  UpdateUserInfo(accountVM: AccountViewModel) {
    debugger;

    const body = JSON.stringify({ "Customer": accountVM.customer });
    //const userParameters = new HttpParams().set(
    //  "Id", accountVM.user.id.toString()
    //).set(
    //  "FirstName", accountVM.user.firstName
    //).set(
    //  "LastName", accountVM.user.lastName
    //).set(
    //  "UserName", accountVM.user.userName
    //).set(
    //  "Email", accountVM.user.email
    //).set(
    //  "PhoneNumber", accountVM.user.phoneNumber
    //)
    try {
      this.repo.create('api/Customer/UpdateCustomerInfo', body)
        .subscribe(res => {
          console.log(res);
        },
          (error) => {
            console.log(error);
            //this.handleErrors(error);
          });

    } catch (e) {
      console.log(e);
    }
  }
}
