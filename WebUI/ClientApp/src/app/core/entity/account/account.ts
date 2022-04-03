import { Token } from "../token/token";

export class Account {
  public id: number;
  public email: string;
  public password: string;
  public createAt: Date;
  public modiftAt: Date;

  public tokenId: number;
  public token: Token = new Token();

  constructor() { }
}
