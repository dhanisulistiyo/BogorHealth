import { AuthServiceProvider } from './../../providers/auth-service';
import { TabsHomePage } from './../tabs-home/tabs-home';
import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, LoadingController, MenuController } from 'ionic-angular';
import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { RegisterPage } from '../register/register';

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
  registerCredentials = { Username: null, Password: null };
  constructor(public nav: NavController,
    private alertCtrl: AlertController, public load: LoadingController,
    public menu: MenuController, private auth: AuthServiceProvider) {
  }
  ionViewDidEnter(){
    console.log('ionViewDidLoad LoginPage');
    this.registerCredentials = { Username: null, Password: null };
  }


  public createAccount() {
    this.nav.push(RegisterPage);
  }

  public login() {
    let loader = this.load.create({
      content: 'Please wait...'
    });
    loader.present();
    this.auth.loginPasien(this.registerCredentials).subscribe(data=>{
      console.log(data.json())
      this.auth.storeUserCredentials(data.json())
      this.auth.loadToken()
      loader.dismiss();
      this.nav.setRoot(TabsHomePage);
    }, err=>{
      console.log(err.json());
      this.showError(err.json().Message)
      loader.dismiss();
    })
  }

  showError(text) {
    let alert = this.alertCtrl.create({
      title: 'Failed!',
      subTitle: text,
      buttons: ['OK']
    });
    alert.present();
  }

}
