import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ToyNavbarComponent } from './toy-navbar.component';

describe('ToyNavbarComponent', () => {
  let component: ToyNavbarComponent;
  let fixture: ComponentFixture<ToyNavbarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ToyNavbarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ToyNavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
