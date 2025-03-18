import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserProfileRoutingModule } from './user-profile-routing.module';
import { UserProfileListComponent } from './components/user-profile-list/user-profile-list.component';
import { SharedModule } from '../../shared/shared.module';
import { UserProfileManageComponent } from './components/user-profile-manage/user-profile-manage.component';


@NgModule({
  declarations: [
    UserProfileListComponent,
    UserProfileManageComponent
  ],
  imports: [
    SharedModule,
    UserProfileRoutingModule
  ]
})
export class UserProfileModule { }
