import { isNgTemplate } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { Product } from '../_models/product';
import { ShoppingCartItem } from '../_models/shoppingCartItem';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private cartName = "folletShopCart";
  private cart: ShoppingCartItem[] = [];

  constructor() { }


  getCart(): ShoppingCartItem[] {
    this.cart = JSON.parse(localStorage.getItem(this.cartName) || "[]");
    return this.cart
  }

  saveCart(): void {
    localStorage.setItem(this.cartName, JSON.stringify(this.cart));
  }

  addToCart(newItem:ShoppingCartItem): ShoppingCartItem[] {
    this.getCart();

    let productFound = false;

    this.cart.forEach(cartItem => {
      if (cartItem.item.id == newItem.item.id) {
        cartItem.amount += newItem.amount;
        productFound = true;

        if (cartItem.amount <= 0) {
          this.removeItemFromCart(newItem.item.id);
        }
      }
    })
    if (!productFound) {
      this.cart.push(newItem);
    }
    this.saveCart();
    return this.cart;
  }

  removeItemFromCart(id: number): ShoppingCartItem[] {
    this.getCart();
    this.cart = this.cart.filter(cartItem => cartItem.item.id !== id);
    this.saveCart;
    return this.cart;
  }
}
