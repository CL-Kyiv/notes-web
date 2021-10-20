import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { WheatherComponent } from './wheather/wheather.component';

const routes: Routes = [
  {path:'weatherforecast', component:WheatherComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
