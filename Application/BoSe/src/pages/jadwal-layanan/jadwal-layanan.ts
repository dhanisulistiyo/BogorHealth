import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, LoadingController } from 'ionic-angular';
import { LayananServiceProvider } from '../../providers/layanan-service';

/**
 * Generated class for the JadwalLayananPage page.
 *
 * See http://ionicframework.com/docs/components/#navigation for more info
 * on Ionic pages and navigation.
 */

@Component({
  selector: 'page-jadwal-layanan',
  templateUrl: 'jadwal-layanan.html',
})
export class JadwalLayananPage {
  id;
  Jadwal
  constructor(public navCtrl: NavController, public navParams: NavParams, public ser : LayananServiceProvider, 
    public load : LoadingController, public alertCtrl: AlertController ) {
    this.id = this.navParams.data['id'];
    this.Jadwal = []
  }

  ionViewWillEnter(){
    console.log('ionViewDidLoad JadwalLayananPage');
    let loader = this.load.create({
      content: 'Please wait...'
    });
    loader.present();

    this.ser.getJadwal(this.id).subscribe(data=>{
      this.Jadwal = data.json();
      console.log(this.Jadwal)
    loader.dismiss();
    }, err=>{
      console.log(err);
      console.log(err.json());
      loader.dismiss();
      this.showError(err.json().Message)
    })
  }
  
  showError(text) {
    let alert = this.alertCtrl.create({
      title: 'Failed!',
      subTitle: text,
      buttons: [
        {
          text: 'OK',
          handler: () => {
            this.navCtrl.pop();
            console.log('err');
          }
        }
      ]
    });
    alert.present();
  }

}
