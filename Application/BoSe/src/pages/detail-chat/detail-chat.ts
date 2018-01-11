import { ChatServiceProvider } from './../../providers/chat-service';
import { Component, ViewChild } from '@angular/core';
import { IonicPage, NavController, NavParams, Content, LoadingController } from 'ionic-angular';
import { AuthServiceProvider } from '../../providers/auth-service';

/**
 * Generated class for the DetailChatPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@Component({
  selector: 'page-detail-chat',
  templateUrl: 'detail-chat.html',
})
export class DetailChatPage {
  @ViewChild(Content) content: Content;
  nik;
  npa;
  msgList
  user
  constructor(public navCtrl: NavController, public navParams: NavParams, public cs:ChatServiceProvider, public load: LoadingController, public auth: AuthServiceProvider) {
    this.nik= this.navParams.data['nik']
    this.npa= this.navParams.data['npa']
    this.user=this.auth.Authenthication.UserName
    this.msgList = []
  }

  ionViewWillEnter() {
    console.log('ionViewDidLoad DetailChatPage');
    let loader = this.load.create({
      content: 'Please wait...'
    });
    loader.present();

    this.cs.getDetailsChat(this.nik, this.npa).subscribe(data=>{
      this.msgList = data.json();
      console.log(data.json())
      loader.dismiss();
    }, err=>{
      console.log(err);
      console.log(err.json());
      loader.dismiss();
    })
  }

  onFocus() {
    this.content.resize();
    this.scrollToBottom();
}

sendMsg() {
 
  }

  scrollToBottom() {
    setTimeout(() => {
        if (this.content.scrollToBottom) {
            this.content.scrollToBottom();
        }
    }, 400)
}

}
