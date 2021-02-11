import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  model: any = {};

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  signup(){
    console.log(this.model);
    this.authService.register(this.model).subscribe(() => {
      console.log("Sign up successful")
    }, error => {
      console.error(error);
    });
  }

  cancel(){
    this.cancelRegister.emit(false);
    console.log('cancelling sign up')
  }

}
