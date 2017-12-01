import { Component } from '@angular/core';
import { NavParams,NavController } from 'ionic-angular';

@Component({
  selector: 'page-infomodal',
  templateUrl: 'infomodal.html'
})
export class InfoModalPage {
    myParam: string;
   constructor(
    public navCtrl: NavController,
    params: NavParams
  ) {
    this.myParam = params.get('myParam');
  }

}
