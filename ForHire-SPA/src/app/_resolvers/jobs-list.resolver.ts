import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { JobPreview } from '../_models/job-preview';
import { AlertifyService } from '../_services/alertify.service';
import { JobsService } from '../_services/jobs.service';

@Injectable()
export class JobsListResolver implements Resolve<JobPreview[]> {
  constructor(
    private jobsService: JobsService,
    private router: Router,
    private alertify: AlertifyService
  ) {}
  resolve(route: ActivatedRouteSnapshot): Observable<JobPreview[]> {
    return this.jobsService.getJobPreviews().pipe(
      catchError((error) => {
        this.alertify.error('Problem retrieving');
        this.router.navigate(['/jobs']);
        return Observable.throw(error);
      })
    );
  }
}
