import { Account } from "../account/account";

export class Customer {
  public id: number;
  public firstName: string;
  public lastName: string;
  public username: string;
  public phoneNumber: string;
  public birthday: Date;
  public createAt: Date;
  public modifyAt: Date;
  public rememberMe: boolean;
  public tearmsAndContidions: boolean;

  public accountId: number;
  public account: Account = new Account();

  constructor() { }
}
