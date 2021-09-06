import { ItemsService } from './../items/items.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-admin-home',
  templateUrl: './admin-home.component.html',
  styleUrls: ['./admin-home.component.scss']
})
export class AdminHomeComponent implements OnInit {
  changePassword:boolean = false;
  addItems:boolean = false;
  deleteItems:boolean = false;
  saveItem:boolean = false;
  deleteId:number = 0;
  userForm:FormGroup;
  constructor() { }
  get id(){
    return this.userForm.get('id');
  }
  get name(){
    return this.userForm.get('name');
  }
  get description(){
    return this.userForm.get('description');
  }
  get price(){
    return this.userForm.get('price');
  }
  get available(){
    return this.userForm.get('available');
  }
  ngOnInit(): void {
    this.userForm = new FormGroup({
      id:new FormControl('',Validators.required),
      name:new FormControl('',Validators.required),
      price:new FormControl('',Validators.required),
      description:new FormControl('',Validators.required),
      available:new FormControl('',Validators.required),
    });
  }
  submit(){
    this.addItems = false;
    this.saveItem = true;
  }
  deleteItem(id:number){
    this.deleteItems = false;
    ItemsService.deleteItemById(id);
  }
}
