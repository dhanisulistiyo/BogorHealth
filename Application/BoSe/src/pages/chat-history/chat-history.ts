import { ListDokterPage } from './../list-dokter/list-dokter';
import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { DetailChatPage } from '../detail-chat/detail-chat';

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

  constructor(public navCtrl: NavController, public navParams: NavParams) {
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad ChatHistoryPage');
  }

  gotoListDokter(){
    this.navCtrl.push(ListDokterPage);
  }

  gotoDetailChat(){
    this.navCtrl.push(DetailChatPage)
  }

}
