import { ChatServiceProvider } from './../../providers/chat-service';
import { ListDokterPage } from './../list-dokter/list-dokter';
import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, LoadingController } from 'ionic-angular';
import { DetailChatPage } from '../detail-chat/detail-chat';
import { AuthServiceProvider } from '../../providers/auth-service';

/**
 * Generated class for the ChatHistoryPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@Component({
  selector: 'page-chat-history',
  templateUrl: 'chat-history.html',
})
export class ChatHistoryPage {
Nik
ListChat
  constructor(public navCtrl: NavController, public navParams: NavParams, public load: LoadingController, 
    public cs : ChatServiceProvider, public auth: AuthServiceProvider) {
    this.Nik= this.auth.Authenthication.UserName;
    this.ListChat = []
  }

  ionViewWillEnter(){
      console.log('ionViewDidLoad ChatHistoryPage');
      let loader = this.load.create({
        content: 'Please wait...'
      });
      loader.present();
  
      this.cs.getHistoryChat(this.Nik).subscribe(data=>{
        this.ListChat = data.json();
        console.log(data.json())
        loader.dismiss();
      }, err=>{
        console.log(err);
        console.log(err.json());
        loader.dismiss();
      })
  }

  gotoListDokter(){
    this.navCtrl.push(ListDokterPage);
  }

  gotoDetailChat(nik,npa){
    this.navCtrl.push(DetailChatPage, {nik,npa})
  }

}
