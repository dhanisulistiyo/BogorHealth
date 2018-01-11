import { Component,ChangeDetectorRef } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';

/**
 * Generated class for the DetailAntrianPage page.
 *
 * See http://ionicframework.com/docs/components/#navigation for more info
 * on Ionic pages and navigation.
 */
@Component({
  selector: 'page-detail-antrian',
  templateUrl: 'detail-antrian.html',
})
export class DetailAntrianPage {
  Antrian
  baseUrl
  showToolbar: boolean = false;
  constructor(public navCtrl: NavController, public navParams: NavParams, public ref: ChangeDetectorRef) {
    this.Antrian= this.navParams.data['antri']
    this.baseUrl="http://localhost:53939/Content/img/"
  }

  onScroll($event: any) {
    let scrollTop = $event.scrollTop;
    this.showToolbar = scrollTop >= 120;
    this.ref.detectChanges();
  }
  ionViewDidLoad() {
    console.log('ionViewDidLoad DetailAntrianPage');
  }

}
