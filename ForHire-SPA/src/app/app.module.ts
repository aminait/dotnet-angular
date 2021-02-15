import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { AccordionModule } from 'ngx-bootstrap/accordion';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { SignupComponent } from './signup/signup.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { FormsModule } from '@angular/forms';
import { AuthService } from './_services/auth.service';
// import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { JobsListComponent } from './jobs/jobs-list/jobs-list.component';
import { MessagesComponent } from './messages/messages.component';
import { AppliedJobsComponent } from './applied-jobs/applied-jobs.component';
import { NotifsComponent } from './notifs/notifs.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { AlertifyService } from './_services/alertify.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeUserComponent } from './home-user/home-user.component';
import { JobsService } from './_services/jobs.service';
import { JobsSavedComponent } from './jobs/jobs-saved/jobs-saved.component';
import { ApplicationModalComponent } from './application-modal/application-modal.component';

@NgModule({
  declarations: [	
    AppComponent,
    NavComponent,
    SignupComponent,
    LoginComponent,
    HomeComponent,
    JobsListComponent,
    MessagesComponent,
    AppliedJobsComponent,
    NotifsComponent,
    HomeUserComponent,
    JobsSavedComponent,
      ApplicationModalComponent
   ],
  imports: [
    BrowserModule,
    CommonModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BsDropdownModule.forRoot(),
    RouterModule.forRoot(appRoutes),
    BrowserAnimationsModule,
    ModalModule.forRoot(),
    AccordionModule.forRoot(),
  ],
  providers: [
    AuthService,
    // ErrorInterceptorProvider,
    AlertifyService,
    JobsService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
