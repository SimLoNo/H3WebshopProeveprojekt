import { Component, OnInit } from '@angular/core';
import { Product } from '../_models/product';
import { ProductService } from '../_services/product.service';
@Component({
  selector: 'app-frontpage',
  templateUrl: './frontpage.component.html',
  styleUrls: ['./frontpage.component.scss']
})
export class FrontpageComponent implements OnInit {

  constructor(private productService:ProductService) { }
  products: Product[] = [];
  product: Product = { id: 0, name: '', price: 0, discountPercentage: 0, categoryId: 0 };
 
  ngOnInit(): void {
    this.productService.GetAllProducts()
    .subscribe(x => this.products = x);
  }

}
