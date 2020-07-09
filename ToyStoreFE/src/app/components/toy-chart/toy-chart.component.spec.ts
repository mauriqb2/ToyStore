import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ToyChartComponent } from './toy-chart.component';

describe('ToyChartComponent', () => {
  let component: ToyChartComponent;
  let fixture: ComponentFixture<ToyChartComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ToyChartComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ToyChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
