import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PessoaServiceService {
  private apiUrl = 'http://localhost:7026/api/Pessoa'; 

  constructor(private http: HttpClient) { }


  getPessoas(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);  
  }

  getPessoaById(id: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${id}`);  
  }

  createPessoa(pessoa: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, pessoa); 
  }

  updatePessoa(pessoa: any): Observable<any> {
    return this.http.put<any>(this.apiUrl, pessoa);  
  }

  deletePessoa(id: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/${id}`); 
  }
}
