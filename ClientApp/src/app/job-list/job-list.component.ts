import { Component, Input, OnInit, TemplateRef } from '@angular/core';
import { UserInfoService } from '../_services/user-info.service';
import { AccountService } from '../_services/account.service';
import { take } from 'rxjs';
import { User } from '../_models/user';
import { UserInfo } from '../_models/userInfo';
import { Job } from '../_models/job';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

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
  modalRef?: BsModalRef;

  constructor(
    private accountService: AccountService,
    private userInfoService: UserInfoService,
    private modalService: BsModalService
  ) {
    this.accountService.currentUser$.pipe(take(1)).subscribe({
      next: (user) => (this.user = user),
    });
  }

  ngOnInit(): void {}

  // Create a addJob method that will add a job to the user's job list
  // addJob(job: Job) {
  //   this.userInfoService.addJob(this.user!.id, job).subscribe({
  //     next: (userInfo) => {
  //       this.userInfo = userInfo;
  //       this.jobs = userInfo.jobs;
  //     },
  //   });

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }
}
