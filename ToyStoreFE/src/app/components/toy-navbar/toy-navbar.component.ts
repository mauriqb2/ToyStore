import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BreakpointObserver, Breakpoints, BreakpointState } from '@angular/cdk/layout';
import { MatDialog } from '@angular/material/dialog';
import { ToyStockComponent } from '../toy-stock/toy-stock.component';
import { ToyCategoryComponent } from '../toy-category/toy-category.component';
import { ToyStoreComponent } from '../toy-store/toy-store.component';

@Component({
  selector: 'app-toy-navbar',
  templateUrl: './toy-navbar.component.html',
  styleUrls: ['./toy-navbar.component.scss']
})
export class ToyNavbarComponent {

  isHandset: Observable<BreakpointState> = this.breakpointObserver.observe(Breakpoints.Handset);
  constructor(private breakpointObserver: BreakpointObserver, private dialog:MatDialog) {}

  checkStock(){
    this.dialog.open(ToyStockComponent, {
      width:'650px'
    })
    this.dialog.afterAllClosed.subscribe(() => {
      window.location.reload()
    }) 
  }

  createNewCategory(){
    this.dialog.open(ToyCategoryComponent, {
      width:'650px'
    })
    this.dialog.afterAllClosed.subscribe(() => {
      window.location.reload()
    }) 
  }

  sellItems(){
    this.dialog.open(ToyStoreComponent, {
      width:'650px'
    })
    this.dialog.afterAllClosed.subscribe(() => {
      window.location.reload()
    }) 
  }

}
