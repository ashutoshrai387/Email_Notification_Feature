import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Email_Notification_Feature';

  showComponent1: boolean = true;

  onComponent1ButtonClick() {
    this.showComponent1 = false;
  }

  onComponent2ButtonClick() {
    this.showComponent1 = true;
  }
}
