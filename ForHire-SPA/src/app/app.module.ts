import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TabsModule } from 'ngx-bootstrap/tabs';
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
import { JobsListComponent } from './jobs/jobs-list/jobs-list.component';
import { MessagesComponent } from './messages/messages.component';
import { NotifsComponent } from './notifs/notifs.component';
import { RouterModule } from '@angular/router';
import { AlertifyService } from './_services/alertify.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeUserComponent } from './user/home-user/home-user.component';
import { JobsService } from './_services/jobs.service';
import { JobsSavedComponent } from './jobs/jobs-saved/jobs-saved.component';
import { ApplicationModalComponent } from './application-modal/application-modal.component';
import { JobsListResolver } from './_resolvers/jobs-list.resolver';
import { NotFoundComponent } from './not-found/not-found.component';
import { appRoutes } from './routes';
import { UserProfileComponent } from './user/user-profile/user-profile.component';
import { UserProfileResolver } from './_resolvers/user-profile.resolver';
import { JwtModule } from '@auth0/angular-jwt';
import { AuthGuard } from './_guards/auth.guard';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes.guard';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { ResumeUploadComponent } from './user/user-profile/resume-upload/resume-upload.component';
import { FileUploadModule } from 'ng2-file-upload';

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    SignupComponent,
    LoginComponent,
    HomeComponent,
    JobsListComponent,
    MessagesComponent,
    NotifsComponent,
    HomeUserComponent,
    JobsSavedComponent,
    ApplicationModalComponent,
    NotFoundComponent,
    UserProfileComponent,
    ResumeUploadComponent,
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
    TabsModule.forRoot(),
    FileUploadModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ['localhost:5000'],
        disallowedRoutes: ['localhost:5000/api/auth'],
      },
    }),
  ],
  providers: [
    AuthService,
    ErrorInterceptorProvider,
    AlertifyService,
    AuthGuard,
    JobsService,
    JobsListResolver,
    UserProfileResolver,
    PreventUnsavedChanges,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
