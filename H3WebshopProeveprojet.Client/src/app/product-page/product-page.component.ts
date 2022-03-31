import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../_models/product';
import { ShoppingCartItem } from '../_models/shoppingCartItem';
import { CartService } from '../_services/cart.service';
import { ProductService } from '../_services/product.service';

@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.scss']
})
export class ProductPageComponent implements OnInit {

  constructor(private productService: ProductService, private route:ActivatedRoute, private cartService:CartService) { }
  product:Product = {id:0,name:'',price:0,discountPercentage:0,categoryId:0};
  productId:number = 0;
  amount:number = 0;
  ngOnInit(): void {
    this.route.paramMap
    .subscribe(params => {
      this.productId = Number(params.get('id'));
      this.productService.GetProduct(this.productId)
      .subscribe(x => this.product = x);
    })
  }

  addProductToCart(product: Product){
    console.log("The type of amount input is: " + typeof this.amount);
    if (typeof this.amount == "number") {
    let cartItem:ShoppingCartItem = {
      amount:this.amount,
      item:product};
    this.cartService.addToCart(cartItem);
    }
  }

}
