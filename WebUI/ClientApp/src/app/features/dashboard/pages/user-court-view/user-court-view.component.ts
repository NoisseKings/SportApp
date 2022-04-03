import { Component, OnInit, SimpleChanges } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RepositoryService } from '../../../../share/services/repository.service';
import { DashboardService } from '../../services/dashboard-service';

@Component({
  selector: 'app-user-court-view',
  templateUrl: './user-court-view.component.html',
  styleUrls: ['./user-court-view.component.css']
})
export class UserCourtViewComponent implements OnInit {
  private _dashboardService: DashboardService;
  public courtId: string;

  constructor(public router: Router, private _repository: RepositoryService) {
  }

  async ngOnInit() {
    this._dashboardService = new DashboardService(this.router, this._repository);

  }
  ngOnChanges(changes: SimpleChanges) {
    console.log(changes)
  }

}
