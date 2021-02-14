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
    redirectTo: '',
    pathMatch: 'full',
  },
];
