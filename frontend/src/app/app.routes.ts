// src/app/app.routes.ts
import { Routes } from '@angular/router';
import { PartManagement } from './pages/part-management/part-management';

export const routes: Routes = [
    { path: 'parts', component: PartManagement },
    { path: '', redirectTo: '/parts', pathMatch: 'full' }
];
