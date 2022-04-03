import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RepositoryService } from '../../../../share/services/repository.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit {
  public switchUrl: any;
  constructor(public router: Router, private _repository: RepositoryService, private actRoute: ActivatedRoute) { }

  async ngOnInit() {
    debugger;
    this.switchUrl = this.router.url.search('courtView');
    const courtId = this.actRoute.snapshot.params.courtId;
  }

}
