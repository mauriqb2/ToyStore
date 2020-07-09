import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ToyStoreComponent } from './toy-store.component';

describe('ToyStoreComponent', () => {
  let component: ToyStoreComponent;
  let fixture: ComponentFixture<ToyStoreComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ToyStoreComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ToyStoreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
