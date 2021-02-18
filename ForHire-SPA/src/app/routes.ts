import { Routes } from '@angular/router';
import { HomeUserComponent } from './home-user/home-user.component';
import { HomeComponent } from './home/home.component';
import { AppliedJobsComponent } from './applied-jobs/applied-jobs.component';
import { JobsListComponent } from './jobs/jobs-list/jobs-list.component';
import { LoginComponent } from './login/login.component';
import { MessagesComponent } from './messages/messages.component';
import { NotifsComponent } from './notifs/notifs.component';
import { SignupComponent } from './signup/signup.component';
import { AuthGuard } from './_guards/auth.guard';
import { JobsSavedComponent } from './jobs/jobs-saved/jobs-saved.component';
import { JobsListResolver } from './_resolvers/jobs-list.resolver';
import { Component } from '@angular/core';
import { NotFoundComponent } from './not-found/not-found.component';

@Component({ template: '' })
export class EmptyComponent {}

export const appRoutes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'home',
    component: HomeUserComponent,
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'signup',
    component: SignupComponent,
  },
  {
    path: 'jobs',
    component: JobsListComponent,
    resolve: { jobs: JobsListResolver },
  },
  {
    path: 'saved',
    component: JobsSavedComponent,
  },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {
        path: 'jobs-applied',
        component: AppliedJobsComponent,
      },
      {
        path: 'messages',
        component: MessagesComponent,
      },
      {
        path: 'notifications',
        component: NotifsComponent,
      },
    ],
  },
  {
    path: '**',
    redirectTo: 'not-found',
    pathMatch: 'full',
  },
  {
    path: 'not-found',
    component: NotFoundComponent,
  },
  // {
  //   path: 'externalRedirect',
  //   canActivate: [externalUrlProvider],
  //   component: EmptyComponent,
  //   url: externalUrlProvider,
  // },
];
