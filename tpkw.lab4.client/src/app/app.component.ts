import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface Student {
  id: number;
  firstName: string;
  lastName: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public students: Student[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getStudents();
  }

  getStudents() {
    this.http.get<Student[]>('/api/Students').subscribe(
      (result) => {
        this.students = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'tpkw.lab4.client';
}
