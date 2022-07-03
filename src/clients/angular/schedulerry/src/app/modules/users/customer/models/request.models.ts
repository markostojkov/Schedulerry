export class CustomerRegisterRequest {
  constructor(
    public customerUsername: string,
    public customerEmail: string,
    public customerPassword: string,
    public customerConfirmPassword: string
  ) {}
}
