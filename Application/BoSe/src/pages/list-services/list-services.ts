import { JadwalLayananPage } from './../jadwal-layanan/jadwal-layanan';
import { LayananServiceProvider } from './../../providers/layanan-service';
import { ConfigProvider } from './../../providers/config';
import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { AntrianPage } from '../antrian/antrian';

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
      console.log(this.ListLayanan)
    })
  }

  gotoJadwal(id){
    this.navCtrl.push(JadwalLayananPage,{id})
  }

  gotoAntrian(id){
    this.navCtrl.push(AntrianPage,{id})
  }

}
