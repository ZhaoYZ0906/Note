import { Component, OnInit } from '@angular/core';
import { OpenIdConnectService } from '../open-id-connect.service';

@Component({
  selector: 'ac-redirect-silentrenew',
  templateUrl: './redirect-silentrenew.component.html',
  styleUrls: ['./redirect-silentrenew.component.scss']
})
export class RedirectSilentrenewComponent implements OnInit {
  constructor(private oidc: OpenIdConnectService) {}

  ngOnInit() {
    this.oidc.handleSilentCallback();
  }
}
