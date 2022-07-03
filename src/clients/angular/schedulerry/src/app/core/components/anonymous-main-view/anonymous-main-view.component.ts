import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services';

@Component({
  selector: 'app-anonymous-main-view',
  templateUrl: './anonymous-main-view.component.html',
  styleUrls: ['./anonymous-main-view.component.scss']
})
export class AnonymousMainViewComponent implements OnInit {
  constructor(private auth: AuthService) {}

  ngOnInit(): void {}

  public login(): void {
    this.auth.login();
  }
}
