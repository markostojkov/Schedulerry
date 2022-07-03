import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddServiceOptionScheduleDialogComponent } from './add-service-option-schedule-dialog.component';

describe('AddServiceOptionScheduleDialogComponent', () => {
  let component: AddServiceOptionScheduleDialogComponent;
  let fixture: ComponentFixture<AddServiceOptionScheduleDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddServiceOptionScheduleDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddServiceOptionScheduleDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
