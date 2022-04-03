import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Reservation } from '../../../../core/entity/reservation/reservation';
import { RepositoryService } from '../../../../share/services/repository.service';
import { DashboardService } from '../../services/dashboard-service';

@Component({
  selector: 'app-reservation-panel',
  templateUrl: './reservation-panel.component.html',
  styleUrls: ['./reservation-panel.component.css']
})
export class ReservationPanelComponent implements OnInit {
  private _dashboardService: DashboardService;
  public reservation: Reservation = new Reservation();
  public periodFree: number = 0;
  public periodCreate: number = 0;


  constructor(private _repository: RepositoryService, public router: Router, private actRoute: ActivatedRoute) { }

  ngOnInit() {

  }

  async createReservation() {
    this.periodFree = 0;

    const courtId = this.actRoute.snapshot.params.courtId;
    this.reservation.courtId = courtId;

    this._dashboardService = new DashboardService(this.router, this._repository);
    const result = await this._dashboardService.CheckIfPeriodIsFree(this.reservation);
    if (result) {
      this._dashboardService = new DashboardService(this.router, this._repository);
      const resultCreateReservation = await this._dashboardService.CreateReservation(this.reservation);
      if (resultCreateReservation) {
        this.periodCreate = 1;
      } else {
        this.periodCreate = 2;
      }
    } else {
      this.periodFree = 2;
    }
  }
  changeIsOpen(e) {
    this.reservation.isOpen = e.target.value;
  }
  async CheckIfPeriodIsFree(e) {
    const courtId = this.actRoute.snapshot.params.courtId;
    this.reservation.endDate = e.target.value;
    this._dashboardService = new DashboardService(this.router, this._repository);
    const result = await this._dashboardService.CheckIfPeriodIsFree(this.reservation);
    if (result) {
      this.periodFree = 1;
    } else {
      this.periodFree = 2;
    }
  }
}
