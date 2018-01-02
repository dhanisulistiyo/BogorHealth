import { DetailDokterPage } from './../detail-dokter/detail-dokter';
import { DokterServiceProvider } from './../../providers/dokter-service';
import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';

/**
 * Generated class for the ListDokterPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@Component({
  selector: 'page-list-dokter',
  templateUrl: 'list-dokter.html',
})
export class ListDokterPage {
  listDokter
  constructor(public navCtrl: NavController, public navParams: NavParams, public dokter : DokterServiceProvider) {
    this.listDokter = []
  }

  ionViewWillEnter(){
    console.log('ionViewDidLoad ListDokterPage');
    this.dokter.getAllDokter().subscribe(data => {
      this.listDokter = data.json();
      console.log(data.json())
    });
  }

  detailDokter(doc){
    this.navCtrl.push(DetailDokterPage,{ doc })
  }


}
