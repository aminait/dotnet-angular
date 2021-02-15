import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-application-modal',
  templateUrl: './application-modal.component.html',
  styleUrls: ['./application-modal.component.css'],
})
export class ApplicationModalComponent implements OnInit {
  modalRef: BsModalRef | any;
  constructor(private modalService: BsModalService) {}

  ngOnInit() {}
}
