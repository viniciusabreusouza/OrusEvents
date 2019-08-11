export interface GetRegisterInfoResponse {
  EventId: number;
  EventName: string;
  EventDate: Date;
  Payed: boolean;
  UserEmail: string;
  Errors: string[];
  Success: boolean;
  Message: string;
}
