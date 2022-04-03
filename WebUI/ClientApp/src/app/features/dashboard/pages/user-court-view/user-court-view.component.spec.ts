import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserCourtViewComponent } from './user-court-view.component';

describe('UserCourtViewComponent', () => {
  let component: UserCourtViewComponent;
  let fixture: ComponentFixture<UserCourtViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserCourtViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserCourtViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
