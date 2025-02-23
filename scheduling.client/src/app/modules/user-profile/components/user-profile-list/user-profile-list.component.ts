import { Component, OnInit } from '@angular/core';
import { SearchPageDto } from '../../../../models/search-page-dto';
import { UserProfileFilter, UserProfileModel } from '../../../../models/user-profile/user-profile-model';
import { PagedDataDto } from '../../../../models/paged-data-dto';
import { UserProfileService } from '../../../../services/user-profile.service';
import { BaseComponent } from '../../../../base.component';

@Component({
  selector: 'app-user-profile-list',
  standalone: false,

  templateUrl: './user-profile-list.component.html',
  styleUrl: './user-profile-list.component.css'
})
export class UserProfileListComponent extends BaseComponent implements OnInit {

  searchCriteria: SearchPageDto<UserProfileFilter> = new SearchPageDto<UserProfileFilter>();
  filteredCriteria: SearchPageDto<UserProfileFilter> = new SearchPageDto<UserProfileFilter>();
  result: PagedDataDto<UserProfileModel> = new PagedDataDto<UserProfileModel>();
  //--------------------------------------------------------------------**
  constructor(private userProfileService: UserProfileService) {
    super();
  }

  ngOnInit() {
    this.prepareSearchCriteria();
  }

  prepareSearchCriteria(): void {
    this.filteredCriteria = new SearchPageDto<UserProfileFilter>();
    this.filteredCriteria.criteria = new UserProfileFilter();

    //this.filteredCriteria.criteria.name =
    //  this.searchCriteria.criteria.name?.length! > 0
    //    ? this.searchCriteria.criteria.name
    //    : undefined;

    //this.filteredCriteria.criteria.phoneNumber =
    //  this.searchCriteria.criteria.phoneNumber?.length! > 0
    //    ? this.searchCriteria.criteria.phoneNumber
    //    : undefined;

    this.searchUserProfiles();
  }

  private searchUserProfiles(): void {
    this.userProfileService.search(this.filteredCriteria).subscribe({
      next: (response) => {
        this.result = response;
      }
    });
  }
}
