import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Court } from '../../../../core/entity/court/court';

@Component({
  selector: 'app-last-minute-deals',
  templateUrl: './last-minute-deals.component.html',
  styleUrls: ['./last-minute-deals.component.css']
})
export class LastMinuteDealsComponent implements OnInit {

  public deals: any[];

  constructor(private http: HttpClient) {

    this.getlastMinutesDeals();

  }

  ngOnInit() {
  }

  getlastMinutesDeals() {
    console.log("Deals !!!");
    this.http.get<Court>('api/Dashboard/GetLastMinutesDeals').subscribe((data: any) => {
      debugger;
      this.deals = data;

    });

  }

}
