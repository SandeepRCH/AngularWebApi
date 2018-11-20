import { Component } from '@angular/core';
import {DataService} from '../app/data.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
   providers:[DataService]
})
export class AppComponent {
  
}
