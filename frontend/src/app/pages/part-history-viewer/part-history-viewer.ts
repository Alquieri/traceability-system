import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Api, Movement, Part } from '../../services/api';

@Component({
  selector: 'app-part-history-viewer',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './part-history-viewer.html',
  styleUrls: ['./part-history-viewer.css']
})
export class PartHistoryViewer implements OnInit {
  history: Movement[] = [];
  parts: Part[] = [];
  isLoading = false;
  searched = false;

  constructor(private api: Api) {}

  ngOnInit(): void {
    // Carrega as peças para popular o dropdown de seleção
    this.api.getParts().subscribe(data => this.parts = data);
  }

  searchHistory(partId: string): void {
    if (!partId) {
      this.searched = false;
      this.history = [];
      return;
    }
    this.isLoading = true;
    this.searched = true;
    this.history = [];

    this.api.getHistoryByPartId(partId).subscribe({
      next: (data) => {
        this.history = data;
        this.isLoading = false;
      },
      error: (err) => {
        console.error('Erro ao buscar histórico:', err);
        this.isLoading = false;
      }
    });
  }
}