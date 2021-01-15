import { Component, OnInit } from '@angular/core';
import { Guid } from 'guid-typescript';
import { ToastrService } from 'ngx-toastr';
import { CustomerDetailService } from '../shared/customer-detail.service';
import { CustomerDetail } from '../shared/customerDetail.model';

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.css']
})
export class CustomerDetailComponent implements OnInit {

  constructor(public detailService:CustomerDetailService, private toastr:ToastrService) { }

  ngOnInit(): void {
    this.detailService.getCustomersDetails();
  }

  onPopulate(detail:CustomerDetail){
    this.detailService.formData = Object.assign({},detail);
  }

  onDelete(customerId:Guid){
    this.detailService.deleteCustomerDetail(customerId).subscribe(
      res=>{
        this.detailService.getCustomersDetails();
        this.toastr.info("Deleted Successfully",'Customer detail register')
      },
      err=>{
        console.log(err);
        this.toastr.error("Error occured");
      }
    );
  }
}
