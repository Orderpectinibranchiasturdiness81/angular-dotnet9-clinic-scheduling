import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../../../base.component';
import { UserProfileService } from '../../../../services/user-profile.service';
import { Location } from '@angular/common';
import { UserProfileModel } from '../../../../models/user-profile/user-profile-model';

@Component({
  selector: 'app-user-profile-manage',
  standalone: false,

  templateUrl: './user-profile-manage.component.html',
  styleUrl: './user-profile-manage.component.css'
})
export class UserProfileManageComponent extends BaseComponent implements OnInit {
  model: UserProfileModel = new UserProfileModel();
  //-------------------------------------------------**
  constructor(private userProfileService: UserProfileService,
    private location: Location) {
    super();
  }

  ngOnInit(): void { }

  submit() {
    this.add();
  }

  private add() {
    this.userProfileService.add(this.model).subscribe({
      next: () => {
        this.toastrService.success("Done Successfully");
        this.cancel();
      }
    });
  }
  cancel() {
    this.location.back();
  }

}
