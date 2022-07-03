import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddOrganizerDialogComponent } from './add-organizer-dialog.component';

describe('AddOrganizerDialogComponent', () => {
  let component: AddOrganizerDialogComponent;
  let fixture: ComponentFixture<AddOrganizerDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddOrganizerDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddOrganizerDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
