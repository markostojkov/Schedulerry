import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VerifyOrganizerComponent } from './verify-organizer.component';

describe('VerifyOrganizerComponent', () => {
  let component: VerifyOrganizerComponent;
  let fixture: ComponentFixture<VerifyOrganizerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VerifyOrganizerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VerifyOrganizerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
