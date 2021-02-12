import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  registerMode = false;

  constructor(private router: Router) {}

  ngOnInit() {}

  registerToggle() {
    this.registerMode = true;
  }

  cancel() {
    this.router.navigate(['/home']);
  }
}
