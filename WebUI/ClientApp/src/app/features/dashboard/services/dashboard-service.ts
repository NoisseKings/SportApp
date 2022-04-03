import { HttpParams } from "@angular/common/http";
import { Router } from "@angular/router";
import { Reservation } from "../../../core/entity/reservation/reservation";
import { RepositoryService } from "../../../share/services/repository.service";
import { AccountViewModel } from "../models/account-view-model";

export class DashboardService {
  constructor(
    public router: Router,
    private _repository: RepositoryService
  ) { }

  async GetCustomerValuesByToken(token: string) {
    var res: AccountViewModel;
    try {
      const userParameters = new HttpParams().set(
        "token", token
      );
      await this._repository.getData('api/Customer/LoginCustomer', userParameters).toPromise().then((data: any) => {
        res = data as AccountViewModel;
      });
    } catch (e) {
      console.log(e);
    }
    return res;
  }
  async GetCourtValueByToken(token: string) {
    var res: AccountViewModel;
    try {
      const userParameters = new HttpParams().set(
        "token", token
      );
      await this._repository.getData('api/Court/LoginCourt', userParameters).toPromise().then((data: any) => {
        res = data as AccountViewModel;
      });
    } catch (e) {
      console.log(e);
    }
    return res;
  }
  async GetCourtById(id: string) {
    var res: AccountViewModel;
    try {
      const userParameters = new HttpParams().set(
        "id", id
      );
      await this._repository.getData('api/Dashboard/GetCourtById', userParameters).toPromise().then((data: any) => {
        res = data as AccountViewModel;
      });
    } catch (e) {
      console.log(e);
    }
    return res;
  }
  async CreateReservation(reservation: Reservation) {
    reservation.isOpen
    const body = JSON.stringify({ "Reservation": reservation });

    const result = this._repository.create('api/Dashboard/CreateReservation', body).subscribe((data: Reservation) => {
      return data;
    });

    return result;
  }
  async CheckIfPeriodIsFree(reservation: Reservation) {
    const body = JSON.stringify({ "Reservation": reservation });
     const result = this._repository.create("api/Dashboard/CheckIfPeriodIsFree", body).subscribe((data: Reservation) => {
       return data;
     });

    return result;
  }
  async GetCustomerSession() {
    const session = this._repository.getData('api/Account/GetCustomerSession').subscribe((data: any) => {
      return data
    },
      (error) => {
        console.log(error);
      });
    //await this._repository.getData('api/Account/GetCustomerSession').toPromise().then((data: any) => {
    //  debugger;
    //  session = data;
    //});
    return session;
  }
}
