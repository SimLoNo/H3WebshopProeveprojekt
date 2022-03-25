import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Account } from '../_models/account';
import { Jwt } from '../_models/jwt';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private apiUrl = environment.apiUrl + 'JwtAuthentication';
  
  private httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  };
  constructor(private http:HttpClient) { }

  authenticate(account:Account):Observable<Jwt>{ //:Observable<string>
    return this.http.post<Jwt>(this.apiUrl,
      account,
      this.httpOptions);
  }
}
