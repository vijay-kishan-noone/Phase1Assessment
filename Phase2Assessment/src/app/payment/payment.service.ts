import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {
  static paymentList:any[] = new Array();
  static getList(){
    return this.paymentList[this.paymentList.length-1];
  }
  static addList(i){
    this.paymentList.push(i);
  }
  constructor() { }
}
