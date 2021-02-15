import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JobDetails } from 'src/app/_models/job-details';
import { JobPreview } from 'src/app/_models/job-preview';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { JobsService } from 'src/app/_services/jobs.service';

@Component({
  selector: 'app-jobs-saved',
  templateUrl: './jobs-saved.component.html',
  styleUrls: ['./jobs-saved.component.scss'],
})
export class JobsSavedComponent implements OnInit {
  savedJobs: JobPreview[];
  updatedJob: JobDetails | any;
  constructor(
    private jobsService: JobsService,
    private alertify: AlertifyService,
    private router: Router
  ) {
    this.savedJobs = [];
  }

  ngOnInit() {
    this.loadSavedJobs();
  }

  loadSavedJobs() {
    this.jobsService.getSavedJobs().subscribe(
      (savedJobs: JobPreview[]) => {
        this.savedJobs = savedJobs;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  removeSavedJob(savedJob: any) {
    savedJob.isSaved = !savedJob.isSaved;
    this.jobsService
      .toggleSavedJobListing(savedJob.id)
      .subscribe((updates: JobDetails) => {
        this.updatedJob = updates;
        this.alertify.warning(savedJob.title + ' removed');
      });
    this.savedJobs = this.savedJobs.filter(function (val, index, arr) {
      return val.id != savedJob.id;
    });
  }
}
