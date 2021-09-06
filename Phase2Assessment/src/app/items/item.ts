export class Item {
    id?:number;name?:string;price?:number;description?:string;available?:number;
    constructor(id?:number,name?:string,price?:number,description?:string,available?:number){
        this.id = id;
        this.name = name;
        this.price = price;
        this.description = description;
        this.available = available;
    }
}
