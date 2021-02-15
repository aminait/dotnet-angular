import {
  Component,
  EventEmitter,
  OnInit,
  Output,
  TemplateRef,
} from '@angular/core';
import { JobPreview } from 'src/app/_models/job-preview';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { JobsService } from 'src/app/_services/jobs.service';
import { JobDetails } from 'src/app/_models/job-details';
import { CompanyDetails } from 'src/app/_models/company-details';

import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-jobs-list',
  templateUrl: './jobs-list.component.html',
  styleUrls: ['./jobs-list.component.scss'],
})
export class JobsListComponent implements OnInit {
  // @Output() savedJobChild = new EventEmitter();

  jobs: JobPreview[];
  selectedJob: any;
  showModal: boolean = false;
  jobDetails: JobDetails | any;
  companyDetails: CompanyDetails | any;
  modalRef: BsModalRef | any;
  updatedJob: JobDetails | any;
  // details: JobDetails | null;
  // expandedText: string;
  // bsModalRef: BsModalRef;

  constructor(
    private jobsService: JobsService,
    private alertify: AlertifyService,
    private modalService: BsModalService,
    private router: RouterModule
  ) {
    this.jobs = [];
  }

  ngOnInit() {
    this.loadJobPreviews();
  }

  loadJobPreviews() {
    this.jobsService.getJobPreviews().subscribe(
      (jobs: JobPreview[]) => {
        this.jobs = jobs;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  getJobDetails(job: any) {
    // console.log('INSIDE JOB DETAILS, before expanded val: ', job.isExpanded);
    job.isExpanded = !job.isExpanded;
    // isExpanded = !isExpanded;
    // console.log('INSIDE JOB DETAILS, after expanded val: ', job.isExpanded);
    this.jobsService.getJobDetails(job.id).subscribe(
      (details: JobDetails) => {
        this.jobDetails = details;
        // console.log('Associated details: ', this.jobDetails.seniority);
      },
      (error) => {
        this.alertify.error(error);
      }
    );
    // return isExpanded;
    // this.modalRef = this.modalService.show(template);
  }

  getCompanyByJobId(job: any, id: number, template: TemplateRef<any>) {
    this.showModal = true;
    console.log('Modal Boolean value', this.showModal);
    console.log('logging job: ', job);
    console.log('logging title: ', job.title);

    this.jobsService.getCompany(id).subscribe(
      (details: CompanyDetails) => {
        this.companyDetails = details;
        console.log('Associated details: ', this.companyDetails.tagline);
      },
      (error) => {
        this.alertify.error(error);
      }
    );
    this.modalRef = this.modalService.show(template);
  }
  showApplicationModal(jobId: number) {}

  toggleSaved(job: any) {
    console.log('inside saved: ', job.isSaved);
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
    // this.savedJobChild.emit(this.updatedJob);
  }
  // toggleHidden(job: any) {
  //   console.log('inside hidden: ', job.isHidden);
  //   job.isHidden = !job.isHidden;
  //   console.log('inside hidden after: ', job.isHidden);
  // }

  //  openModalWithComponent() {
  //   await this.delay(2000);
  //   console.log('inside open modal with component');
  //   console.log(
  //     'from inside this blessed f, lets see details:',
  //     this.jobDetails
  //   );
  //   this.bsModalRef = this.modalService.show(this.jobDetails);
  //   this.bsModalRef.content.closeBtnName = 'Close';
  // }

  hideModal() {
    this.showModal = false;
  }

  delay(ms: number) {
    return new Promise((resolve) => setTimeout(resolve, ms));
  }

  // getJobDetails(index: number) {
  //   this.jobsService.getJobDetails(index).subscribe(
  //     (details: JobDetails) => {
  //       return details;
  //     },
  //     (error) => {
  //       this.alertify.error(error);
  //     }
  //   );
  // }

  // expandJobDetails(index) {
  //   this.jobsService.getJobDetails(this.jobs[index + 1]);

  //   this.bsModalRef = this.bsModalService.show(ModalDetailsComponent);
  //   this.bsModalRef.content.event.subscribe((result) => {
  //     if (result == 'OK') {
  //       setTimeout(() => {
  //         this.loadJobPreviews();
  //       }, 5000);
  //     }
  //   });
}
