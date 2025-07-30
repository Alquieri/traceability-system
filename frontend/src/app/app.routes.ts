// src/app/app.routes.ts
import { Routes } from '@angular/router';
import { PartManagement } from './pages/part-management/part-management';
import { MovementRegistration } from './pages/movement-registration/movement-registration'; 

export const routes: Routes = [
    { path: 'parts', component: PartManagement },
    { path: 'move', component: MovementRegistration },
    { path: '', redirectTo: '/parts', pathMatch: 'full' }
];
