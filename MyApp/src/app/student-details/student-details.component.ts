import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service'; 
import { BackLogs } from '../BackLogs';
import { Education } from '../Education';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  styleUrls: ['./student-details.component.css']
})
export class StudentDetailsComponent implements OnInit {

  constructor(private Data:DataService) { }
  Subjects:string[];
  Backlogs:BackLogs[];
  public Education:Education;
  public i:number;
  public IdNumber:number;
  public dis:boolean =true;
  public UpdateMessage:string;
  ngOnInit() 
  {

  }
public GetBacklogs(IdNum:number)
{
  this.Data.getBacklogs(IdNum).subscribe((res)=>this.Backlogs=res);
}
public GetEducationInfo(IDNum:number)
{
  this.UpdateMessage='';
  this.dis=true;
   this.Data.GetEduDetails(IDNum).subscribe((res)=>this.Education=res);
   this.Education.Specialization; 
}
public toggle(){
  this.dis=!this.dis;
}
public EditStud(){
  
this.Data.updateEducation(this.Education.Id,this.Education).subscribe((res)=>this.UpdateMessage=res);
this.dis=true;
}
}