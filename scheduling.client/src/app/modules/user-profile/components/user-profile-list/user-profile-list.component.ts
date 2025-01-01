import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-user-profile-list',
  standalone: false,

  templateUrl: './user-profile-list.component.html',
  styleUrl: './user-profile-list.component.css'
})
export class UserProfileListComponent implements OnInit {
  //constructor(private translate: TranslateService) {
  //  this.translate.setDefaultLang('en'); // Set default language
  //  this.translate.use('en'); // Set active language
  //}

  constructor() { }
  ngOnInit() {
    //this.translate.setDefaultLang('en'); // Set default language
    //this.translate.use('en'); // Set active language
  }
}
