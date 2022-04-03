import { Account } from "../account/account";

export class Court {

  public id: number;
  public name: string;
  public workingHours: string;
  public priceForHour: string;
  public phoneNumber: string;
  public dateOfCreation: Date;
  public createAt: Date;
  public modifyAt: Date;
  public rememberMe: boolean;
  public termAndCondition: boolean;

  public accountId: number;
  public account: Account = new Account();

  constructor() { }
}
