import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Court } from '../../../../core/entity/court/court';

@Component({
  selector: 'app-list-of-courts',
  templateUrl: './list-of-courts.component.html',
  styleUrls: ['./list-of-courts.component.css']
})
export class ListOfCourtsComponent implements OnInit {

  public deals: any[];

  constructor(private http: HttpClient) {

    this.getListOfCourts();

  }

  ngOnInit() {
  }

  getListOfCourts() {
    console.log("List !!!");
    this.http.get<Court>('api/Dashboard/GetListOfCourts').subscribe((data: any) => {
      debugger;
      this.deals = data.$values;
    });
  }
}
