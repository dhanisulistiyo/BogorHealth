import { ChatHistoryPage } from './../chat-history/chat-history';
import { ListHospitalPage } from './../list-hospital/list-hospital';
import { Component, ChangeDetectorRef } from '@angular/core';
import { NavController } from 'ionic-angular';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {
  showToolbar
  constructor(public navCtrl: NavController, public ref: ChangeDetectorRef) {

  }

  onScroll($event: any) {
    let scrollTop = $event.scrollTop;
    this.showToolbar = scrollTop >= 120;
    this.ref.detectChanges();
  }

  gotoListHospital(){
    this.navCtrl.push(ListHospitalPage)
  }

  gotoChat(){
    this.navCtrl.push(ChatHistoryPage)
  }

}
