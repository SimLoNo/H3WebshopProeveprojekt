import { Component, OnInit } from '@angular/core';
import { Category } from '../_models/category';
import { Product } from '../_models/product';
import { CategoryService } from '../_services/category.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-product-pages',
  templateUrl: './product-pages.component.html',
  styleUrls: ['./product-pages.component.scss']
})
export class ProductPagesComponent implements OnInit {

  constructor(private categoryService:CategoryService, private route:ActivatedRoute) { }
  category: Category = { id: 0, categoryName: '', products: [] };
  categoryId:Number = 0;
 
  ngOnInit(): void {
    this.route.paramMap
    .subscribe(params => {
      this.categoryId = Number(params.get('id'));
      this.categoryService.getCategoryById(this.categoryId)
    .subscribe(x => this.category = x);
    })
    
  }


}