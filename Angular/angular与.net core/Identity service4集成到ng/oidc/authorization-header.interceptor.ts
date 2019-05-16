import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OpenIdConnectService } from './open-id-connect.service';
import { Observable } from 'rxjs';

@Injectable()
export class AuthorizationHeaderInterceptor implements HttpInterceptor {
  constructor(private oidc: OpenIdConnectService) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    if (this.oidc.userAvailable) {
      //克隆发起的请求
      request = request.clone({
        //在header上添加新的token信息
        setHeaders: {
          Authorization: `${this.oidc.Currentuser.token_type} ${
            this.oidc.Currentuser.access_token
          }`
        }
      });
    }

    //返回新的请求
    return next.handle(request);
  }
}
