import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';
import { student } from '../Student'
@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {

  constructor(private Data:DataService) { }
  public student:student;
  public editstu:student;
  public studs:student[];
  public index=0;
  public IdNum:number;
  public message:string;
  public Id:number;
  public Name:string;
  public Address:string;
  public email:string;
  public branch:string;
  public eMessage:string;
  public UpdateMessage:string;
  public AddStudent:student=<student>
  {
    Id:0,
    FullName:'',
    Address:'',
    email:'',
    branch:''
  };


  ngOnInit() {
  }
  public GetStu(){
    this.index=0;
    this.Data.getstudents().subscribe(res=>
      {
        this.studs=res,
        this.student=this.studs[this.index]
      });
    }
    public Next(){
      if(this.index+1<this.studs.length){
        this.message='';
        this.index=this.index+1;
        this.student=this.studs[this.index];
      }
      else{
        this.message='Invalid Slection'
      }
    }
    public Previous(){
      if(this.index-1>=0){
        this.message='';
        this.index=this.index-1;
        this.student=this.studs[this.index];
      }
      else{
        this.message='Invalid Slection'
      }
    }
    public Find(IdN:number)
    {
      this.student=this.studs.find(x=>x.Id===IdN);
      this.index=this.studs.indexOf(this.studs.find(x=>x.Id===IdN),0);
    }
    public addstudent()
    {
        this.AddStudent.Id=this.Id;
        this.AddStudent.FullName=this.Name;
        this.AddStudent.Address=this.Address;
        this.AddStudent.email=this.email;
        this.AddStudent.branch=this.branch;
        if(this.AddStudent.Id>0){
          this.Data.AddStudent(this.AddStudent).subscribe((res)=>this.eMessage=res);
        }
        else{
          this.eMessage='Invalid Record';
        }
    }
    public edit(){
      this.eMessage='';
      this.UpdateMessage='';
      this.editstu =JSON.parse(JSON.stringify(this.student));
    }
    public Save(){
      this.Data.updateStudent(this.editstu.Id,this.editstu).subscribe((res)=>{this.UpdateMessage=res});
    }
}