import { Component, OnInit } from '@angular/core';
import { OpenIdConnectService } from '../open-id-connect.service';
import { Router } from '@angular/router';

@Component({
  selector: 'ac-signin-oidc',
  templateUrl: './signin-oidc.component.html',
  styleUrls: ['./signin-oidc.component.scss']
})
export class SigninOidcComponent implements OnInit {
  constructor(private oidc: OpenIdConnectService, private route: Router) {}

  ngOnInit() {
    this.oidc.userLoad$.subscribe(userlonaded => {
      if (userlonaded) {
        this.route.navigate(['/dashboard']);
      } else {
        console.log('登入失败!');
      }
    });
    this.oidc.handleCallback();
  }
}
