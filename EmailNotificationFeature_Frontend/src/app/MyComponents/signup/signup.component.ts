import { HttpClient } from '@angular/common/http';
import { Component, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css'
})

export class SignupComponent {
  regData: any = {};
  constructor(private http:HttpClient) {}
  signUp() {
    this.http.post<any>('https://localhost:7214/api/EmailNotification', this.regData)
      .subscribe(
        response => {
          console.log('Registration successful:', response);
          window.alert('Registration Successful');
        },
        error => {
          console.error('Registration failed:', error);
          window.alert('Registration Failed');
        }
      );
  }

  @Output() buttonClick: EventEmitter<void> = new EventEmitter<void>();
  buttonClicked() {
    this.buttonClick.emit();
  }

}