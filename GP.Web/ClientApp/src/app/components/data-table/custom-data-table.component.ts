import { Component, OnInit, ChangeDetectionStrategy, Input, ViewChild, Output, EventEmitter } from '@angular/core';
import { Table } from 'primeng/table';
import { ActionType } from 'src/app/models/data-table/action-type.enum';
import { BodyButtonType } from 'src/app/models/data-table/body-button-type.enum';
import { HeaderInputType } from 'src/app/models/data-table/header-input-type.enum';
import { NameValue } from 'src/app/models/name-value.model';

@Component({
  selector: 'app-data-table',
  templateUrl: './custom-data-table.component.html',
  styleUrls: ['./custom-data-table.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class DataTableComponent implements OnInit {

  @Input()
  dataSource: Array<any> = [];
  @Input() scrollable: boolean = true;
  @Input() resizableColumns: boolean = true;
  @Input() columnsDefinition: any[] = [];
  @ViewChild('dataTable', { static: false }) table: Table | undefined;
  @Input() multiSelectOptions: Array<NameValue> = [];
  @Output() emitEdit = new EventEmitter();
  @Output() emitShow = new EventEmitter();
  @Output() emitTransfers = new EventEmitter();

  @Output() emitActionOnClick = new EventEmitter();

  inputType = HeaderInputType;
  buttonType = BodyButtonType;
  actionType = ActionType;
  selectedRowId: number | undefined;

  constructor() { }


  ngOnInit() {
  }

  filterTableByTypes(table: any, selected: Array<NameValue>, field: string, alg: string) {
    table.filter(selected.map(x => x.value), field, alg);
  }

  onEdit(rowData: any) {
    this.emitEdit.emit(rowData);
  }

  onShow(rowData: any) {
    this.emitShow.emit(rowData);
  }

  onTransfers(rowData: any) {
    this.emitTransfers.emit(rowData);
  }

  actionOnClick() {
    this.emitActionOnClick.emit();
  }

  //ex.
  initExample() {
    this.columnsDefinition = [
      { field: 'username', header: 'management.username', inputType: HeaderInputType.Filter },
      { field: 'drivingLicences', header: 'management.drivingLicences', inputType: HeaderInputType.MultiSelect },
      { field: 'dateCreated', header: 'management.dateCreated', inputType: HeaderInputType.Calendar },
      { field: 'durationTicks', header: 'management.durationTicks', inputType: HeaderInputType.Time },
      { field: 'action', header: 'common.action', width: '145px', inputType: HeaderInputType.Link,
      routerLink: '/management/vehicles/calendar', button: BodyButtonType.Show },
    ];
  }

}
