import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { ConfigProvider } from './config';

/*
  Generated class for the ChatServiceProvider provider.

  See https://angular.io/docs/ts/latest/guide/dependency-injection.html
  for more info on providers and Angular DI.
*/
@Injectable()
export class ChatServiceProvider {

  constructor(public http: Http, public conf: ConfigProvider) {
    console.log('Hello ChatServiceProvider Provider');
  }


  getHistoryChat(nik){
    let url = this.conf.baseUrl+'api/ChatsHistory?nik='+nik;
    let res = this.http.post(url, null).map(res=>res).map(res=>res);
    return res;
  }

  getDetailsChat(nik, npa){
    let url = this.conf.baseUrl+'api/ChatsDetails?nik='+nik+'&npa='+npa;
    let res = this.http.post(url, null).map(res=>res).map(res=>res);
    return res;
  }
}
