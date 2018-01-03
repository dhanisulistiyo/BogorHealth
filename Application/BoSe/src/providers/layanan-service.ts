import { ConfigProvider } from './config';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

/*
  Generated class for the LayananServiceProvider provider.

  See https://angular.io/docs/ts/latest/guide/dependency-injection.html
  for more info on providers and Angular DI.
*/
@Injectable()
export class LayananServiceProvider {

  constructor(public http: Http, public conf: ConfigProvider) {
    console.log('Hello LayananServiceProvider Provider');
  }

  getServiceHospital(id){
      let url = this.conf.baseUrl+'api/LayananRs/'+id;
      let res = this.http.get(url).map(res=>res).map(res=>res);
      return res;
  }

  getJadwal(id){
    let url = this.conf.baseUrl+'api/JadwalLayanans/'+id;
    let res = this.http.get(url).map(res=>res).map(res=>res);
    return res;
  }

  getAntrian(nik, id){
    let url = this.conf.baseUrl+'api/Antrians?nik='+nik+'&idlayanan='+id;
    let res = this.http.get(url).map(res=>res).map(res=>res);
    return res;
  }
}
