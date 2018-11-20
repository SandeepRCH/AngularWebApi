import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-new',
  templateUrl: './new.component.html',
  styleUrls: ['./new.component.css']
})
export class NewComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }
  public Code=0;
  Message:string;
  branches=["Bio","Civil","CSE","Mech"];
  bran:string;
  public increment()
  {
    this.Code=this.Code +1;
    this.Branch();
  }
  public decrement()
  {
    this.Code=this.Code-1;
    this.Branch();
  } 
  public Branch()
  {
    if(this.Code==1){
      this.Message='Bio';
    }
    else if(this.Code==2){
      this.Message='Civil';
    }
    else if(this.Code==3){
      this.Message='CSE';
    }
    else if(this.Code==4){
      this.Message='Mech';
    }
    else{
      this.Message='...';
    }
  }
  public bclick(event){
    console.log(event);
  }
}
