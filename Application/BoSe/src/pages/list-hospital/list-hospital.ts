import { ListServicesPage } from './../list-services/list-services';
import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';

/**
 * Generated class for the ListHospitalPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */


@Component({
  selector: 'page-list-hospital',
  templateUrl: 'list-hospital.html',
})
export class ListHospitalPage {

  constructor(public navCtrl: NavController, public navParams: NavParams) {
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad ListHospitalPage');
  }

  gotoService(){
    this.navCtrl.push(ListServicesPage)
  }

}
