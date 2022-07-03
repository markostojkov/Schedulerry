import { AfterViewInit, Directive, ElementRef } from '@angular/core';
import { LoaderService } from 'src/app/core/services';

@Directive({
  selector: '[appLoader]'
})
export class LoaderDirective implements AfterViewInit {
  el: ElementRef;

  constructor(el: ElementRef, private loader: LoaderService) {
    this.el = el;
  }
  ngAfterViewInit(): void {
    this.el.nativeElement.style.display = 'none';

    this.loader.isLoading.subscribe((isLoading) => {
      if (!isLoading) {
        this.el.nativeElement.style.display = 'block';
      }
    });
  }
}
