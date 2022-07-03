import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PreviewOrganizationComponent } from './preview-organization.component';

describe('PreviewOrganizationComponent', () => {
  let component: PreviewOrganizationComponent;
  let fixture: ComponentFixture<PreviewOrganizationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PreviewOrganizationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PreviewOrganizationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
