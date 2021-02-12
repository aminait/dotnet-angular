import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { JobsAppliedComponent } from './jobs-applied/jobs-applied.component';
import { JobsListComponent } from './jobs-list/jobs-list.component';
import { LoginComponent } from './login/login.component';
import { MessagesComponent } from './messages/messages.component';
import { NotifsComponent } from './notifs/notifs.component';
import { SignupComponent } from './signup/signup.component';

export const appRoutes: Routes = [
  {
    path: 'home',
    component: HomeComponent,
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
    path: 'jobs-applied',
    component: JobsAppliedComponent,
  },
  {
    path: 'messages',
    component: MessagesComponent,
  },
  {
    path: 'notifications',
    component: NotifsComponent,
  },
  {
    path: '**',
    redirectTo: 'home',
    pathMatch: 'full',
  },
];
