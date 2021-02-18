import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { JobDetails } from '../_models/job-details';
import { JobPreview } from '../_models/job-preview';
import { AlertifyService } from '../_services/alertify.service';
import { JobsService } from '../_services/jobs.service';

@Injectable()
export class JobDetailsResolver implements Resolve<JobDetails> {
  constructor(
    private jobsService: JobsService,
    private router: Router,
    private alertify: AlertifyService
  ) {}
  resolve(route: ActivatedRouteSnapshot): Observable<JobDetails> {
    return this.jobsService.getJobDetails(route.params['id']).pipe(
      catchError((error) => {
        this.alertify.error('Problem retrieving');
        this.router.navigate(['/jobs']);
        return Observable.throw(error);
        // return of(null);
      })
    );
  }
}
