import { Component, OnInit } from '@angular/core';
import { Product } from '../_models/product';
import { ShoppingCartItem } from '../_models/shoppingCartItem';
import { CartService } from '../_services/cart.service';
import { ProductService } from '../_services/product.service';
@Component({
  selector: 'app-frontpage',
  templateUrl: './frontpage.component.html',
  styleUrls: ['./frontpage.component.scss']
})
export class FrontpageComponent implements OnInit {

  constructor(private productService: ProductService, private cartService: CartService) { }
  products: Product[] = [];
  product: Product = { id: 0, name: '', price: 0, discountPercentage: 0, categoryId: 0 };

  ngOnInit(): void {
    this.productService.GetAllProducts()
      .subscribe(x => this.products = x);
  }

  addProductToCart(product: Product) {
    let cartItem: ShoppingCartItem = {
      amount: 1,
      item: product
    };
    this.cartService.addToCart(cartItem);
  }

}
