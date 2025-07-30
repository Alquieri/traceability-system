// src/app/services/api.service.ts

import { Injectable } from '@angular/core'; 
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

// Interface para o modelo de dados da Peça
export interface Part {
  id: string;
  name: string;
  status: string;
  currentStationId: string | null;
}

@Injectable({
  providedIn: 'root'
})
export class Api {
  private readonly apiUrl = 'http://localhost:5175';

  constructor(private http: HttpClient) { }

  getParts(): Observable<Part[]> {
    return this.http.get<Part[]>(`${this.apiUrl}/api/Part`);
  }

 
  createPart(partName: string): Observable<Part> {
    const body = { name: partName };
    return this.http.post<Part>(`${this.apiUrl}/api/Part`, body);
  }


}