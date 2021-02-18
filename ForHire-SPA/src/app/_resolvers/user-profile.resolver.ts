import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router } from '@angular/router';
import { Observable, of, SchedulerLike } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { UserProfile } from '../_models/user-profile';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';
import { UserService } from '../_services/user.service';

@Injectable()
export class UserProfileResolver implements Resolve<UserProfile> {
  constructor(
    private userService: UserService,
    private router: Router,
    private alertify: AlertifyService,
    private authService: AuthService
  ) {}
  resolve(route: ActivatedRouteSnapshot): Observable<UserProfile> {
    return this.userService.getUser(this.authService.decodedToken.nameid).pipe(
      catchError((error) => {
        this.alertify.error('Problem retrieving');
        this.router.navigate(['/home']);
        console.log(error);
        // tslint:disable-next-line deprecation
        return Observable.throw(error);
      })
    );
  }
}
