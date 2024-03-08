import { Component, Input } from '@angular/core';
import { ApiserviceService } from '../../apiservice.service';

@Component({
  selector: 'app-contact-add-edit',
  templateUrl: './contact-add-edit.component.html',
  styleUrl: './contact-add-edit.component.css'
})
export class ContactAddEditComponent {

  constructor(private service: ApiserviceService) { }
  
  @Input() contactItem: any;
  EmployeeId = "";
  EmployeeName = "";
  Department = "";
  DateOfJoining = "";
  PhotoFileName = "";
  PhotoFilePath = "";
  DepartmentList: any = [];


  ngOnInit(): void {
    this.loadEmployeeList();
  }

  loadEmployeeList() {

    this.service.getContactList().subscribe((data: any) => {
      this.DepartmentList = data;

      this.EmployeeId = this.contactItem.ContactId;
      this.EmployeeName = this.contactItem.FirstName;
    });
  }

  addEmployee() {
    var val = {
      EmployeeId: this.EmployeeId,
      EmployeeName: this.EmployeeName
    };

    this.service.addContact(val).subscribe(res => {
      alert(res.toString());
    });
  }

  updateEmployee() {
    var val = {
      EmployeeId: this.EmployeeId,
      EmployeeName: this.EmployeeName
    };

    this.service.updateContact(val).subscribe(res => {
      alert(res.toString());
    });
  }

  
}