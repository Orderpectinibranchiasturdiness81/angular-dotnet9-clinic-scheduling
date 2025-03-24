import {
  Directive,
  ElementRef,
  Input,
  AfterViewInit,
  OnDestroy,
  forwardRef
} from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

declare var $: any;

@Directive({
  selector: '[appSummernote]',
  standalone: false,
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => SummernoteDirective),
      multi: true
    }
  ]
})
export class SummernoteDirective implements AfterViewInit, OnDestroy, ControlValueAccessor {

  @Input() summernoteConfig: any;
  private onChange: any = () => { };
  private onTouched: any = () => { };

  constructor(private el: ElementRef) { }

  writeValue(value: any): void {
    $(this.el.nativeElement).summernote('code', value || '');
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  ngAfterViewInit() {
    const defaultConfig = {
      placeholder: '................!',
      tabsize: 0,
      height: 300,
      toolbar: [
        ['style', ['fontname', 'bold', 'italic', 'underline', 'clear']],
        ['font', ['strikethrough', 'superscript', 'subscript']],
        ['fontsize', ['fontsize']],
        ['color', ['color', 'forecolor','backcolor']],
        ['para', ['ul', 'ol', 'paragraph', 'height', 'style']],
        ['insert', ['link', 'picture', 'video', 'table', 'hr']],
        ['view', ['fullscreen', 'codeview', 'help']]
      ],
      callbacks: {
        onChange: (contents: any) => {
          this.onChange(contents);
        }
      }
    };

    $(this.el.nativeElement).summernote({
      ...(this.summernoteConfig || defaultConfig),
      theme: 'bs4'
    });
  }

  ngOnDestroy() {
    $(this.el.nativeElement).summernote('destroy');
  }

}
