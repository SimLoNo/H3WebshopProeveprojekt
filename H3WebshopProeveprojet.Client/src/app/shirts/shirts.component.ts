import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Product } from '../_models/product';
import { ProductService } from '../_services/product.service';

@Component({
  selector: 'app-shirts',
  templateUrl: './shirts.component.html',
  styleUrls: ['./shirts.component.scss']
})
export class ShirtsComponent implements OnInit {

  constructor(private ProductService:ProductService) { }

  products: Product[] = []

  ngOnInit(): void {
    //this.products.push({id:1,name:"Kingsbridge Scarlet",price:10,discountPrice:0,categoryId:1})
    //this.products.push({id:1,name:"Pallageto",price:200,discountPrice:0,categoryId:2})
    this.ProductService.GetAllProducts()
    .subscribe(x => this.products = x);
  }

}
