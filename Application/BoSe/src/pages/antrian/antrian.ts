import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { Component ,ChangeDetectorRef } from '@angular/core';
import { IonicPage, NavController, NavParams, LoadingController } from 'ionic-angular';
import { AuthServiceProvider } from '../../providers/auth-service';
import { LayananServiceProvider } from '../../providers/layanan-service';

/**
 * Generated class for the AntrianPage page.
 *
 * See http://ionicframework.com/docs/components/#navigation for more info
 * on Ionic pages and navigation.
 */

@Component({
  selector: 'page-antrian',
  templateUrl: 'antrian.html',
})
export class AntrianPage {
  id
  Nik
  Antrian
  ErrorMessage
  showToolbar: boolean = false;
  constructor(public navCtrl: NavController, public navParams: NavParams, public auth: AuthServiceProvider, 
    public ser: LayananServiceProvider, public alertCtrl: AlertController, public load: LoadingController,
    public ref: ChangeDetectorRef
  ) {
    this.id= this.navParams.data['id']
    this.Nik= this.auth.Authenthication.UserName;
    this.Antrian = null;
    this.ErrorMessage = null;
  }

  onScroll($event: any) {
    let scrollTop = $event.scrollTop;
    this.showToolbar = scrollTop >= 120;
    this.ref.detectChanges();
  }

  test(){
    console.log('ionViewDidLoad AntrianPage');
    let loader = this.load.create({
      content: 'Please wait...'
    });
    loader.present();

    this.ser.getAntrian( this.Nik, this.id).subscribe(data=>{
      this.Antrian = data.json();
      console.log(data.json())
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
