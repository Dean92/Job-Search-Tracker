import { Component, OnInit } from '@angular/core';
import { UserInfo } from '../_models/userInfo';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';
import { UserInfoService } from '../_services/user-info.service';
import { take } from 'rxjs';

@Component({
  selector: 'app-user-home',
  templateUrl: './user-home.component.html',
  styleUrls: ['./user-home.component.css'],
})
export class UserHomeComponent implements OnInit {
  userInfo: UserInfo | undefined;
  user: User | null = null;

  constructor(
    private accountService: AccountService,
    private userInfoService: UserInfoService
  ) {
    this.accountService.currentUser$.pipe(take(1)).subscribe({
      next: (user) => (this.user = user),
    });
  }

  ngOnInit(): void {
    this.loadUser();
  }

  loadUser() {
    if (!this.user) return;
    this.userInfoService.getUser(this.user.username).subscribe({
      next: (userInfo) => (this.userInfo = userInfo),
    });
  }
}
