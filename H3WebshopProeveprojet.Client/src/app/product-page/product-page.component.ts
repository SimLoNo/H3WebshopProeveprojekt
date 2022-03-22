import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../_models/product';
import { ProductService } from '../_services/product.service';

@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.scss']
})
export class ProductPageComponent implements OnInit {

  constructor(private productService: ProductService, private route:ActivatedRoute) { }
  product:Product = {id:0,name:'',price:0,discountPercentage:0,categoryId:0};
  productId:number = 0;
  ngOnInit(): void {
    this.route.paramMap
    .subscribe(params => {
      this.productId = Number(params.get('id'));
      this.productService.GetProduct(this.productId)
      .subscribe(x => this.product = x);
    })
  }

}
