import { Component } from '@angular/core';
import { ApiserviceService } from '../apiservice.service';


@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrl: './contact.component.css'
})
export class ContactComponent {

  constructor(private service: ApiserviceService) { }

  ContactList: any = [];
  ModalTitle = "";
  ActivateAddEditEmpComp: boolean = false;
  contactItem: any;

  ngOnInit(): void {
    this.refreshConactList();
  }

  addClick() {
    this.contactItem = {
      EmployeeId: "0",
      EmployeeName: "",
      Department: "",
      DateOfJoining: "",
      PhotoFileName: "anonymous.png"
    }
    this.ModalTitle = "Add Employee";
    this.ActivateAddEditEmpComp = true;
  }

  editClick(item: any) {
    this.contactItem = item;
    this.ModalTitle = "Edit Contact";
    this.ActivateAddEditEmpComp = true;
  }

  deleteClick(item: any) {
    console.log(item)
    if (confirm('Are you sure?')) {
      this.service.deleteContact(item.contactId).subscribe(data => {
        alert('Succesfully deleted!');
        this.refreshConactList();
      })
    }
  }

  closeClick() {
    this.ActivateAddEditEmpComp = false;
    this.refreshConactList();
  }

  refreshConactList() {
    this.service.getContactList().subscribe(data => {
      console.log('data')
      console.log(data)
      this.ContactList = data;
    });
  }

}
