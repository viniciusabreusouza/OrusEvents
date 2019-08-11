import { Routes, RouterModule } from "@angular/router";
import { AppComponent } from "./app.component";
import { HomeComponent } from "./home/home.component";
import { NgModule } from "@angular/core";
import { HomeGuard } from "./services/auth/home.guard";

const routes: Routes = [
    //{ path: 'login', component: LoginComponent },
    //{ path: 'registrar', component: RegistrarComponent },
    {
      path: '', component: HomeComponent, pathMatch: 'full',
      children: [
        { path: '', redirectTo: 'home', pathMatch: 'full', canActivate: [HomeGuard] },
        { path: 'home', component: HomeComponent, canActivate: [HomeGuard] },
      ]
    }
  ];
  @NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }
