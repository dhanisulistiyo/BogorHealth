import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { Pasien } from './../../model/pasien';
import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { AuthServiceProvider } from '../../providers/auth-service';

/**
 * Generated class for the RegisterPage page.
 *
 * See http://ionicframework.com/docs/components/#navigation for more info
 * on Ionic pages and navigation.
 */
@Component({
  selector: 'page-register',
  templateUrl: 'register.html',
})
export class RegisterPage {
  Pasien
  Dokter
  constructor(public navCtrl: NavController, public navParams: NavParams, public auth : AuthServiceProvider, public alertCtrl : AlertController) {
    this.Pasien = new Pasien();
    console.log(this.Pasien)
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad RegisterPage');
  }


  register(){
    console.log(this.Pasien)
    this.auth.register(this.Pasien).subscribe(data=>{
      console.log(data)
      this.showPopup("Success", "Your new account is created.");
    }, err=>{
      console.log(err)
      this.showPopup("Error", "Failed to create account. Please try again latter ...");
    })
  }


  showPopup(title, text) {
    let alert = this.alertCtrl.create({
        title: title,
        subTitle: text,
        buttons: [
            {
                text: 'OK',
                handler: data => {
                  this.navCtrl.pop();
                }
            }
        ]
    });
    alert.present();
}
}
