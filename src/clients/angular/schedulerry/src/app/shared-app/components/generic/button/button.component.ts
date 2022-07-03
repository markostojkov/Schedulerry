import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

import { ButtonType } from './button.models';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.scss']
})
export class ButtonComponent implements OnInit {
  @Input() buttonType = ButtonType.Basic;
  @Input() disabled = false;
  @Output() action = new EventEmitter();

  constructor() {}

  ngOnInit(): void {}

  public getButtonType(): string {
    switch (this.buttonType) {
      case ButtonType.Basic:
        return '';
      case ButtonType.CallToAction:
        return 'primary';
      case ButtonType.Warn:
        return 'warn';
    }
  }
}
