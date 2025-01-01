import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserProfileRoutingModule } from './user-profile-routing.module';
import { UserProfileListComponent } from './components/user-profile-list/user-profile-list.component';
import { SharedModule } from '../../shared/shared.module';


@NgModule({
  declarations: [
    UserProfileListComponent
  ],
  imports: [
    SharedModule,
    UserProfileRoutingModule
  ]
})
export class UserProfileModule { }
