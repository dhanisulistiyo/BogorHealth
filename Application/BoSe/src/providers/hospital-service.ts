import { ConfigProvider } from './config';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

/*
  Generated class for the HospitalServiceProvider provider.

  See https://angular.io/docs/ts/latest/guide/dependency-injection.html
  for more info on providers and Angular DI.
*/
@Injectable()
export class HospitalServiceProvider {

  constructor(public http: Http , public conf: ConfigProvider) {
    console.log('Hello HospitalServiceProvider Provider');
  }


  getAllHospital(){
    let url = this.conf.baseUrl+'api/RumahSakits'
    let res = this.http.get(url).map(res=>res).map(res=>res);
    return res;
  }
}
