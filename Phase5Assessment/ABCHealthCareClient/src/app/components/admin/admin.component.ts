import { ProductComponent } from './../product/product.component';
import { ProductService } from './../../services/product.service';
import { CategoriesService } from './../../services/categories.service';
import { UserService } from './../../services/user.service';
import { HttpClient } from '@angular/common/http';
import { User } from './../../models/user';
import { Component, OnInit } from '@angular/core';
import { Categories } from 'src/app/models/categories';
import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {
  users : User[];
  categories: Categories[];
  products: Product[];
  showUsers:boolean = true;
  showCategories:boolean = false;
  showProducts:boolean = false;
  categoryToBeAdded:Categories = new Categories();
  productToBeAdded: Product = new Product();
  constructor(private http:HttpClient,
              private userService : UserService,
              private categoriesService : CategoriesService,
              private productService : ProductService) { }

  ngOnInit(): void {
    this.userService.getAllUsers().subscribe(
      usersResponse => {
        this.users = usersResponse;
      }
    );
    this.categoriesService.getAllCategories().subscribe(
      cat => {
        this.categories = cat;
      }
    );
    this.productService.getAllProducts().subscribe(
      productsResponse => {
        this.products = productsResponse;
      }
    )
  }
  displayUsers(){
    this.showUsers = true;
    this.showCategories = false;
    this.showProducts = false;
  }
  displayCategories(){
    this.showUsers = false;
    this.showCategories = true;
    this.showProducts = false;
  }
  displayProducts(){
    this.showUsers = false;
    this.showCategories = false;
    this.showProducts = true;
  }
  addCategory(){
    this.categoriesService.addCategory(this.categoryToBeAdded).subscribe(
      data => {
        this.displayCategories();
      }
    );
  }
  clearAll(){
    this.productToBeAdded = new Product();
  }
  getProductById(){
    this.productService.getSingleProduct(this.productToBeAdded.id).subscribe(
        data => this.productToBeAdded = data
    );
  }
  addProduct(){
    this.productService.addProduct(this.productToBeAdded).subscribe(
      data => {
        this.clearAll();
      }
    );
  }
  editProduct(){
    this.productService.editProduct(this.productToBeAdded).subscribe(
      data =>{
        this.clearAll();
      }
    )
  }
  deleteProduct(){
    this.productService.deleteProduct(this.productToBeAdded.id).subscribe(
      data => this.clearAll()
    );
  }

}
