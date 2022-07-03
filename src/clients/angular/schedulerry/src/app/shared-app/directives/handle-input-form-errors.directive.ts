import {
  AfterViewInit,
  ComponentFactoryResolver,
  ComponentRef,
  ContentChild,
  Directive,
  ElementRef,
  Renderer2,
  ViewContainerRef
} from '@angular/core';
import { NgControl } from '@angular/forms';
import { MatFormField } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';

import { FormErrorComponent } from '../components/generic/form-error/form-error.component';

@Directive({
  selector: '[appHandleInputFormErrors]'
})
export class HandleInputFormErrorsDirective implements AfterViewInit {
  private errorComponent: ComponentRef<FormErrorComponent>;
  private control!: NgControl | null;
  @ContentChild(MatInput, { read: ElementRef }) controlElementRef!: ElementRef;

  constructor(
    private vcr: ViewContainerRef,
    private resolver: ComponentFactoryResolver,
    private formField: MatFormField,
    private renderer: Renderer2
  ) {
    const factory = this.resolver.resolveComponentFactory(FormErrorComponent);
    this.resolver.resolveComponentFactory(FormErrorComponent);
    this.errorComponent = this.vcr.createComponent(factory);
  }

  public ngAfterViewInit(): void {
    this.control = this.formField._control.ngControl;
    this.renderer.listen(this.controlElementRef.nativeElement, 'blur', () => this.onChange());
    this.formField?._control?.ngControl?.statusChanges?.subscribe(() => this.onChange());
  }

  private onChange(): void {
    this.errorComponent.instance.errors = this.control?.errors;
  }
}
