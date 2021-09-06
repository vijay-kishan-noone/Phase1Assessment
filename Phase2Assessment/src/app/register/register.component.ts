import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormArray, Validator, Validators} from '@angular/forms';
import { CustomerService } from '../customers/customer.service';
import { Customer } from '../customers/customer';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  userForm:FormGroup;
  constructor(private router:Router) { }
  get uname(){
    return this.userForm.get('uname');
  }
  get password(){
    return this.userForm.get('password');
  }
  get id(){
    return this.userForm.get('id');
  }
  get name(){
    return this.userForm.get('name');
  }
  get gender(){
    return this.userForm.get('gender');
  }
  get city(){
    return this.userForm.get('city');
  }
  get phone(){
    return this.userForm.get('phone');
  }
  ngOnInit(): void {
    this.userForm = new FormGroup({
      id:new FormControl('',Validators.required),
      name:new FormControl('',Validators.required),
      gender:new FormControl('',Validators.required),
      city:new FormControl('',Validators.required),
      phone:new FormControl('',Validators.required),
      uname:new FormControl('',Validators.required),
      password:new FormControl('',Validators.required)
    });
  }
  submit(){
    let id = this.userForm.get('id').value;
    let name = this.userForm.get('name').value;
    let gender = this.userForm.get('gender').value;
    let city = this.userForm.get('city').value;
    let phone = this.userForm.get('phone').value;
    let uname = this.userForm.get('uname').value;
    let password = this.userForm.get('password').value;
    CustomerService.addCustomer(new Customer(id,name,gender,city,phone,uname,password));
    this.router.navigate(['/login']);
  }
}
