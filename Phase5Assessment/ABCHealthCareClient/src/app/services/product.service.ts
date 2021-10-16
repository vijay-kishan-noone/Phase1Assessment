import {Injectable} from '@angular/core';
import {HttpClient,HttpHeaders} from "@angular/common/http";
import {environment} from "../../environments/environment";
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private url = environment.serverURL;

  constructor(private http: HttpClient) {
  }

  getAllProducts(limitOfResults=10){
    return this.http.get<Product[]>(this.url + 'products', {
      params: {
        limit: limitOfResults.toString()
      }
    });
  }
  getSingleProduct(id: number){
    return this.http.get<Product>(this.url + 'products/' + id);
  }

  getProductsFromCategory(catName: string){
    return this.http.get<Product[]>(this.url + 'products?categoryName=' + catName);
  }
  addProduct(product : Product){
    return this.http.post<Product>(this.url + 'products/',product,{
      headers : new HttpHeaders({
        'Content-Type':'application/json'
      })
    });
  }
  editProduct(product : Product){
    return this.http.put(this.url + 'products/'+`${product.id}`,product,{
      headers : new HttpHeaders({
        'Content-Type':'application/json'
      })
    });
  }
  deleteProduct(id:number){
    return this.http.delete(this.url + 'products/' + id);
  }
}
