import { Guid } from 'guid-typescript';
export class CustomerDetail{
    customerId: Guid|undefined;
    customerFirstName:string|undefined;
    customerLastName:string|undefined;
    customerAddress:string|undefined;
    customerPostalCode:string|undefined;
    customerMobileNumber:string|undefined;
    customerEmail:string|undefined;
}