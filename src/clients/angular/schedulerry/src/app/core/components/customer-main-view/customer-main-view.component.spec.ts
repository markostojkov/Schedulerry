import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerMainViewComponent } from './customer-main-view.component';

describe('CustomerMainViewComponent', () => {
  let component: CustomerMainViewComponent;
  let fixture: ComponentFixture<CustomerMainViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustomerMainViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CustomerMainViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
