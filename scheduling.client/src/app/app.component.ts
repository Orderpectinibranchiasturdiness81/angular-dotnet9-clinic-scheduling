import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  constructor(private translate: TranslateService) {}

  ngOnInit() {
    let lang: string = 'en';
    localStorage.setItem('lang', lang);
    this.translate.setDefaultLang(lang);
    this.translate.use(lang);
  }

  switchLanguage(lang: string): void {
    localStorage.setItem('lang', lang);
    this.translate.use(lang);
  }
}
