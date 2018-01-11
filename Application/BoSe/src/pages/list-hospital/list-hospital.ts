import { HospitalServiceProvider } from './../../providers/hospital-service';
import { ListServicesPage } from './../list-services/list-services';
import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';

/**
 * Generated class for the ListHospitalPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */


@Component({
  selector: 'page-list-hospital',
  templateUrl: 'list-hospital.html',
})
export class ListHospitalPage {
  Hospital
  baseUrl
  constructor(public navCtrl: NavController, public navParams: NavParams, public hos: HospitalServiceProvider) {
    this.baseUrl="http://localhost:53939/Content/img/"
  }

  ionViewWillEnter(){
    console.log('ionViewDidLoad ListHospitalPage');
    this.hos.getAllHospital().subscribe(data=>{
      console.log(data)
      this.Hospital = data.json();
    })
  }
  gotoService(id){
    this.navCtrl.push(ListServicesPage, {id})
  }

}
