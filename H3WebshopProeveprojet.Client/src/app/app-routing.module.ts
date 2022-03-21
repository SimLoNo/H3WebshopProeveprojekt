import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoryComponent } from './admin/category/category.component';
import { ProductComponent } from './admin/product/product.component';
import { FrontpageComponent } from './frontpage/frontpage.component';
import { ProductPagesComponent } from './product-pages/product-pages.component';
import { ShirtsComponent } from './shirts/shirts.component';

const routes: Routes = [
  { path: '', component: FrontpageComponent },
  { path: 'shirts', component: ShirtsComponent },
  { path: 'admin/product', component: ProductComponent },
  { path: 'products/:id', component: ProductPagesComponent },
  { path: 'admin/category', component: CategoryComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
