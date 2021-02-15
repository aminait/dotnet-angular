import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CompanyDetails } from '../_models/company-details';
import { JobDetails } from '../_models/job-details';
import { JobPreview } from '../_models/job-preview';
import { Tag } from '../_models/tag';

@Injectable({
  providedIn: 'root',
})
export class JobsService {
  baseUrl = environment.apiUrl + 'jobs/';

  constructor(private http: HttpClient) {}

  getJobPreviews(): Observable<JobPreview[]> {
    return this.http.get<JobPreview[]>(this.baseUrl);
  }

  getJobPreview(id: number): Observable<JobPreview> {
    return this.http.get<JobPreview>(this.baseUrl + id);
  }

  getJobDetails(id: number): Observable<JobDetails> {
    return this.http.get<JobDetails>(this.baseUrl + id + '/details');
  }

  getJobTags(id: number): Observable<Tag[]> {
    return this.http.get<Tag[]>(this.baseUrl + id + '/tags');
  }

  getCompany(id: number): Observable<CompanyDetails> {
    return this.http.get<CompanyDetails>(this.baseUrl + id + '/company');
  }
}
