import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ConfirmationService } from 'primeng/api';
import { ToastsService } from 'src/app/services/toasts.service';
import { TableRestaurant } from '../../models/table-restaurant';
import { TableService } from '../../service/table.service';


@Component({
  selector: 'app-rom-table',
  templateUrl: './rom-table.component.html',
  styleUrls: ['./rom-table.component.scss']
})
export class RomTableComponent implements OnInit {

  constructor(private tableService: TableService,
              private confirmationService: ConfirmationService,
              protected toastsService: ToastsService,
              private router: Router) { }
  tables: TableRestaurant[] = [];
  selectedItemId: number | undefined;

  cols = [
    { field: 'id', header: 'Id' , width: '200px' },
    { field: 'name', header: 'Nazwa', width: '200px' },
    { field: 'description', header: 'Opis' },
    { field: 'number', header: 'Numer' , width: '200px' },
    { field: 'active', header: 'Aktywny' , width: '200px' },
    { field: 'action', header: '', width: '180px' },
  ];

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void{
    this.tables = [];
    this.tableService.GetAll().subscribe(
      result => {
        this.tables = result;
      });
  }

  onChange(model: TableRestaurant): void{
    this.confirmationService.confirm({
      message: `Potwierdzasz zmiane statusu stolika nr: ${model.number}`,
      accept: () => {
        this.tableService.ChangeStatut(model.id).subscribe(x => {
          this.toastsService.showSuccess(`Status został zmieniony`);
          this.loadData();
            }, error => this.toastsService.showError(error));
      }
  });
  }

  onAdd(): void{
    this.router.navigate(['/orders/table-add']);
  }
}
