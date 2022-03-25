import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ShirtsComponent } from './shirts/shirts.component';
import { FrontpageComponent } from './frontpage/frontpage.component';
import { ProductComponent } from './admin/product/product.component';
import { FormsModule } from '@angular/forms';
import { ProductPagesComponent } from './product-pages/product-pages.component';
import { CategoryComponent } from './admin/category/category.component';
import { ProductPageComponent } from './product-page/product-page.component';
import { LoginPageComponent } from './login-page/login-page.component';

@NgModule({
  declarations: [
    AppComponent,
    ShirtsComponent,
    FrontpageComponent,
    ProductComponent,
    ProductPagesComponent,
    CategoryComponent,
    ProductPageComponent,
    LoginPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
