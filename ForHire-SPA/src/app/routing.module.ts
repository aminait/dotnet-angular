// import { Routes, RouterModule, ActivatedRouteSnapshot } from '@angular/router';
// import { InjectionToken, NgModule } from '@angular/core';

// import { HomeUserComponent } from './home-user/home-user.component';
// import { HomeComponent } from './home/home.component';
// import { AppliedJobsComponent } from './applied-jobs/applied-jobs.component';
// import { JobsListComponent } from './jobs/jobs-list/jobs-list.component';
// import { LoginComponent } from './login/login.component';
// import { MessagesComponent } from './messages/messages.component';
// import { NotifsComponent } from './notifs/notifs.component';
// import { SignupComponent } from './signup/signup.component';
// import { AuthGuard } from './_guards/auth.guard';
// import { JobsSavedComponent } from './jobs/jobs-saved/jobs-saved.component';
// import { JobsListResolver } from './_resolvers/jobs-list.resolver';
// import { NotFoundComponent } from './not-found/not-found.component';

// const externalUrlProvider = new InjectionToken('externalUrlRedirectResolver');
// const deactivateGuard = new InjectionToken('deactivateGuard');

// export const routes: Routes = [
//   {
//     path: '',
//     component: HomeComponent,
//   },
//   {
//     path: 'home',
//     component: HomeUserComponent,
//   },
//   {
//     path: 'login',
//     component: LoginComponent,
//   },
//   {
//     path: 'signup',
//     component: SignupComponent,
//   },
//   {
//     path: 'jobs',
//     component: JobsListComponent,
//     resolve: { jobs: JobsListResolver },
//   },
//   {
//     path: 'saved',
//     component: JobsSavedComponent,
//   },
//   {
//     path: '',
//     runGuardsAndResolvers: 'always',
//     canActivate: [AuthGuard],
//     children: [
//       {
//         path: 'jobs-applied',
//         component: AppliedJobsComponent,
//       },
//       {
//         path: 'messages',
//         component: MessagesComponent,
//       },
//       {
//         path: 'notifications',
//         component: NotifsComponent,
//       },
//     ],
//   },
//   {
//     path: '**',
//     redirectTo: 'not-found',
//     pathMatch: 'full',
//   },
//   {
//     path: 'not-found',
//     component: NotFoundComponent,
//   },
//   {
//     path: 'externalRedirect',
//     canActivate: [externalUrlProvider],
//     // We need a component here because we cannot define the route otherwise
//     component: NotFoundComponent,
//   },
// ];

// @NgModule({
//   imports: [RouterModule.forRoot(routes)],
//   exports: [RouterModule],
//   providers: [
//     {
//       provide: externalUrlProvider,
//       useValue: (route: ActivatedRouteSnapshot) => {
//         const externalUrl = route.paramMap.get('externalUrl');
//         window.open(externalUrl!, '_self');
//       },
//     },
//   ],
// })
// export class AppRoutingModule {}
