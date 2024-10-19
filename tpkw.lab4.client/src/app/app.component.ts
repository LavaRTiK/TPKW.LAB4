import { HttpClient } from '@angular/common/http';
import { Component, OnInit, input } from '@angular/core';

interface Student {
  id: number;
  firstName: string;
  lastName: string;
}
interface StudentDto {
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
  inputForm: any = {
    firstName: '',
    lastName: '',
  };
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
  onSubmit() {
    console.log(this.inputForm)
    const student: StudentDto = {
      firstName: this.inputForm.firstName,
      lastName: this.inputForm.lastName
    };
    this.addPostStudent(student);
  }
  addPostStudent(student: StudentDto){
    this.http.post<StudentDto>('/api/Students', student).subscribe(data => {
      this.inputForm.firstName = data.firstName;
      this.inputForm.lastName = data.lastName;
    },
      error => {
        console.error('Ошибка при отправке данных студента', error);
      }
    );
  }

  title = 'tpkw.lab4.client';
}
