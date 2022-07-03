export enum TimeLengthMinutesOptionsEnum {
  HalfHour = 30,
  OneHour = 60,
  TwoHour = 120
}

export enum DaysOfWeek {
  Monday = 1,
  Tuesday = 2,
  Wednesday = 3,
  Thursday = 4,
  Friday = 5,
  Saturday = 6,
  Sunday = 0
}

export interface DayOfWeekRepresentation {
  dayDescription: string;
  dayEnum: DaysOfWeek;
}

export const DAYS_OF_WEEK_REPRESENTATION: DayOfWeekRepresentation[] = [
  {
    dayDescription: 'Monday',
    dayEnum: DaysOfWeek.Monday
  },
  {
    dayDescription: 'Tuesday',
    dayEnum: DaysOfWeek.Tuesday
  },
  {
    dayDescription: 'Wednesday',
    dayEnum: DaysOfWeek.Wednesday
  },
  {
    dayDescription: 'Thursday',
    dayEnum: DaysOfWeek.Thursday
  },
  {
    dayDescription: 'Friday',
    dayEnum: DaysOfWeek.Friday
  },
  {
    dayDescription: 'Saturday',
    dayEnum: DaysOfWeek.Saturday
  },
  {
    dayDescription: 'Sunday',
    dayEnum: DaysOfWeek.Sunday
  }
];
