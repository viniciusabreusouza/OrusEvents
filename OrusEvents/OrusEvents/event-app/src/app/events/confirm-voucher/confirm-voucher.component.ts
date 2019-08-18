import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { GetRegisterInfoResponse } from 'src/app/models/events/get-register-info-response.model';
import { ActivatedRoute, Router } from '@angular/router';
import { EventsService } from 'src/app/services/event-control/events.service';
import { RegisterConfirmationResponse } from 'src/app/models/events/register-confirmation-response.model';
import { debug } from 'util';

@Component({
  selector: 'app-confirm-voucher',
  templateUrl: './confirm-voucher.component.html',
  styleUrls: ['./confirm-voucher.component.scss']
})
export class ConfirmVoucherComponent implements OnInit {

  registerConfirmation: Subscription;
  getRegisterInfo: Subscription;
  registerId: string;
  registerModel: GetRegisterInfoResponse;
  confirmEvent = false;
  message: string;

  constructor(private router: Router,
              private route: ActivatedRoute,
              private eventService: EventsService) { }

  ngOnInit() {
    debugger
    this.registerId = this.route.snapshot.params.registerId;

    this.getRegisterDetails(this.registerId);
  }

  getRegisterDetails(registerId: string) {
    if (registerId) {
      this.getRegisterInfo = this.eventService.GetRegisterInfo(this.registerId).subscribe(
        (data: GetRegisterInfoResponse) => {
          if (data != null && data.Success) {

            this.registerModel = data;

          } else if (data != null && !data.Success) {
            console.log(data.Message);
          }
        },
        (error) => {
          console.log('erro' + error);
        });
    }
  }

  confirmPresence(): void {
    this.registerConfirmation = this.eventService.RegisterConfirmationInEvent(this.registerId).subscribe(
      (data: RegisterConfirmationResponse) => {
        if (data != null && data.Success) {

          if (data.Confirmation) {
            this.message = 'Usuário confirmado com sucesso!';
          }
        }
      },
      (error) => {
        if (error.status === 409 || error.status === 204) {
          this.message = error.error.Message;
        } else {
          this.message = error;
          console.log('erro' + error);
        }
      });
  }
}
