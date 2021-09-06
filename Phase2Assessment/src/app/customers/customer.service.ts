import { Injectable } from '@angular/core';
import { Customer } from './customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private static customers:Customer[] = [
    {id:1001, name:'Anil', gender:'Male', city:'Hyderabad', phone:'987654321',uname:'anil',password:'password'},
    {id:1002, name:'Bobby', gender:'Male', city:'Bengaluru', phone:'987654320',uname:'bobby',password:'password'},
    {id:1003, name:'Kavya', gender:'Female', city:'Chennai', phone:'987654329',uname:'kavya',password:'password'}
  ];
  constructor() { }
  static getCustomers():Customer[]{
    return this.customers;
  }
  static addCustomer(c:Customer):void{
    this.customers.push(c);
  }
}
