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
  ContactId = "";
  ContactName = "";
  ContactList: any = [];


  ngOnInit(): void {
    this.loadEmployeeList();
  }

  loadEmployeeList() {

    this.service.getContactList().subscribe((data: any) => {
      this.ContactList = data;

      this.ContactId = this.contactItem.contactId;
      this.ContactName = this.contactItem.firstName;
    });
  }

  addEmployee() {
    var val = {
      ContactId: this.ContactId,
      ContactName: this.ContactName
    };

    this.service.addContact(val).subscribe(res => {
      alert(res.toString());
    });
  }

  updateEmployee() {
    var val = {
      contactId: this.ContactId,
      firstName: this.ContactName,
      lastName: this.ContactName,
    };

    this.service.updateContact(val).subscribe(res => {
        if(!res){
          alert('Successfully updated!');
        }else{
          alert('Invalid data!');
        }

        this.loadEmployeeList();
        document.getElementById("updateClose")?.click();
    });
  }

  
}