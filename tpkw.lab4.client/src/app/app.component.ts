import { HttpClient } from '@angular/common/http';
import { identifierName } from '@angular/compiler';
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
  isCreate: boolean = true;
  public students: Student[] = [];
  inputForm: any = {
    id: '',
    firstName: '',
    lastName: '',
  };
  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getStudents();
  }
  toggleCreateEdit() {
    this.isCreate = !this.isCreate;
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
    if (this.isCreate) {
      console.log(this.inputForm)
      const student: StudentDto = {
        firstName: this.inputForm.firstName,
        lastName: this.inputForm.lastName
      };
      this.addPostStudent(student);
    }
    else {
      console.log(this.inputForm)
      const student: StudentDto = {
        firstName: this.inputForm.firstName,
        lastName:this.inputForm.lastName
      };
      this.editPutStudent(student,this.inputForm.id);
      
    }
  }
  addPostStudent(student: StudentDto){
    this.http.post<StudentDto>('/api/Students', student).subscribe(data => {
      this.getStudents();
    },
      error => {
        console.error('Error to send create student', error);
      }
    );
  }
  editPutStudent(student: StudentDto,id:number) {
    this.http.put<StudentDto>(`/api/Students/${id}`, student).subscribe(data => {
      this.getStudents();
    },
      error => {
        console.error('Error to send edit student',error);
      }
    );
  }
  deleteStudent(id: number) {
    console.log("click delete");
    console.log(id);
    this.http.delete(`/api/Students/${id}`).subscribe(() => this.getStudents());
  }

  onCLickEdit(id: number , firstName: string , lastName : string) {
    console.log("Click Edit");
    console.log(id);
    this.isCreate = false;
    this.inputForm.id = id;
    this.inputForm.firstName = firstName;
    this.inputForm.lastName = lastName;
    this.isCreate = false;

  }
  onCLickDelete(id: number) {
    this.deleteStudent(id);
  }

  title = 'tpkw.lab4.client';
}
