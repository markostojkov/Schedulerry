namespace Schedulerry.Common.Errors
{
    public static class ErrorCodes
    {
        public const string MustBeUnique = "must-be-unique";
        public const string FieldRequired = "field-required";
        public const string MaxLengthExceeded = "max-length-exceeded";
        public const string MinLengthNotExceeded = "min-length-not-exceeded";
        public const string UrlNotValid = "url-not-valid";
        public const string CurrencyNotValid = "currency-not-valid";
        public const string ResourceForbidden = "resource-forbidden";
        public const string Forbidden = "forbidden";
        public const string CodeDatePassed = "code-date-passed";
        public const string NotFound = "not-found";
        public const string EmailNotValid = "email-not-valid";
        public const string PasswordNotValid = "password-not-valid";
        public const string PasswordNotMatch = "password-not-match";
        public const string PriceNotValid = "price-not-valid";
        public const string WorkingTimeNotValid = "working-time-not-valid";
        public const string WorkingDatesRepeat = "working-dates-repeat";
        public const string ReservationInThatIntervalInvalid = "reservation-in-that-interval-invalid";
        public const string CustomerAlreadyHasReservationInThatInterval = "customer-already-has-reservation-in-that-interval";
        public const string ReservationInThePastInvalid = "reservation-in-the-past-invalid";
        public const string ServiceOptionNotWorkingThatDay = "service-option-not-working-that-day";
    }
}
