import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-passrest',
  templateUrl: './passrest.component.html',
  styleUrl: './passrest.component.css'
})

export class PassrestComponent {
  formData: any = {};
  constructor(private http:HttpClient) {}
  submitResetForm() {
    this.http.post<any>('hhttps://localhost:7214/api/PasswordReset', this.formData)
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