import { Component, OnInit } from '@angular/core';
import { DataService} from '../data.service';
import { Observable } from '../../../node_modules/rxjs';
import { student } from '../Student';
import { element } from '../../../node_modules/protractor';
@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css'],
  providers:[DataService]
})
export class TestComponent implements OnInit {

  constructor(private Data:DataService) {
  }
  ngOnInit() {
  }
  branches=["Bio","Civil","CSE","Mech"];
  bran:string;
  Message:string;
  ChildMessage:string;
  players:string[];
  public play(Num:number){
    this.players=this.Data.played();
  }
  public AddPlayer(Pdata:string){
    console.log(Pdata);
    this.Data.Cricket.push(Pdata);
  }
 
}
