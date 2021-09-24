import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  templateUrl: './add-table.component.html',
  styleUrls: ['./add-table.component.scss']
})
export class AddTableComponent implements OnInit {

  tableForm = new FormGroup ({});

  constructor() { }

  ngOnInit(): void {
  }

}
