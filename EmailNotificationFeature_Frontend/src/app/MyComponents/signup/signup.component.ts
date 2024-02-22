import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css'
})

export class SignupComponent {
  formData: any = {};
  constructor(private http:HttpClient) {}
  submitForm() {
    this.http.post<any>('https://localhost:7214/api/EmailNotification', this.formData)
      .subscribe(
        response => {
          console.log('Registration successful:', response);
          // Add any additional handling after successful registration
        },
        error => {
          console.error('Registration failed:', error);
          // Handle registration error
        }
      );
  }
}