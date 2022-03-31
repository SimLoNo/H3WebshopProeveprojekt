import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/_models/category';
import { CategoryService } from 'src/app/_services/category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent implements OnInit {

  constructor(private categoryService: CategoryService) { }

  categories: Category[] = [];
  category: Category = { id: 0, categoryName: '', products: [] };
  message: string = '';

  ngOnInit(): void {

    this.categoryService.getAllCategories()
      .subscribe(x => this.categories = x);

  }

  edit(category: Category): void {
    this.category = category;
    this.message = '';
  }

  delete(category: Category): void {
    if (confirm('Are you sure you want to delete this category?')) {
      this.categoryService.deleteCategory(category.id)
        .subscribe(() => {
          this.categories = this.categories.filter(x => x.id != category.id);
          this.category = category;
        })
    }
  }

  save(): void {
    if (this.category.id == 0) {
      this.categoryService.addCategory(this.category)
        .subscribe({
          next: (x) => {
            this.categories.push(x);
            this.category = { id: 0, categoryName: '', products: [] };
          },
          error: (err) => {
            console.log(err.error);
            this.message = Object.values(err.error.errors).join(", ");
          }
        });
    }
    else {
      this.categoryService.editCategory(this.category.id, this.category)
        .subscribe({
          error: (err) => {
            console.log(err.error);
            this.message = Object.values(err.error.errors).join(", ");
          },
          complete: () => {
            this.category = { id: 0, categoryName: '', products: [] };
          }
        })
    }
  }

  cancel(): void {
    this.message = '';
    this.category = { id: 0, categoryName: '', products: [] };
  }

}
