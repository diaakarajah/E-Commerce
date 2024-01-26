import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './Auth/AuthGuard';
import { NgModule } from '@angular/core';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'brand', loadChildren: () => import('./brands/brands.module').then(m => m.BrandsModule), canActivate: [AuthGuard] },
  { path: 'category', loadChildren: () => import('./category/category.module').then(m => m.CategoryModule), canActivate: [AuthGuard] },
  { path: 'product', loadChildren: () => import('./product/product.module').then(m => m.ProductModule), canActivate: [AuthGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
