import { Component, OnInit } from '@angular/core';
import { Api, Part } from '../../services/api';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-part-management',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './part-management.html',
  styleUrls: ['./part-management.css']
})
export class PartManagementComponent implements OnInit {
  parts: Part[] = [];

  constructor(private api: Api) { }

  ngOnInit(): void {
    this.api.getParts().subscribe({
      next: (data) => {
        this.parts = data;
        console.log('Peças carregadas com sucesso:', this.parts);
      },
      error: (err) => {
        console.error('Ocorreu um erro ao carregar as peças:', err);
      }
    });
  }
}
