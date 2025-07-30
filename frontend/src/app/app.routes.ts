// src/app/app.routes.ts
import { Routes } from '@angular/router';
import { PartManagementComponent } from './pages/part-management/part-management';

export const routes: Routes = [
    { path: 'parts', component: PartManagementComponent },
    { path: '', redirectTo: '/parts', pathMatch: 'full' }
];
