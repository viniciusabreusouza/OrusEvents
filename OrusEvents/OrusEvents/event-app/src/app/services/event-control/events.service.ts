import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { RegisterUserInEventRequest } from 'src/app/models/events/register-user-event-request.model';
import { Observable } from 'rxjs';
import { RegisterUserInEventResponse } from 'src/app/models/events/register-user-event-response.model';
import { RegisterConfirmationResponse } from 'src/app/models/events/register-confirmation-response.model';


const urlEvent = 'https://localhost:44357/api/Event/';

@Injectable({
  providedIn: 'root'
})
export class EventsService {

  constructor(protected http: HttpClient,
              private router: Router) { }

  RegisterUserInEvent(request: RegisterUserInEventRequest): Observable<RegisterUserInEventResponse> {
    return this.http.post<RegisterUserInEventResponse>(`${urlEvent}/RegisterUserInEvent/${request.eventId}/${request.email}`, null);
  }

  RegisterConfirmationInEvent(request: string): Observable<RegisterConfirmationResponse>{
    return this.http.post<RegisterConfirmationResponse>(`${urlEvent}/RegisterConfirmationInEvent/${request}`, null);
  }
}
