import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss'],
})
export class SignupComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  model: any = {};
  loginModel: any = {};

  constructor(
    private authService: AuthService,
    private alertify: AlertifyService,
    private router: Router
  ) {}

  ngOnInit() {}

  signup() {
    console.log(this.model);
    this.loginModel.email = this.model.email;
    this.loginModel.password = this.model.password;
    this.authService.register(this.model).subscribe(
      () => {
        this.alertify.success('Signed up successfully!');
        this.authService.login(this.loginModel).subscribe(
          () => {
            this.alertify.message('Logging in...');
          },
          (error) => {
            this.alertify.error(error);
          }
        );
        this.router.navigate(['/jobs']);
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  cancel() {
    this.cancelRegister.emit(false);
    console.log('cancelling sign up');
    this.router.navigate(['/home']);
  }
}
