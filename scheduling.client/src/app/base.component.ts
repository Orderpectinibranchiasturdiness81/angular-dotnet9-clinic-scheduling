import { Component, inject } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-base',
  standalone: false,
  template: `
    <p>
      base works!
    </p>
  `,
  styles: [
  ]
})
export class BaseComponent {

  toastrService: ToastrService = inject(ToastrService); // Inject ToastrService
  //------------------------------------------------**
  constructor() { }

  isEnglishLang(): boolean {
    return localStorage.getItem('lang') == 'en';
  }
}
