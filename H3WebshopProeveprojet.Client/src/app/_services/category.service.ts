import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Category } from '../_models/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private apiUrl = environment.apiUrl + 'category';

  private httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  };

  constructor(private http:HttpClient) { }

  getAllCategories():Observable<Category[]>{
    return this.http.get<Category[]>(
      this.apiUrl);
  }

  getCategoryById(categoryId:Number):Observable<Category>{
    return this.http.get<Category>(
      `${this.apiUrl}/${categoryId}`);
  }
  addCategory(category:Category):Observable<Category>{
    return this.http.post<Category>(
      this.apiUrl,
      category,
      this.httpOptions);
  }

  editCategory(categoryId: number, category: Category): Observable<Category> {
    return this.http.put<Category>(
      `${this.apiUrl}/${categoryId}`,
       category, 
       this.httpOptions);

  }

  deleteCategory(categoryId: Number): Observable<Category> {
    return this.http.delete<Category>(
      `${this.apiUrl}/${categoryId}`,
       this.httpOptions);

  }
}
