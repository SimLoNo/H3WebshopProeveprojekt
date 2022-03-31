import { Component, OnInit } from '@angular/core';
import { Account } from '../_models/account';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {

  constructor(private accountService: AccountService) { }

  account: Account = { id: 0, username: '', password: '', userFirstName: '', userLastName: '', accountRoleId: 0 };

  ngOnInit(): void {
  }
  login(): void {
    let jwt = this.accountService.authenticate(this.account)
      .subscribe(x => {
        console.log(x.token);
      });
  }

}
