import { Component, OnInit, Input } from '@angular/core';
import { DataService } from '../data.service';

@Component({
  selector: 'app-page-not-found',
  templateUrl: './page-not-found.component.html',
  styleUrls: ['./page-not-found.component.css'],
  providers:[DataService]
})
export class PageNotFoundComponent implements OnInit {

  @Input() Message:string[];
  @Input() ID:number;
  PMes:string;
  constructor(private Child:DataService) { }
  ngOnInit() {
  }
  public OnClick(){
    this.PMes=this.Child.player(this.ID);
  }
}
