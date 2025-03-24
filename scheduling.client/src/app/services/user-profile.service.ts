import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { ControllerNames } from '../models/controller-names';
import { SearchPageDto } from '../models/search-page-dto';
import { UserProfileFilter, UserProfileModel } from '../models/user-profile/user-profile-model';
import { PagedDataDto } from '../models/paged-data-dto';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserProfileService {
  URL_API: string = `${environment.server_URL}${ControllerNames.UserProfile}`;
  constructor(private http: HttpClient) { }
  //-----------------------------------------------**
  search(model: SearchPageDto<UserProfileFilter>): Observable<PagedDataDto<UserProfileModel>> {
    return this.http.post<PagedDataDto<UserProfileModel>>(`${this.URL_API}/search`, model)
  }

  getById(id: number): Observable<UserProfileModel> {
    return this.http.get<UserProfileModel>(`${this.URL_API}/${id}`)
  }

  add(model: UserProfileModel): Observable<Object> {
    return this.http.post(`${this.URL_API}`, model)
  }

  update(model: UserProfileModel): Observable<Object> {
    return this.http.put(`${this.URL_API}`, model)
  }

  delete(id: number): Observable<Object> {
    return this.http.delete(`${this.URL_API}/${id}`)
  }
}
