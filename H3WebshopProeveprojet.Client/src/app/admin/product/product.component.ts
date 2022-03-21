import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/_models/category';
import { Product } from 'src/app/_models/product';
import { CategoryService } from 'src/app/_services/category.service';
import { ProductService } from 'src/app/_services/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {

  products: Product[] = [];
  product: Product = { id: 0, name: '', price: 0, discountPercentage: 0, categoryId: 0 };
  categories: Category[] = [];
  message: string = '';

  constructor(private ProductService: ProductService, private CategoryService: CategoryService) { }

  ngOnInit(): void {
    this.ProductService.GetAllProducts()
      .subscribe(x => this.products = x);

    this.CategoryService.getAllCategories()
      .subscribe(x => this.categories = x);

  }

  edit(product: Product): void {
    this.product = product;
    this.message = '';
    console.log(`The product categoryId is: ${product.categoryId}`)
  }

  delete(product: Product): void {
    if (confirm('Are you sure you want to delete this product?')) {
      this.ProductService.DeleteProduct(product.id)
        .subscribe(() => {
          this.products = this.products.filter(x => x.id != product.id);
          this.product = product;
        })
    }
  }

  save(): void {
    if (this.product.id == 0) {
      this.ProductService.AddProduct(this.product)
        .subscribe({
          next: (x) => {
            this.products.push(x);
            this.product = { id: 0, name: '', price: 0, discountPercentage: 0, categoryId: 0 };
          },
          error:(err) =>{
            console.log(err.error);
            this.message = Object.values(err.error.errors).join(", ");
          }
        });
    }
    else {
      this.ProductService.EditProduct(this.product.id, this.product)
        .subscribe({
          error: (err) => {
            console.log(err.error);
            this.message = Object.values(err.error.errors).join(", ");
          },
          complete: () => {
            this.product = { id: 0, name: '', price: 0, discountPercentage: 0, categoryId: 0 };
          }
        })
    }
  }

  cancel(): void {
    this.message='';
    this.product = { id: 0, name: '', price: 0, discountPercentage: 0, categoryId: 0 };
  }
}
