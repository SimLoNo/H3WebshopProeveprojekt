import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Product } from '../_models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private apiUrl = environment.apiUrl + 'Product';

  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  constructor(private http: HttpClient) { }

  GetAllProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.apiUrl);
  }

  GetProduct(productId: number): Observable<Product> {
    return this.http.get<Product>(`${this.apiUrl}/${productId}`);
  }

  AddAuthor(product:Product):Observable<Product>{
    return this.http.post<Product>(this.apiUrl, product, this.httpOptions)
  }
}
