export class ApplicationUser {
  constructor(
    public id: number,
    public userType: ApplicationUserType,
    public email: string,
    public username: string,
    public isVerified: boolean
  ) {}
}

export class SelfUserResponse {
  uid!: string;
  organizationUid?: string;
}

export enum ApplicationUserType {
  Organizer = 'Organizer',
  Customer = 'Customer'
}
