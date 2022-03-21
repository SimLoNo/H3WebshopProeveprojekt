import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Category } from '../_models/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private apiUrl = environment.apiUrl + "category";

  private httpOptions = {
    Headers: new HttpHeaders({'Content-Type': 'application/json'})
  };

  constructor(private Http:HttpClient) { }

  getAllCategories():Observable<Category[]>{
    return this.Http.get<Category[]>(
      this.apiUrl);
  }

  getCategoryById(categoryId:Number):Observable<Category>{
    return this.Http.get<Category>(
      `${this.apiUrl}/${categoryId}`);
  }
}
