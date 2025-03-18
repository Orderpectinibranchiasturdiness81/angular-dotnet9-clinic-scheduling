import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserProfileListComponent } from './components/user-profile-list/user-profile-list.component';
import { UserProfileManageComponent } from './components/user-profile-manage/user-profile-manage.component';

const routes: Routes = [
  { path: '', component: UserProfileListComponent },
  { path: 'manage', component: UserProfileManageComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserProfileRoutingModule { }
