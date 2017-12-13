import { Component, ViewChild } from '@angular/core';
import { IonicPage, NavController, NavParams,  Content } from 'ionic-angular';

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
  constructor(public navCtrl: NavController, public navParams: NavParams) {
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad DetailChatPage');
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
