import {Product} from "./product";

export class CartModelServer {
  total: number;
  data: [{
    product: Product,
    numInCart: number
  }];
}

export class CartModelPublic {
  total: number;
  prodData: [{
    id: number,
    inCart: number
  }]
}