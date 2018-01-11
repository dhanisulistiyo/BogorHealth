import { DetailAntrianPage } from './../detail-antrian/detail-antrian';
import { AuthServiceProvider } from './../../providers/auth-service';
import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, LoadingController } from 'ionic-angular';
import { LayananServiceProvider } from '../../providers/layanan-service';

/**
 * Generated class for the HistoryAntrianPage page.
 *
 * See http://ionicframework.com/docs/components/#navigation for more info
 * on Ionic pages and navigation.
 */
@Component({
  selector: 'page-history-antrian',
  templateUrl: 'history-antrian.html',
})
export class HistoryAntrianPage {
  ListAntrian
  Nik
  constructor(public navCtrl: NavController, public navParams: NavParams, public auth: AuthServiceProvider, public load:LoadingController,
  public ser: LayananServiceProvider
  ) {
    this.Nik= this.auth.Authenthication.UserName;
    this.ListAntrian = []
  }
  
  ionViewWillEnter(){
    console.log('ionViewDidLoad AntrianPage');
    let loader = this.load.create({
      content: 'Please wait...'
    });
    loader.present();

    this.ser.getListAntrian( this.Nik).subscribe(data=>{
      this.ListAntrian = data.json();
      console.log(data.json())
      loader.dismiss();
    }, err=>{
      console.log(err);
      console.log(err.json());
      loader.dismiss();
    })
  }

  gotoDetails(antri){
    this.navCtrl.push(DetailAntrianPage, {antri})
  }
 



}
