import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TimestampDisplayComponent } from './timestamp-display.component';

describe('TimestampDisplayComponent', () => {
  let component: TimestampDisplayComponent;
  let fixture: ComponentFixture<TimestampDisplayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TimestampDisplayComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TimestampDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
