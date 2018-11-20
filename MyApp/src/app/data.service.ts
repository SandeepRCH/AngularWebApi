import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { student } from './Student';
import { BackLogs } from './BackLogs';
import { Observable } from '../../node_modules/rxjs';
import { Education } from './Education'

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http:HttpClient) { }
  public Cricket:string[]=['Rohit','Dhawan','Kohli','Rayudu','Jadeja','Bhuwaneshwar','Kuldeep Yadav','Bumrah'];
  public stud:student[];
  public student:student;
  public backlogs:BackLogs[];
  public Id:number[];
  public education:Education;
  public Edu:Observable<Education>;
  index=0;
  public URL:string = 'http://localhost:50331/api/values';

  public played(){
    return this.Cricket;
  }
  public player(ID){
    console.log(this.Cricket[ID]);
    return this.Cricket[ID];
  }
  public getstudents():Observable<student[]> 
  {
    return this.http.get<student[]>(this.URL+'/GetStudents');
  }
  public getstudent(IdNum:number):Observable<student>{
   return this.http.get<student>(this.URL+'/GetStudent?Id='+IdNum);
  }
  public getBacklogs(IdNum:number):Observable<BackLogs[]>
  {
    if(IdNum){
      return this.http.get<BackLogs[]>(this.URL+'/getBacklogs?Id='+IdNum);
    }
    else{
      return this.http.get<BackLogs[]>(this.URL+'/getBacklogs');
    }
  }
  public AddStudent(Student:student){
   return this.http.post<string>(this.URL+'/AddStudent',Student,{
     headers:new HttpHeaders({
       'Content-Type':'application/json'
     })
   });
  }
  public GetEduDetails(IdNum):Observable<Education>{
     return this.http.get<Education>(this.URL+'/getEducationdetails?ID='+IdNum);
  }
  public updateStudent(IdNum:number,stu:student){
   return this.http.put<string>(this.URL+'/PutStudent?Id='+IdNum,stu);
    }
    public updateEducation(IdNum:number,Edu:Education){
     return this.http.put<string>(this.URL+'/PutEducation?Id='+IdNum,Edu);
    }
}