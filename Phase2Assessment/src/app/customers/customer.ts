export class Customer {
    id?:number;name?:string;gender?:string;city?:string;phone?:string;uname?:string;password?:string;
    constructor(id?:number,name?:string,gender?:string,city?:string,phone?:string,uname?:string,password?:string){
        this.id = id;
        this.name = name;
        this.gender = gender;
        this.city = city;
        this.phone = phone;
        this.uname = uname;
        this.password = password;
    }
}
