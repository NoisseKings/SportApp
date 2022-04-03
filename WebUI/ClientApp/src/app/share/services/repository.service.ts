import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
//this is repository level service
@Injectable({
  providedIn: 'root'
})
export class RepositoryService {
  private envUrl: string = "https://localhost:44301";

  constructor(private http: HttpClient) { }

  public getData = (route: string, body?) => {
    return this.http.get(this.createCompleteRoute(route, this.envUrl), { params: body });
  }

  public create = (route: string, body) => {
    return this.http.post(this.createCompleteRoute(route, this.envUrl), body, this.generateHeaders());
  }

  public update = (route: string, body) => {
    return this.http.put(this.createCompleteRoute(route, this.envUrl), body, this.generateHeaders());
  }

  public delete = (route: string) => {
    return this.http.delete(this.createCompleteRoute(route, this.envUrl));
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }

  private generateHeaders = () => {
    return {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
  }
}
