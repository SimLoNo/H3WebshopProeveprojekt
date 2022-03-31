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
    this.shoppingCart.forEach(item => {
      console.log(item.item.name);
    })
    // if (this.shoppingCart.length == 0) {
    //   this.shoppingCart.push({ amount: 2, item: { id: 0, name: 'Test1', price: 10, discountPercentage: 0, categoryId: 0, productImage: 'carisDress' } })
    //   this.shoppingCart.push({ amount: 1, item: { id: 0, name: 'Dress', price: 10, discountPercentage: 0, categoryId: 0, productImage: 'carisDress' } })
    // }
  }

  deleteItem(id:number){
    console.log("Type of Id: " + typeof id + " id: " + id);
    this.shoppingCart = this.cartService.removeItemFromCart(id);
    this.shoppingCart.forEach(item => {
      console.log(item.item.name);
    })

  }
  updateProductToCart(){
    this.shoppingCart.forEach(item => {
      if (item.amount <= 0) {
        console.log("id is: " + item.item.id + " name is: " + item.item.name);
      }
    });
    this.shoppingCart = this.cartService.updateToCart(this.shoppingCart);
  }

}
