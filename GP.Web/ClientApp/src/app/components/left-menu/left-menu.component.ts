import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-left-menu',
  templateUrl: './left-menu.component.html',
  styleUrls: ['./left-menu.component.scss']
})
export class LeftMenuComponent implements OnInit {

  collapsedList: Array<boolean> = [false, false, false, false, false, false, false];
  lastIndex: Number | undefined;

  @Input()
  expand!: boolean;

  @Output()
  expandEvent = new EventEmitter<boolean>();


  menu = [
    { label: 'Menu', routerLink: '/orders/menu', iconSrc: this.iconsSrcPath('menu') },
    {
      label: 'Zamówienia', iconSrc: this.iconsSrcPath('orders'), children: [
         { label: 'Aktywne', routerLink: '/orders/order-list', iconSrc: '' },
         { label: 'Zamów', routerLink: '/orders/create', iconSrc: ''}
      ]
    },
    { label: 'Stoliki', routerLink: '/orders/tables', iconSrc: this.iconsSrcPath('rom-tables') },
  ];


  constructor() { }

  iconsSrcPath(name: string) {
    return `../../../../../assets/icons/menu/${name}.svg`;
  }

  ngOnInit() {
  }

  collapse(index: number, collapseParent: boolean = true) {
    this.collapsedList.forEach((x, i) => {
      if (i !== index && collapseParent) {
        this.collapsedList[i] = false;
      }
    });
    this.collapsedList[index] = !this.collapsedList[index];
    this.lastIndex = index;
  }

  onHideMenu() {
    this.expand = false;
    this.expandEvent.emit(this.expand);
  }


  onExpandMenu() {
    this.collapsedList.forEach((x, i) => { this.collapsedList[i] = false; });
    this.expand = !this.expand;
    this.expandEvent.emit(this.expand);
  }
}
