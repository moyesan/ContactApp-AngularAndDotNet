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
  ActivateAddEditContactComp: boolean = false;
  contactItem: any;

  sortProperty: string = 'contactId';
  sortOrder = 1;
  loading = false;

  ngOnInit(): void {
    this.refreshConactList();
  }

  addClick() {
    this.contactItem = {
      contactId: "",
      firstName: "",
      lastName: "",
      email: "",
      phoneNumber: "",
      address: ""
    }
    this.ModalTitle = "Add Contact";
    this.ActivateAddEditContactComp = true;
  }

  editClick(item: any) {
    this.contactItem = item;
    this.ModalTitle = "Edit Contact";
    this.ActivateAddEditContactComp = true;
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
    this.ActivateAddEditContactComp = false;
    this.refreshConactList();
  }

  refreshConactList() {
    this.service.getContactList().subscribe(data => {
      console.log('data')
      console.log(data)
      this.ContactList = data;
    });
  }
  

  // sorting ///////////////////////////////
  sortBy(property: string) {
    this.sortOrder = property === this.sortProperty ? (this.sortOrder * -1) : 1;
    this.sortProperty = property;
    this.ContactList = [...this.ContactList.sort((a: any, b: any) => {
        // sort comparison function
        let result = 0;
        if (a[property] < b[property]) {
            result = -1;
        }
        if (a[property] > b[property]) {
            result = 1;
        }
        return result * this.sortOrder;
    })];
  }

  sortIcon(property: string) {
      if (property === this.sortProperty) {
          return this.sortOrder === 1 ? '☝️' : '👇';
      }
      return '';
  }

}
