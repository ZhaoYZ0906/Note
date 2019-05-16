import { Injectable } from '@angular/core';
import { UserManager, User } from 'oidc-client';
import { environment } from 'src/environments/environment';
import { ReplaySubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OpenIdConnectService {
  private userManager = new UserManager(environment.openIdConnectSettings);
  private user: User;

  // 判断是否有用户登陆
  get userAvailable(): boolean {
    return !!this.user;
  }

  // 返回当前用户
  get Currentuser(): User {
    return this.user;
  }

  // rxjs知识，只知道是一个广播的东西，广播bool类型，并且有一个用户登陆就广播一次
  userLoad$ = new ReplaySubject<boolean>(1);

  constructor() {
    this.userManager.clearStaleState();
    this.userManager
      // 获取当前用户
      .getUser()
      .then(user => {
        // 如果当前用户 存在/不存在 就广播 true/false 并且赋值到user/置为空
        if (user) {
          this.user = user;
          this.userLoad$.next(true);
        } else {
          this.user = null;
          this.userLoad$.next(false);
        }
      })
      // 防止报错，错了就全部置为空
      .catch(err => {
        this.user = null;
        this.userLoad$.next(false);
      });

    // 用户登陆加载之后执行？好像是这样
    this.userManager.events.addUserLoaded(user => {
      console.log('欢迎：' + user + '登陆');
      this.user = user;
      this.userLoad$.next(true);
    });

    // 用户登出加载之后执行？好像是这样
    this.userManager.events.addUserLoaded(user => {
      console.log('登出！');
      this.user = null;
      this.userLoad$.next(false);
    });
  }

  // 登入和登入回掉函数
  triggerSingIn(): void {
    this.userManager.signinRedirect().then(() => {
      console.log('登入函数');
    });
  }
  handleCallback(): void {
    this.userManager.signinRedirectCallback().then(user => {
      this.user = user;
      console.log('登入回掉函数');
    });
  }

  // 自动刷新登入时的回掉函数，登入有个过期时间到了过期时间就自动重新登入，这个是对应的回掉
  handleSilentCallback() {
    this.userManager.signinSilentCallback().then(user => {
      this.user = user;
      console.log('自动刷新回掉');
    });
  }

  // 登出函数
  triggerSingOut(): void {
    this.userManager.signoutRedirect().then(res => {
      console.log('登出函数');
    });
  }
}
