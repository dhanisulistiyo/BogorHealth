import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams,LoadingController, MenuController } from 'ionic-angular';
import { AlertController } from 'ionic-angular/components/alert/alert-controller';

/**
 * Generated class for the LoginPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@Component({
  selector: 'page-login',
  templateUrl: 'login.html',
})
export class LoginPage {
  registerCredentials = { companyid:'' ,username: '', password: '' };
  constructor(public nav: NavController,
    private alertCtrl: AlertController,public load : LoadingController, 
    public menu: MenuController) {
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad LoginPage');
  }


public createAccount() {
    
}

public login() {
     let loader = this.load.create({
        content: 'Please wait...'
    });
    
    loader.present();
   
}

showError(text) {
    let alert = this.alertCtrl.create({
        title: 'Failed!',
        subTitle: text,
        buttons: ['OK']
    });
    alert.present();
}
setText(ev){
    console.log(ev)
}

}
