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
  FirstName = "";
  LastName = "";
  Email = "";
  PhoneNumber = "";
  Address = ""
  ContactList: any = [];


  ngOnInit(): void {
    this.loadContactList();
  }  

  validate(isAdd: boolean){
    var form = document.getElementsByClassName('form-validation')[0] as HTMLFormElement;
   
    if (form.checkValidity() === false) {
      form.classList.add('was-validated');
    } else{
      if(isAdd)
        this.addContact();
      else
        this.updateContact();
    }    
  }

  loadContactList() {

    this.service.getContactList().subscribe((data: any) => {
      this.ContactList = data;

      this.ContactId = this.contactItem.contactId;
      this.FirstName = this.contactItem.firstName;
      this.LastName = this.contactItem.lastName;
      this.Email = this.contactItem.email;
      this.PhoneNumber = this.contactItem.phoneNumber;
      this.Address = this.contactItem.address;
    });
  }

  addContact() {
    var val = {
      contactId: this.ContactId,
      firstName: this.FirstName,
      lastName: this.LastName,
      email: this.Email,
      phoneNumber: this.PhoneNumber,
      address: this.Address,
    };

    this.service.addContact(val).subscribe(res => {
      if(!res){
        alert('Successfully updated!');
      }else{
        alert('Invalid data!');
      }

      this.loadContactList();
      document.getElementById("addEditModalClose")?.click();
    });
  }

  updateContact() {
    var val = {
      contactId: this.ContactId,
      firstName: this.FirstName,
      lastName: this.LastName,
      email: this.Email,
      phoneNumber: this.PhoneNumber,
      address: this.Address
    };

    this.service.updateContact(val).subscribe(res => {
        if(!res){
          alert('Successfully updated!');
        }else{
          alert('Invalid data!');
        }

        this.loadContactList();
        document.getElementById("addEditModalClose")?.click();
    });
  }

  
}