import { ConfigProvider } from './config';
import { Http, Headers } from '@angular/http';
import { Injectable, forwardRef } from '@angular/core';
import 'rxjs/add/operator/map';
/*
  Generated class for the AuthServiceProvider provider.

  See https://angular.io/guide/dependency-injection for more info on providers
  and Angular DI.
*/
@Injectable()
export class AuthServiceProvider {
  Authenthication
  constructor(public http: Http, private conf: ConfigProvider) {
    console.log('Hello AuthServiceProvider Provider');
    this.Authenthication = null
  }

  public storeUserCredentials(token) {
    window.localStorage.setItem('auth', JSON.stringify(token));
  }

  public loadToken() {
    let akun = JSON.parse(window.localStorage.getItem('auth'))
    this.Authenthication = akun
  }

  loginPasien(user) {
    var headers = new Headers();
    headers.append('Content-Type', 'application/json');
    let response = this.http.post(this.conf.baseUrl+'api/LoginPasien', user, { headers: headers }).map(res =>res) 
    return response
  }


  test() {
 
    let url = this.conf.baseUrl+'api/Pasiens/'
    this.http.get(url).map(res=>res).map(res=>res).subscribe(res=>{
      console.log(res.json())
    })
  }


}
