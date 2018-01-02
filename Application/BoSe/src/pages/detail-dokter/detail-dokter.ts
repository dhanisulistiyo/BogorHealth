import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';

/**
 * Generated class for the DetailDokterPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@Component({
  selector: 'page-detail-dokter',
  templateUrl: 'detail-dokter.html',
})
export class DetailDokterPage {
  Dokter
  constructor(public navCtrl: NavController, public navParams: NavParams) {
    this.Dokter = this.navParams.data.doc;
    console.log(this.Dokter)
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad DetailDokterPage');
  }

}
