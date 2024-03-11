import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiserviceService {

  readonly apiUrl = 'https://localhost:44333/api/';

  constructor(private http: HttpClient) { } 

  // get ContactList
  getContactList(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl + 'Contact/GetContactList');
  }

  // add Contact
  addContact(contact: any): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<any>(this.apiUrl + 'Contact/AddContact', contact, httpOptions);
  }

  // update Contact
  updateContact(contact: any): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<any>(this.apiUrl + 'Contact/UpdateContact/' + contact.contactId, contact, httpOptions);
  }

  // delete Contact
  deleteContact(contactId: number): Observable<number> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.delete<number>(this.apiUrl + 'Contact/DeleteContact/' + contactId, httpOptions);
  }
}
