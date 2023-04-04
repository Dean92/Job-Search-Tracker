import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.css'],
})
export class TestErrorComponent {
  baseUrl = 'https://localhost:7039/api/';
  validationErrors: string[] = [];

  constructor(private http: HttpClient) {}

  get404Error() {
    this.http.get(this.baseUrl + 'ErrorHandle/not-found').subscribe({
      next: (response) => console.log(response),
      error: (error) => console.log(error),
    });
  }
  get400Error() {
    this.http.get(this.baseUrl + 'ErrorHandle/bad-request').subscribe({
      next: (response) => console.log(response),
      error: (error) => console.log(error),
    });
  }
  get401Error() {
    this.http.get(this.baseUrl + 'ErrorHandle/auth').subscribe({
      next: (response) => console.log(response),
      error: (error) => console.log(error),
    });
  }
  get400ValidationError() {
    this.http.post(this.baseUrl + 'account/register', {}).subscribe({
      next: (response) => console.log(response),
      error: (error) => {
        console.log(error), (this.validationErrors = error);
      },
    });
  }
  get500Error() {
    this.http.get(this.baseUrl + 'ErrorHandle/server-error').subscribe({
      next: (response) => console.log(response),
      error: (error) => console.log(error),
    });
  }
}
