import { Component } from '@angular/core';

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

  //------------------------------------------------**
  constructor() { }

  isEnglishLang(): boolean {
    return localStorage.getItem('lang') == 'en';
  }
}
