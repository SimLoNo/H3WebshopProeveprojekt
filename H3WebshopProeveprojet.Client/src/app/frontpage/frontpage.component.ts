import { Component, OnInit } from '@angular/core';
import { Product } from '../_models/product';
import { ProductService } from '../_services/product.service';
@Component({
  selector: 'app-frontpage',
  templateUrl: './frontpage.component.html',
  styleUrls: ['./frontpage.component.scss']
})
export class FrontpageComponent implements OnInit {

  constructor() { }

  products:Product[] = []
  ngOnInit(): void {
  }

}
