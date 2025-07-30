import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

// --- INTERFACES ---
export interface Part {
  id: string;
  name: string;
  status: string;
  currentStationId: string | null;
}

export interface Station {
  id: string;
  name: string;
  number: number;
}

export interface MovementPayload {
  partId: string;
  destinationStationId : string;
  responsible: string;
}

export interface Movement {
  timestamp: Date;
  originStationName: string;
  destinationStationName: string;
  responsible: string;
}

@Injectable({
  providedIn: 'root'
})
export class Api {
  private readonly apiUrl = 'http://localhost:5175';

  constructor(private http: HttpClient) { }

  // --- MÉTODOS DE PEÇA ---
  getParts(): Observable<Part[]> {
    return this.http.get<Part[]>(`${this.apiUrl}/api/Part`);
  }
  createPart(partName: string): Observable<Part> {
    const body = { name: partName };
    return this.http.post<Part>(`${this.apiUrl}/api/Part`, body);
  }

  // --- MÉTODOS DE ESTAÇÃO E MOVIMENTO ---
  getStations(): Observable<Station[]> {
    return this.http.get<Station[]>(`${this.apiUrl}/api/Station`);
  }
  createMovement(payload: MovementPayload): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/api/Movement`, payload);
  }

  // --- MÉTODO DE HISTÓRICO ---
  getHistoryByPartId(partId: string): Observable<Movement[]> {
    return this.http.get<Movement[]>(`${this.apiUrl}/api/Movement/part/${partId}`);
  }
}