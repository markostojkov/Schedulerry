import { Component, OnInit } from '@angular/core';
import { LoaderService, RedirectService } from './core/services';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  constructor(public loader: LoaderService, private redirect: RedirectService) {}

  ngOnInit(): void {
    this.redirect.redirectLoggedInUser();
  }
}
