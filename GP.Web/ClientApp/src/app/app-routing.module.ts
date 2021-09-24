import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { EmptyLayoutComponent } from './components/empty-layout/empty-layout.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { MainLayoutComponent } from './components/main-layout/main-layout.component';
import { AuthGuardsService } from './services/auth-guards.service';

const NO_LAYOUT_ROUTES: Routes = [
  { path: 'error', loadChildren: () => import('./modules/error-pages/error-pages.module').then(m => m.ErrorPagesModule) },
  { path: '**', redirectTo: '/error/404', pathMatch: 'full' },
];

const MAIN_LAYOUT_ROUTES: Routes = [
  //  { path: '', pathMatch: 'full', redirectTo: 'home-page' },
  //  { path: 'home-pag', loadChildren:'./modules/orders/orders.module#OrdersModule' },
  { path: '', redirectTo: '/orders/menu', pathMatch: 'full' },
  {
    path: 'orders',
    loadChildren: () => import('./modules/orders/orders.module').then(m => m.OrdersModule),

  },
];

const APP_ROUTES: Routes = [
  {
    path: '',
    canLoad: [AuthGuardsService],
    canActivate: [AuthGuardsService],
    component: MainLayoutComponent,
    children: MAIN_LAYOUT_ROUTES,
  },
  {
    path: '',
    component: EmptyLayoutComponent,
    children: NO_LAYOUT_ROUTES
  }
];

@NgModule({
  imports: [
  RouterModule.forRoot(APP_ROUTES, { preloadingStrategy: PreloadAllModules }),
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
