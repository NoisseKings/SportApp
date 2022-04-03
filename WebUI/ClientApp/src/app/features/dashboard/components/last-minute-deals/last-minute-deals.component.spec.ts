import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LastMinuteDealsComponent } from './last-minute-deals.component';

describe('LastMinuteDealsComponent', () => {
  let component: LastMinuteDealsComponent;
  let fixture: ComponentFixture<LastMinuteDealsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LastMinuteDealsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LastMinuteDealsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
