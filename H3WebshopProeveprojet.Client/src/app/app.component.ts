import { Component } from '@angular/core';
import { Category } from './_models/category';
import { CategoryService } from './_services/category.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'H3WebshopProeveprojekt-Client';

  constructor(private categoryService:CategoryService) { }

  categories:Category[] = [];
  ngOnInit(): void {
    this.categoryService.getAllCategories()
    .subscribe(x => {
      this.categories = x;
      console.log(this.categories);
      console.log(x);
    });
  }
}
