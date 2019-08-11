import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfirmVoucherComponent } from './confirm-voucher.component';

describe('ConfirmVoucherComponent', () => {
  let component: ConfirmVoucherComponent;
  let fixture: ComponentFixture<ConfirmVoucherComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConfirmVoucherComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfirmVoucherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
