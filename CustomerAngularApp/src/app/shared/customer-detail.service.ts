import { Injectable } from '@angular/core';
import { CustomerDetail } from './customerDetail.model';
import {HttpClient, HttpHeaders} from'@angular/common/http';
import { Guid } from 'guid-typescript';

@Injectable({
  providedIn: 'root'
})
export class CustomerDetailService {
  guid:any;
  Detaillist:CustomerDetail[];
  constructor(private http:HttpClient) { }

  readonly baseUrl = 'https://localhost:44358/api/Customers';
  

  formData:CustomerDetail = new CustomerDetail();

  postCustomerDetail(){
    //debugger;
    this.guid  = Guid.create().toString();
    this.formData.customerId=this.guid;
    
    var headers = new HttpHeaders({
      "Content-Type": "text/json",
      "Accept": "text/json"
    });
    var data =JSON.stringify(this.formData);
    console.log(data);
    return this.http.post(`${this.baseUrl}/PostCustomerDetail`,data,{ responseType: 'json', headers: headers });
  }

  updateCustomerDetail(){

    var headers = new HttpHeaders({
      "Content-Type": "text/json",
      "Accept": "text/json"
    });
    var data =JSON.stringify(this.formData);
    console.log(data);
    return this.http.put(`${this.baseUrl}/PutCustomerDetail/${this.formData.customerId}`,data,{ responseType: 'json', headers: headers });
  }

  deleteCustomerDetail(customerId:Guid){
    return this.http.delete(`${this.baseUrl}/${customerId}`);
  }

  getCustomersDetails(){
    this.http.get(`${this.baseUrl}/GetCustomers`)
    .toPromise()
    .then(result => this.Detaillist = result as CustomerDetail[] );
  }
}
