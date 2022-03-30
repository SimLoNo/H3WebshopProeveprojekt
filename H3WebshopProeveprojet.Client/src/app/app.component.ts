import { Component } from '@angular/core';
import { Category } from './_models/category';
import { ShoppingCartItem } from './_models/shoppingCartItem';
import { CartService } from './_services/cart.service';
import { CategoryService } from './_services/category.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'H3WebshopProeveprojekt-Client';

  constructor(private categoryService:CategoryService, private cartService:CartService) { }

shoppingCart:ShoppingCartItem[] = [];
  categories:Category[] = [];
  ngOnInit(): void {
    this.categoryService.getAllCategories()
    .subscribe(x => {
      this.categories = x;
      console.log(this.categories);
      console.log(x);
    });
    this.shoppingCart = this.cartService.getCart();
    // Shopping cart test data.
    // this.shoppingCart.push({amount:2,item:{id:0,name:'Test1',price:10,discountPercentage:0,categoryId:0,productImage:'carisDress'}})
    // this.shoppingCart.push({amount:1,item:{id:0,name:'Dress',price:10,discountPercentage:0,categoryId:0,productImage:'carisDress'}})
  }

  updateCart(){ //item:ShoppingCartItem
    console.log("updateCart is running.");
    //this.shoppingCart.push(item); // = this.cartService.addToCart(item); // item;

  }
}
