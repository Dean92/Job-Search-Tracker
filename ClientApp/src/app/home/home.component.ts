import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  registerMode = false;

  ngOnInit(): void {
    console.log(this.registerMode);
  }

  registerToggle() {
    this.registerMode = !this.registerMode;
  }
}
