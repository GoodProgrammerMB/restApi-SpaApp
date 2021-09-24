import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-main-layout',
  templateUrl: './main-layout.component.html',
  styleUrls: ['./main-layout.component.scss']
})
export class MainLayoutComponent {
  expand = false;

  constructor() {
    this.expand = true;//JSON.parse(localStorage.getItem('expandMenu'));
  }

  expandMenu(expand: boolean) {
    this.expand = expand;
    localStorage.setItem('expandMenu', JSON.stringify(expand));
  }
}
