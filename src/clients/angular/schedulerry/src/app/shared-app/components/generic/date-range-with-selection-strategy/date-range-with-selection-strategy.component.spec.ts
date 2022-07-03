import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DateRangeWithSelectionStrategyComponent } from './date-range-with-selection-strategy.component';

describe('DateRangeWithSelectionStrategyComponent', () => {
  let component: DateRangeWithSelectionStrategyComponent;
  let fixture: ComponentFixture<DateRangeWithSelectionStrategyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DateRangeWithSelectionStrategyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DateRangeWithSelectionStrategyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
