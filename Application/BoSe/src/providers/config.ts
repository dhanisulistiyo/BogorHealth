
import { Injectable } from '@angular/core';

/*
  Generated class for the ConfigProvider provider.

  See https://angular.io/guide/dependency-injection for more info on providers
  and Angular DI.
*/
@Injectable()
export class ConfigProvider {
  baseUrl;
  constructor() {
    console.log('Hello ConfigProvider Provider');
    this.baseUrl = "http://localhost:53939/"
  }

}
