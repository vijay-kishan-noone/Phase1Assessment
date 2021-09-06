import { Injectable } from '@angular/core';
import { Item } from './item';
@Injectable({
  providedIn: 'root'
})
export class ItemsService {
  private static items:Item[] = [
    {id:1,name:'idly',price:40,description:'A South Indian Breakfast',available:200},
    {id:2,name:'momos',price:50,description:'A North Indian Snack',available:300},
    {id:3,name:'roti',price:20,description:'A North Indian Breakfast',available:100}
  ];
  constructor() { }
  static getItems():Item[]{
    return this.items;
  }
  static addItem(i:Item):void{
    this.items.push(i);
  }
  static deleteItem(name:string,qty:number){
    let index = this.items.findIndex(x => x.name = name);
    this.items[index].available = this.items[index].available - qty;
    //console.log(this.items)
  }
  static deleteItemById(id:number){
    var i = Number(this.items?.findIndex(x=>x.id === id));
      this.items?.splice(i,1);
  }
}
