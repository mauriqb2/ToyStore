import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ToyCategoryComponent } from './toy-category.component';

describe('ToyCategoryComponent', () => {
  let component: ToyCategoryComponent;
  let fixture: ComponentFixture<ToyCategoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ToyCategoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ToyCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
