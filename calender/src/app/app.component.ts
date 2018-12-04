import { Component,ViewEncapsulation,OnInit } from '@angular/core';
import { format } from 'util';
import * as moment from 'moment';
import { FormBuilder,  
  FormControl,  
  FormGroup,  
  Validators,FormsModule} from '@angular/forms';

@Component({
  selector: 'app-root',
  encapsulation:ViewEncapsulation.None,
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'app';
  StartDate:Date;
  EndDate:Date;
  Theme:string="calendar-days1 flex-container flex-center";
  public date=moment();
  public predate=moment(this.date).add(1,'months');
  public daysArr;
  public predaysArr;
  public background;
  public Message;
  public selectedColor="selected"
  public dateForm:FormGroup;
  constructor(private fb:FormBuilder){
    this.initDateForm();
    
  }
  
  public ngOnInit(){
  this.daysArr=this.createCalendar(this.date);
  this.predaysArr=this.createCalendar(this.predate)
}
public todayCheck(day) {
  if (!day) {
    return false;
  }
  return moment().format('L') === day.format('L');
}
public createCalendar(month) {
  let firstDay = moment(month).startOf('M');
  let days = Array.apply(null, { length: month.daysInMonth() }).map(Number.call, Number).map((n)=>{
    return moment(firstDay).add(n,'d');
  })
  for(let n=0;n<firstDay.weekday();n++){
    days.unshift(null);
  }
  return days;

}
public nextMonth() {
  this.date.add(1, 'M');
  this.predate.add(1,'M');
  this.daysArr = this.createCalendar(this.date);
  this.predaysArr=this.createCalendar(this.predate)
}

public previousMonth() {
  this.date.subtract(1, 'M');
  this.predate.subtract(1,'M');
  this.daysArr = this.createCalendar(this.date);
  this.predaysArr=this.createCalendar(this.predate);
}
public initDateForm(){
  return this.dateForm=this.fb.group({
    dateFrom:[null,Validators.required],
    dateTo:[null,Validators.required]
  })
    }
    public selectedDate(day) {
      let dayFormatted = day.format('DD/MM/YYYY');
      if (this.dateForm.valid) {
        this.dateForm.setValue({ dateFrom: null, dateTo: null });
        return;
      }
      if (!this.dateForm.get('dateFrom').value) {
        this.dateForm.get('dateFrom').patchValue(dayFormatted);
      } else {
        this.dateForm.get('dateTo').patchValue(dayFormatted);
      }
    }
    public DarkTheme(){
     this.Theme="calendar-days flex-container flex-center";
    }
    public LightTheme(){
      this.Theme="calendar-days1 flex-container flex-center";
    }
    public Dark(){
      this.background="Background";
    }
    public Light(){
      this.background="Background1";
    }
    public isSelected(day) {
      if (!day) {
        return false;
      }
      let dateFromMoment = moment(this.dateForm.value.dateFrom, 'DD/MM/YYYY');
      let dateToMoment = moment(this.dateForm.value.dateTo, 'DD/MM/YYYY');
      if (this.dateForm.valid) {
        return (
          dateFromMoment.isSameOrBefore(day) && dateToMoment.isSameOrAfter(day)
        );
      }
      if (this.dateForm.get('dateFrom').valid) {
        return dateFromMoment.isSame(day);
      }
    }
    public Apply(){
this.Message= "Applied From "+this.StartDate+" To "+this.EndDate;
    }
}