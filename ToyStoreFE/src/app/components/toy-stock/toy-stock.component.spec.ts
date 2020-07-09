import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ToyStockComponent } from './toy-stock.component';

describe('ToyStockComponent', () => {
  let component: ToyStockComponent;
  let fixture: ComponentFixture<ToyStockComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ToyStockComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ToyStockComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
