import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { UserInfo } from '../_models/userInfo';
import { Observable } from 'rxjs';
import { Job } from '../_models/job';

@Injectable({
  providedIn: 'root',
})
export class UserInfoService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getUser(username: string) {
    return this.http.get<UserInfo>(this.baseUrl + 'users/' + username);
  }

  // getJobsForUser(username: string): Observable<Job[]> {
  //   const url = `${this.baseUrl}users/${username}`;
  //   return this.http.get<Job[]>(url);
  // }

  // getHttpOptions() {
  //   const userString = localStorage.getItem('user');
  //   if (!userString) return;
  //   const user = JSON.parse(userString);
  //   return {
  //     headers: new HttpHeaders({
  //       Authorization: 'Bearer ' + user,
  //     }),
  //   };
  // }
}
