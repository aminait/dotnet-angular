import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Resume } from '../_models/resume';
import { UserProfile } from '../_models/user-profile';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  baseUrl = environment.apiUrl + 'users/';

  constructor(private http: HttpClient) {}

  getUser(id: number): Observable<UserProfile> {
    return this.http.get<UserProfile>(this.baseUrl + id);
  }

  updateUser(id: number, user: UserProfile) {
    return this.http.put(this.baseUrl + id, user);
  }

  getResume(id: number): Observable<Resume> {
    return this.http.get<Resume>(this.baseUrl + id + '/resume');
  }
}
