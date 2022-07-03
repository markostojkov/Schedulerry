import { Component, EventEmitter, Injectable, OnInit, Output } from '@angular/core';
import { DateAdapter } from '@angular/material/core';
import { MatDateRangeSelectionStrategy, DateRange, MAT_DATE_RANGE_SELECTION_STRATEGY } from '@angular/material/datepicker';
import * as moment from 'moment';
import { ScheduleDatesDto } from './date-range-with-selection-strategy.models';

@Injectable()
export class SevenDayRangeSelectionStrategy<D> implements MatDateRangeSelectionStrategy<D> {
  constructor(private dateAdapter: DateAdapter<D>) {}

  selectionFinished(date: D | null): DateRange<D> {
    return this._createSevenDayRange(date);
  }

  createPreview(activeDate: D | null): DateRange<D> {
    return this._createSevenDayRange(activeDate);
  }

  private _createSevenDayRange(date: D | null): DateRange<D> {
    if (date) {
      const start = this.dateAdapter.addCalendarDays(date, -3);
      const end = this.dateAdapter.addCalendarDays(date, 3);
      return new DateRange<D>(start, end);
    }

    return new DateRange<D>(null, null);
  }
}

@Component({
  selector: 'app-date-range-with-selection-strategy',
  templateUrl: './date-range-with-selection-strategy.component.html',
  styleUrls: ['./date-range-with-selection-strategy.component.scss'],
  providers: [
    {
      provide: MAT_DATE_RANGE_SELECTION_STRATEGY,
      useClass: SevenDayRangeSelectionStrategy
    }
  ]
})
export class DateRangeWithSelectionStrategyComponent implements OnInit {
  @Output() dateRange = new EventEmitter<ScheduleDatesDto>();

  constructor() {}

  ngOnInit(): void {}

  dateChanged(dateRangeStart: HTMLInputElement, dateRangeEnd: HTMLInputElement): void {
    this.dateRange.emit(new ScheduleDatesDto(moment(dateRangeStart.value), moment(dateRangeEnd.value)));
  }
}
