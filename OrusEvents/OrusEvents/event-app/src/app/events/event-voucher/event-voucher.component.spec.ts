import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EventVoucherComponent } from './event-voucher.component';

describe('EventVoucherComponent', () => {
  let component: EventVoucherComponent;
  let fixture: ComponentFixture<EventVoucherComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EventVoucherComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EventVoucherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
