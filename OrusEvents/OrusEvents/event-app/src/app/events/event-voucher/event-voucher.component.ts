import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';
import { EventsService } from 'src/app/services/event-control/events.service';
import { RegisterUserInEventRequest } from 'src/app/models/events/register-user-event-request.model';
import { RegisterUserInEventResponse } from 'src/app/models/events/register-user-event-response.model';

export class NgxQrCode {
  text: string;
}

@Component({
  selector: 'app-event-voucher',
  templateUrl: './event-voucher.component.html',
  styleUrls: ['./event-voucher.component.scss']
})
export class EventVoucherComponent implements OnInit {

  registerEvent: Subscription;
  eventId: string;
  userEmail: string;
  registerRequest: RegisterUserInEventRequest;
  public urlConfirmation: string = null;

  constructor(private router: Router,
              private route: ActivatedRoute,
              private eventService: EventsService) { }

  ngOnInit() {
    this.eventId = this.route.snapshot.params.id;
    this.userEmail = this.route.snapshot.params.email;

    //this.registerUserInEvent(this.eventId, this.userEmail);
  }

  registerUserInEvent(eventId: string, userEmail: string): void {

    if (eventId && userEmail) {
      this.registerRequest = {
        email: userEmail,
        eventId: eventId
      };

      this.registerEvent = this.eventService.RegisterUserInEvent(this.registerRequest).subscribe(
        (data: RegisterUserInEventResponse) => {
          debugger;
          if (data != null && data.Success) {

            this.urlConfirmation = 'https://localhost:44357/api/Event/RegisterConfirmationInEvent/' + data.IdRegister;

          } else if (data != null && !data.Success) {
            console.log(data.Message);
          }
        },
        (error) => {
          console.log('erro' + error);
        });
    }
  }

}
