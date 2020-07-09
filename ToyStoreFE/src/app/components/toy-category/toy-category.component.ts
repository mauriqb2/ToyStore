import { Component, OnInit } from '@angular/core';
import { Enterprise } from 'src/app/models/enterprise';
import { EnterpriseService } from 'src/app/services/enterprise.service';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-toy-category',
  templateUrl: './toy-category.component.html',
  styleUrls: ['./toy-category.component.scss']
})
export class ToyCategoryComponent {

  enterprise:Enterprise = new Enterprise()

  constructor(private enterpriseService:EnterpriseService, public dialogRef: MatDialogRef<ToyCategoryComponent>) { 
    
  }

  addEnterprise(enterprise:Enterprise){
    this.enterpriseService.addenterprise(enterprise).subscribe(() => {
      this.dialogRef.close()
    })
  }


}
