import { Component, OnInit } from '@angular/core';
import { Category } from '../_models/category';
import { Product } from '../_models/product';
import { CategoryService } from '../_services/category.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { CartService } from '../_services/cart.service';
import { Output, EventEmitter } from '@angular/core';
import { ShoppingCartItem } from '../_models/shoppingCartItem';

@Component({
  selector: 'app-product-pages',
  templateUrl: './product-pages.component.html',
  styleUrls: ['./product-pages.component.scss']
})
export class ProductPagesComponent implements OnInit {

  constructor(private categoryService: CategoryService, private route: ActivatedRoute, private cartService: CartService) { }
  category: Category = { id: 0, categoryName: '', products: [] };
  categoryId: Number = 0;

  ngOnInit(): void {
    this.route.paramMap
      .subscribe(params => {
        this.categoryId = Number(params.get('id'));
        if (this.categoryId != 0) {
          this.categoryService.getCategoryById(this.categoryId)
            .subscribe(x => this.category = x);
        }
      })
  }
  @Output() newCartEvent: EventEmitter<ShoppingCartItem[]> = new EventEmitter<ShoppingCartItem[]>();

  addProductToCart(product: Product) {
    let cartItem: ShoppingCartItem = {
      amount: 1,
      item: product
    };
    console.log(`addProductToCart is running, newCartEvent should fire. Product: ${product.name}, shoppingCartItem: ${cartItem.amount}.`);
    //this.cartService.addToCart(cartItem);
    console.log(cartItem);
    console.log(this.newCartEvent);
    let newCart: ShoppingCartItem[] = this.cartService.addToCart(cartItem);
    console.log("Event variable: " + typeof (this.newCartEvent));
    this.newCartEvent.emit(newCart);
    console.log("addProductToCart is running, newCartEvent is fired.");
  }



}
