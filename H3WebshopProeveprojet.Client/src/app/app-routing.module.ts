import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductComponent } from './admin/product/product.component';
import { FrontpageComponent } from './frontpage/frontpage.component';
import { ShirtsComponent } from './shirts/shirts.component';

const routes: Routes = [
  { path: '', component: FrontpageComponent },
  { path: 'shirts', component: ShirtsComponent },
  {path: 'admin/product', component:ProductComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
