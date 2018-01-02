import { ConfigProvider } from './config';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

/*
  Generated class for the DokterServiceProvider provider.

  See https://angular.io/docs/ts/latest/guide/dependency-injection.html
  for more info on providers and Angular DI.
*/
@Injectable()
export class DokterServiceProvider {

  constructor(public http: Http, private conf: ConfigProvider) {
    console.log('Hello DokterServiceProvider Provider');
  }

  getAllDokter(){
    let url = this.conf.baseUrl+'api/Dokters/'
    let res = this.http.get(url).map(res=>res).map(res=>res);
    return res;
  }

}
