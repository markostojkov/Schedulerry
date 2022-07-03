import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoaderService {
  public isLoading = new Subject<boolean>();

  constructor() {}

  public appIsLoading(): void {
    this.isLoading.next(true);
  }

  public appStopedLoading(): void {
    this.isLoading.next(false);
  }
}
