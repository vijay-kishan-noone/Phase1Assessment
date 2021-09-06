import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators} from '@angular/forms';
import {Router} from "@angular/router";

@Component({
  selector: 'app-admin-login',
  templateUrl: './admin-login.component.html',
  styleUrls: ['./admin-login.component.scss']
})
export class AdminLoginComponent implements OnInit {
  userForm:FormGroup;
  invalidLogin:boolean = false;
  constructor(private router: Router) { }
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
    if(this.uname.value=='admin' && this.password.value == 'admin'){
      this.router.navigate(['/admin-home']);
    }
    else
      this.invalidLogin = true;
  }

}
