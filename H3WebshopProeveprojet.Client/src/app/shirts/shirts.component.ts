import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Category } from '../_models/category';
import { Product } from '../_models/product';
import { CategoryService } from '../_services/category.service';
import { ProductService } from '../_services/product.service';

@Component({
  selector: 'app-shirts',
  templateUrl: './shirts.component.html',
  styleUrls: ['./shirts.component.scss']
})
export class ShirtsComponent implements OnInit {

  products: Product[] = [];
  product: Product = { id: 0, name: '', price: 0, discountPercentage: 0, categoryId: 0 };
  categories: Category[] = [];

  constructor(private ProductService: ProductService, private CategoryService: CategoryService) { }

  ngOnInit(): void {
    this.ProductService.GetAllProducts()
      .subscribe(x => this.products = x);

    this.CategoryService.getAllCategories()
    .subscribe(x => this.categories = x);
    
  }

  edit(product: Product): void {
    this.product = product;
    console.log(`The product categoryId is: ${product.categoryId}`)
  }

  delete(product: Product): void {
    if(confirm('Are you sure you want to delete this product?')){
      //Delete the product.
    }
  }

}
