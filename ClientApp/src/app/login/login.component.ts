import { Component, EventEmitter, Output } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  // model: any = {};
  // loggedIn = false;
  // constructor(private accountService: AccountService) {}
  // login() {
  //   this.accountService.login(this.model).subscribe({
  //     next: (response) => {
  //       console.log(response);
  //       this.loggedIn = true;
  //     },
  //     error: (error) => console.log(error),
  //   });
  // }
  // logout() {
  //   this.loggedIn = false;
  // }
}
