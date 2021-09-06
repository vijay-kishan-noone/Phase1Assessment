import { CustomerService } from './../customers/customer.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators} from '@angular/forms';
import { Customer } from '../customers/customer';
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  userForm:FormGroup;
  customers:Customer[];
  invalidLogin:boolean = false;

  constructor(private router: Router) {
    this.customers = CustomerService.getCustomers();
   }
  get uname(){
    return this.userForm.get('uname');
  }
  get password(){
    return this.userForm.get('password');
  }

  ngOnInit(): void {
      this.userForm = new FormGroup({
      uname:new FormControl('',Validators.required),
      password:new FormControl('',Validators.required)
    });
  }

  submit(){
    if(this.customers.find(x=>(x.uname == this.uname.value && x.password== this.password.value))){
      this.router.navigate(['/home']);
    }
    else
      this.invalidLogin = true;
  }
}
