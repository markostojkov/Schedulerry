import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AnonymousMainViewComponent } from './anonymous-main-view.component';

describe('AnonymousMainViewComponent', () => {
  let component: AnonymousMainViewComponent;
  let fixture: ComponentFixture<AnonymousMainViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AnonymousMainViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AnonymousMainViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
