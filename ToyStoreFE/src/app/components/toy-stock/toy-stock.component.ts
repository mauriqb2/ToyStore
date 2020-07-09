import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { ToyService } from 'src/app/services/toy.service';
import { MatTableDataSource } from '@angular/material/table';
import { Toy } from 'src/app/models/toy'
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-toy-stock',
  templateUrl: './toy-stock.component.html',
  styleUrls: ['./toy-stock.component.scss']
})
export class ToyStockComponent {

  displayedColumns = ['id','name', 'quantity', 'action']
  dataSource: MatTableDataSource<Toy>
  editID: number = 0
  oldID: number = 0
  reStock: boolean = false
  fullStock: boolean

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort

  constructor(private toyService:ToyService, public dialogRef: MatDialogRef<ToyStockComponent>){
    this.toyService.getToys().subscribe(toys => {
      if(toys.filter(obj => obj.quantity === 0).length === 0)
        this.fullStock = true
      else
        this.fullStock = false
      this.dataSource = new MatTableDataSource(toys.filter(obj => obj.quantity === 0))
      this.dataSource.paginator = this.paginator
      this.dataSource.sort = this.sort
    }) 
  }

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase()
    this.dataSource.filter = filterValue
  }

  updateToy(toy: Toy){
    console.log(toy);
    this.toyService.updateToy(toy).subscribe( answer => {
      this.refresh()
      this.reStock = false
    })
    this.dialogRef.close()
  }

  cancelEdit(toy: Toy){
    this.refresh()
    this.reStock = false
  }

  restoreStock(id: number){
    this.reStock = true
    this.oldID = this.editID
    this.editID = id  
  }

  refresh(){
    this.toyService.getToys().subscribe(toys => {
      this.dataSource.data = toys.filter(obj => obj.quantity === 0)
    }) 
  }

}
