import { DOCUMENT } from '@angular/common';
import { Component, OnInit, ChangeDetectionStrategy, Inject, EventEmitter, Output, Input, AfterViewInit } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from "../../../environments/environment";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HeaderComponent implements AfterViewInit  {

  elem: any;
  isFullScrean = false;
  userName = "";
  environment = environment;

  @Input() expand: boolean | undefined;

  @Output()
  expandEvent = new EventEmitter<boolean>();

  constructor(
    @Inject(DOCUMENT) private document: any,
  ) {}

  ngAfterViewInit(): void {
    this.elem = document.documentElement;
  }

  expandMenu() {
    this.expand = !this.expand;
    this.expandEvent.emit(this.expand);
  }

  openFullscreen() {
    if (this.elem.requestFullscreen) {
      this.elem.requestFullscreen();
    } else if (this.elem.mozRequestFullScreen) {
      this.elem.mozRequestFullScreen();
    } else if (this.elem.webkitRequestFullscreen) {
      this.elem.webkitRequestFullscreen();
    } else if (this.elem.msRequestFullscreen) {
      this.elem.msRequestFullscreen();
    }
    this.isFullScrean = !this.isFullScrean;
  }

  closeFullscreen() {
    if (this.document.exitFullscreen) {
      this.document.exitFullscreen();
    } else if (this.document.mozCancelFullScreen) {
      this.document.mozCancelFullScreen();
    } else if (this.document.webkitExitFullscreen) {
      this.document.webkitExitFullscreen();
    } else if (this.document.msExitFullscreen) {
      this.document.msExitFullscreen();
    }
    this.isFullScrean = !this.isFullScrean;
  }

}
