import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { ToyService } from 'src/app/services/toy.service';
import { MatTableDataSource } from '@angular/material/table';
import { Toy } from 'src/app/models/toy'
import { Enterprise } from 'src/app/models/enterprise';
import { EnterpriseService } from 'src/app/services/enterprise.service';

@Component({
  selector: 'app-toy-chart',
  templateUrl: './toy-chart.component.html',
  styleUrls: ['./toy-chart.component.scss'],
  encapsulation : ViewEncapsulation.None
})
export class ToyChartComponent {
  displayedColumns = ['id', 'createdDate' ,'name', 'category', 'enterprise', 'quantity', 'price', 'action']
  dataSource: MatTableDataSource<Toy>
  editID: number = 0
  oldID: number = 0
  newEnabled: boolean = false
  editdisabled: boolean = true
  selected: Number = 0
  showOptions: boolean = false
  enterprises: Enterprise[]

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort

  constructor(private toyService:ToyService, private enterpriseService:EnterpriseService){
    this.toyService.getToys().subscribe(toys => {
      this.dataSource = new MatTableDataSource(toys.filter(obj => obj.quantity !== 0))
      this.dataSource.paginator = this.paginator
      this.dataSource.sort = this.sort
    }) 
    this.enterpriseService.getenterprises().subscribe(enterprises => {
      this.enterprises = enterprises
    })
    console.log(this.enterprises)
  }

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.dataSource.filter = filterValue;
  }

  updateToy(toy: Toy){
    var enterpriseID = Number(toy.enterpriseID)
    toy.enterpriseID = enterpriseID
    console.log(toy);
    this.toyService.updateToy(toy).subscribe( answer => {
      this.refresh()
    })
    this.editdisabled = true;
  }

  cancelEdit(toy: Toy){
    this.editdisabled = true;
    this.newEnabled = false;
    this.refresh()
  }

  editROw(id: number){
    this.editdisabled = false;
    this.oldID = this.editID
    this.editID = id;    
  }

  deleteToy(toy: Toy){
    this.toyService.deleteToy(toy).subscribe( answer => {
      this.refresh()
    })
  }

  refresh(){
    if(this.selected==0){
      this.toyService.getToys().subscribe(toys => {
        this.dataSource.data = toys.filter(obj => obj.quantity !== 0)
      }) 
      this.enterpriseService.getenterprises().subscribe(enterprises => {
        this.enterprises = enterprises
      })
    }
    else{
      this.filterByEnterprise(this.selected)
    }
  }

  addToy(){
    this.newEnabled = true
    var newToy = {
      name:'',
      enterpriseID: this.selected,
      category: '',
      quantity: 0
    } as Toy
    if(this.selected!=0){
      var enterprise = {
        id:this.selected
      } as Enterprise
      this.enterpriseService.getenterprise(enterprise).subscribe(enterpriseSelected => {
        this.dataSource.data = enterpriseSelected.toys
        this.dataSource.data.push(newToy)
        this.paginator.lastPage()
        this.dataSource.paginator = this.paginator
      })
    }
    else{
      this.toyService.getToys().subscribe(toys => {
        this.dataSource.data = toys.filter(obj => obj.quantity !== 0)
        this.dataSource.data.push(newToy)
        this.paginator.lastPage()
        this.dataSource.paginator = this.paginator
      })
    }
    this.editROw(newToy.id)
  }

  createToy(toy:Toy){
    var enterpriseID = Number(toy.enterpriseID)
    toy.enterpriseID = enterpriseID
    this.toyService.addToy(toy).subscribe(toys => {
      this.refresh()
    })
    this.newEnabled = false
    this.editdisabled = true
  }

  filterByEnterprise(idSelected:Number){
    this.selected = idSelected;
    if(this.selected!=0){
      var enterprise = {
        id:idSelected
      } as Enterprise
      this.enterpriseService.getenterprise(enterprise).subscribe(enterpriseSelected => {
        this.dataSource.data = enterpriseSelected.toys
      })
    }
    else{
      this.refresh()
    }
    this.showOptions = true
  }

  goBack(){
    this.showOptions = false
  }

  deleteCategory(){
    var deleteEnterprise = {
      id:this.selected
    } as Enterprise
    this.enterpriseService.deleteenterprise(deleteEnterprise).subscribe(() => {
      this.selected = 0
      this.refresh()
      this.showOptions = false
    })
  }

}