import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddServiceOptionDialogComponent } from './add-service-option-dialog.component';

describe('AddServiceOptionDialogComponent', () => {
  let component: AddServiceOptionDialogComponent;
  let fixture: ComponentFixture<AddServiceOptionDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddServiceOptionDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddServiceOptionDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
