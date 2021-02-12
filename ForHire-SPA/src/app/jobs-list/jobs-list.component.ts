import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-jobs-list',
  templateUrl: './jobs-list.component.html',
  styleUrls: ['./jobs-list.component.scss'],
})
export class JobsListComponent implements OnInit {
  model: any = {};

  constructor() {}

  ngOnInit() {}
}
