import { Component, OnInit, TemplateRef } from '@angular/core';
import { JobPreview } from 'src/app/_models/job-preview';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { JobsService } from 'src/app/_services/jobs.service';
import { JobDetails } from 'src/app/_models/job-details';
import { CompanyDetails } from 'src/app/_models/company-details';

import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-jobs-list',
  templateUrl: './jobs-list.component.html',
  styleUrls: ['./jobs-list.component.scss'],
})
export class JobsListComponent implements OnInit {
  jobs: JobPreview[];
  selectedJob: any;
  showModal: boolean = false;
  jobDetails!: JobDetails;
  companyDetails!: CompanyDetails;
  modalRef!: BsModalRef;
  updatedJob!: JobDetails;

  constructor(
    private jobsService: JobsService,
    private alertify: AlertifyService,
    private modalService: BsModalService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.jobs = [];
  }

  ngOnInit() {
    this.route.data.subscribe((data) => {
      this.jobs = data['jobs'];
    });
  }

  // loadJobPreviews() {
  //   this.jobsService.getJobPreviews().subscribe(
  //     (jobs: JobPreview[]) => {
  //       this.jobs = jobs;
  //     },
  //     (error) => {
  //       this.alertify.error(error);
  //     }
  //   );
  // }

  getJobDetails(job: any) {
    job.isExpanded = !job.isExpanded;
    this.jobsService.getJobDetails(job.id).subscribe(
      (details: JobDetails) => {
        this.jobDetails = details;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  getCompanyByJobId(job: any, id: number, template: TemplateRef<any>) {
    this.showModal = true;
    this.jobsService.getCompany(id).subscribe(
      (details: CompanyDetails) => {
        this.companyDetails = details;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
    this.modalRef = this.modalService.show(template);
  }

  // showApplicationModal(jobId: number) {

  // }
  goToLink(url: string) {
    window.open(url, '_blank');
  }

  toggleSaved(job: any) {
    // loading API is slow, so trigger appearance change
    job.isSaved = !job.isSaved;
    this.jobsService
      .toggleSavedJobListing(job.id)
      .subscribe((updates: JobDetails) => {
        this.updatedJob = updates;
      });
    if (job.isSaved) {
      this.alertify.success('Adding ' + job.title + ' to Saved Jobs');
    } else {
      this.alertify.warning(job.title + ' has been removed from Saved Jobs');
    }
  }

  // toggleHidden(job: any) {
  //   console.log('inside hidden: ', job.isHidden);
  //   job.isHidden = !job.isHidden;
  //   console.log('inside hidden after: ', job.isHidden);
  // }

  hideModal() {
    this.showModal = false;
  }

  delay(ms: number) {
    return new Promise((resolve) => setTimeout(resolve, ms));
  }
}
