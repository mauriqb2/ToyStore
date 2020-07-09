import { Component, OnInit, ViewChild } from '@angular/core';
import { ToyService } from 'src/app/services/toy.service';
import { MatTableDataSource } from '@angular/material/table';
import { Toy } from 'src/app/models/toy';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-toy-store',
  templateUrl: './toy-store.component.html',
  styleUrls: ['./toy-store.component.scss']
})
export class ToyStoreComponent {

  displayedColumns = ['name','price', 'quantity', 'total']
  dataSource: MatTableDataSource<Toy>
  quantity:number[] = []

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort

  constructor(private toyService:ToyService, public dialogRef: MatDialogRef<ToyStoreComponent>){
    this.toyService.getToys().subscribe(toys => {
      this.dataSource = new MatTableDataSource(toys.filter(obj => obj.quantity !== 0))
      this.dataSource.data.forEach(()=>{
        this.quantity.push(0)
      })
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
    this.toyService.updateToy(toy).subscribe( answer => {})
  }

  sellItems(){
    this.dataSource.data.forEach( (toy,index) => {
      toy.quantity = toy.quantity - this.quantity[index]
      this.updateToy(toy)
    });
    this.dialogRef.close()
  }

}
