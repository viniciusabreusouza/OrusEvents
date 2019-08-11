import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, CanActivate, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { LocalStorageService } from '../local-storage.service';

@Injectable({
  providedIn: 'root'
})
export class HomeGuard implements CanActivate  {
  constructor(private router: Router, private localStorageService: LocalStorageService) { }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
      const localToken = this.localStorageService.get('userToken');
      if (localToken !== null && localToken.id !== null) {
        return true;
      } else {
        this.router.navigate(['login']);
      }
  }
}
