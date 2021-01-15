import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Guid } from 'guid-typescript';
import { ToastrService } from 'ngx-toastr';
import { CustomerDetailService } from 'src/app/shared/customer-detail.service';
import { CustomerDetail } from 'src/app/shared/customerDetail.model';

@Component({
  selector: 'app-customer-detail-form',
  templateUrl: './customer-detail-form.component.html',
  styleUrls: ['./customer-detail-form.component.css']
})
export class CustomerDetailFormComponent implements OnInit {

  constructor(public detailService:CustomerDetailService, private toastr:ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    if(this.detailService.formData.customerId==undefined){
      this.insertRecord(form);
    }else{
      this.updateRecord(form);
    }
  }
  insertRecord(form:NgForm){
    this.detailService.postCustomerDetail().subscribe(
      res=>{
        this.resetForm(form);
        this.detailService.getCustomersDetails();
        this.toastr.success("Submitted Successfully",'Customer detail register')
      },
      err=>{
        console.log(err);
        this.toastr.error("Error occured");
      }
    );
  }

  updateRecord(form:NgForm){
    this.detailService.updateCustomerDetail().subscribe(
      res=>{
        this.resetForm(form);
        this.detailService.getCustomersDetails();
        this.toastr.info("updated Successfully",'Customer detail register')
      },
      err=>{
        console.log(err);
        this.toastr.error("Error occured");
      }
    );
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.detailService.formData = new CustomerDetail();
  }
}
