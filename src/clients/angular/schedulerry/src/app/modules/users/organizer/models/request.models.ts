export class RegisterOrganizerRequest {
  constructor(
    public organizationName: string,
    public organizerUsername: string,
    public organizerEmail: string,
    public organizerPassword: string,
    public organizerConfirmPassword: string
  ) {}
}

export class AcceptInvitationOrganizerRequest {
  constructor(public organizerPassword: string, public organizerConfirmPassword: string) {}
}
