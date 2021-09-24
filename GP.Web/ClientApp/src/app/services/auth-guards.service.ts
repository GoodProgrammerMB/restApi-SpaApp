import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, CanActivateChild, CanLoad, Route, Router, RouterStateSnapshot } from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class AuthGuardsService implements CanActivate, CanActivateChild, CanLoad {

  constructor( private router: Router) { }

  canLoad(route: Route): boolean {
    return true;//this.authService.isAuthenticated();
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    // if (!this.authService.isAuthenticated()) {
    //   this.authService.storeUnaturizeRoute(state.url);
    //   this.router.navigate(['/auth/login']);
    //   return false;
    // }
    // if (!this.authService.hasAccess(route.data.expectedRoles)) {
    //   this.router.navigate(['/error/401']);
    //   return false;
    // }
    return true;
  }

  canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    return this.canActivate(childRoute, state);
  }
}
