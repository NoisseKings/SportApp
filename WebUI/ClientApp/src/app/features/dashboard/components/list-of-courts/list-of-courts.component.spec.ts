import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListOfCourtsComponent } from './list-of-courts.component';

describe('ListOfCourtsComponent', () => {
  let component: ListOfCourtsComponent;
  let fixture: ComponentFixture<ListOfCourtsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListOfCourtsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListOfCourtsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
