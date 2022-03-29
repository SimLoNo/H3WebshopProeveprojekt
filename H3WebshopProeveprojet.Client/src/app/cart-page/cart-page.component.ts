import { Component, OnInit } from '@angular/core';
import { AppComponent } from '../app.component';
import { ShoppingCartItem } from '../_models/shoppingCartItem';
import { CartService } from '../_services/cart.service';

@Component({
  selector: 'app-cart-page',
  templateUrl: './cart-page.component.html',
  styleUrls: ['./cart-page.component.scss']
})
export class CartPageComponent implements OnInit {

  shoppingCart: ShoppingCartItem[] = [];
  constructor(private cartService: CartService) { }

  ngOnInit(): void {
    this.shoppingCart = this.cartService.getCart();
    if (this.shoppingCart.length == 0) {
      this.shoppingCart.push({ amount: 2, item: { id: 0, name: 'Test1', price: 10, discountPercentage: 0, categoryId: 0, productImage: 'carisDress' } })
      this.shoppingCart.push({ amount: 1, item: { id: 0, name: 'Dress', price: 10, discountPercentage: 0, categoryId: 0, productImage: 'carisDress' } })
    }
  }

}
