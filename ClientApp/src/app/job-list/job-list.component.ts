import { Component, Input, OnInit } from '@angular/core';
import { UserInfoService } from '../_services/user-info.service';
import { AccountService } from '../_services/account.service';
import { take } from 'rxjs';
import { User } from '../_models/user';
import { UserInfo } from '../_models/userInfo';
import { Job } from '../_models/job';

@Component({
  selector: 'app-job-list',
  templateUrl: './job-list.component.html',
  styleUrls: ['./job-list.component.css'],
})
export class JobListComponent implements OnInit {
  @Input() userInfo: UserInfo | undefined;
  //userInfo: UserInfo | undefined;
  user: User | null = null;
  jobs: Job[] = [];

  constructor(
    private accountService: AccountService,
    private userInfoService: UserInfoService
  ) {
    this.accountService.currentUser$.pipe(take(1)).subscribe({
      next: (user) => (this.user = user),
    });
  }

  ngOnInit(): void {}
}
