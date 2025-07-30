import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Api, Part, Station, MovementPayload } from '../../services/api';

@Component({
  selector: 'app-movement-registration',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './movement-registration.html',
  styleUrls: ['./movement-registration.css']
})
export class MovementRegistration implements OnInit {
  parts: Part[] = [];
  stations: Station[] = [];

  constructor(private api: Api) {}

  ngOnInit(): void {
    this.api.getParts().subscribe(data => {
      this.parts = data.filter(p => p.status !== 'Finalizada');
    });

    this.api.getStations().subscribe(data => {
      this.stations = data;
    });
  }

  movePart(partId: string, stationId: string, responsible: string): void {
    if (!partId || !stationId || !responsible.trim()) {
      alert('Por favor, selecione uma peça, uma estação e preencha o responsável.');
      return;
    }

    const payload: MovementPayload = { partId, stationId, responsible };

    this.api.createMovement(payload).subscribe({
      next: () => {
        alert('Movimentação registrada com sucesso!');
        this.ngOnInit();
      },
      error: (err) => {
        alert(`Erro ao registrar movimentação: ${err.error.message || 'Verifique o console.'}`);
        console.error(err);
      }
    });
  }
}
