import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AcceptInvitationOrganizerComponent } from './accept-invitation-organizer.component';

describe('AcceptInvitationOrganizerComponent', () => {
  let component: AcceptInvitationOrganizerComponent;
  let fixture: ComponentFixture<AcceptInvitationOrganizerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AcceptInvitationOrganizerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AcceptInvitationOrganizerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
