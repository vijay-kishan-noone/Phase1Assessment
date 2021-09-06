import { OrderService } from './../order.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormArray, Validators, FormBuilder} from '@angular/forms';
import {  Router } from '@angular/router';
import { Item } from '../items/item';
import { ItemsService } from '../items/items.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  userForm:FormGroup;
  counter:number;
  show :boolean = false;
  requestedItems:Item[]=new Array();
  requestedOrder:{name:string,qty:number}[] = new Array();
  constructor(private fb : FormBuilder,private router: Router) { 
    this.userForm = this.fb.group({
    items : this.fb.array([
      this.fb.control('')
    ]),
    orders:this.fb.array([
      this.fb.control('')
    ])
  });
  }

  ngOnInit(): void {
    
  }

  get getitems() { return <FormArray>this.userForm.get('items'); }
  get getorders() { return <FormArray>this.userForm.get('orders')}

  addItem(){
    this.getitems.push(this.fb.control(''));
  }
  deleteItem(index){
    this.getitems.removeAt(index);
  }
  addOrder(){
    this.getorders.push(this.fb.control(''));
  }
  deleteOrder(index){
    this.getorders.removeAt(index);
  }
  submit(){
    this.counter = 0;
    for(let item of this.getitems.controls){
      this.requestedItems.push(ItemsService.getItems().find(x => x.name == this.userForm.get(['items',this.counter]).value.toLowerCase()));
      this.counter = this.counter + 1;
    }
    this.show = true;
  }
  payment(){
    this.counter = 0;
    for(let order of this.getorders.controls){
      let name = this.userForm.get(['orders',this.counter]).value.split(',')[0];
      let qty = this.userForm.get(['orders',this.counter]).value.split(',')[1];
      ItemsService.deleteItem(name,qty);
      this.requestedOrder.push({name,qty});
      this.counter = this.counter + 1;
    }
    OrderService.addList(this.requestedOrder);
    this.router.navigate(['payment']);
  }
}
