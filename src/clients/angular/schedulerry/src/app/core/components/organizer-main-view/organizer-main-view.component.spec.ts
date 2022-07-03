import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrganizerMainViewComponent } from './organizer-main-view.component';

describe('OrganizerMainViewComponent', () => {
  let component: OrganizerMainViewComponent;
  let fixture: ComponentFixture<OrganizerMainViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrganizerMainViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrganizerMainViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
