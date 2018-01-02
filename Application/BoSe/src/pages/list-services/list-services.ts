import { LayananServiceProvider } from './../../providers/layanan-service';
import { ConfigProvider } from './../../providers/config';
import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';

/**
 * Generated class for the ListServicesPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@Component({
  selector: 'page-list-services',
  templateUrl: 'list-services.html',
})
export class ListServicesPage {
  id
  ListLayanan = []
  constructor(public navCtrl: NavController, public navParams: NavParams, public layanan : LayananServiceProvider) {
   this.id = this.navParams.data['id']
  }


  ionViewWillEnter(){
    console.log('ionViewDidLoad ListServicesPage');
    this.layanan.getServiceHospital(this.id).subscribe(data=>{
      this.ListLayanan = data.json();
    })
  }

}
