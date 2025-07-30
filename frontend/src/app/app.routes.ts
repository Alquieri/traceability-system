// src/app/app.routes.ts
import { Routes } from '@angular/router';
import { PartManagement } from './pages/part-management/part-management';
import { MovementRegistration } from './pages/movement-registration/movement-registration';
import { PartHistoryViewer } from './pages/part-history-viewer/part-history-viewer';


export const routes: Routes = [
    { path: 'parts', component: PartManagement },
    { path: 'move', component: MovementRegistration },
    { path: 'history', component: PartHistoryViewer },
    { path: '', redirectTo: '/parts', pathMatch: 'full' }
];
