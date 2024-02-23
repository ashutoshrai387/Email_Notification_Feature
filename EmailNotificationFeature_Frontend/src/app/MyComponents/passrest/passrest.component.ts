import { HttpClient } from '@angular/common/http';
import { Component, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-passrest',
  templateUrl: './passrest.component.html',
  styleUrl: './passrest.component.css'
})

export class PassrestComponent {
  passData: any = {};
  constructor(private http:HttpClient) {}
  resetPass() {
    this.http.post<any>('https://localhost:7214/api/PasswordReset', this.passData)
      .subscribe(
        response => { 
          console.log('Password Reset successful:', response);
          window.alert('Password Reset Successful');
        },
        error => {
          console.error('Password Reset failed:', error);
          window.alert('Password Reset Failed');
        }
      );
  }
  
  @Output() buttonClick: EventEmitter<void> = new EventEmitter<void>();

  buttonClicked() {
    this.buttonClick.emit();
  }
}