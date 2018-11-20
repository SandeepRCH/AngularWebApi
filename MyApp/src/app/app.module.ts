import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule} from '@angular/forms'
import {RouterModule, Routes } from '@angular/router'
import { AppComponent } from './app.component';
import { TestComponent } from './test/test.component';
import { NewComponent } from './new/new.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { DataService} from '../app/data.service';
import { HttpClientModule } from '@angular/common/http';
import { StudentComponent } from './student/student.component';
import { StudentDetailsComponent } from './student-details/student-details.component';

const appRoutes: Routes=[
  {path:'new', component: NewComponent},
  {path:'test', component: TestComponent},
  { path:'student',component:StudentComponent},
  { path:'details',component:StudentDetailsComponent},
  { path:'**',component:StudentComponent},
  { path: ' ',
    redirectTo: '/test',
    pathMatch: 'full'
  }
]
@NgModule({
  declarations: [
    AppComponent,
    TestComponent,
    NewComponent,
    PageNotFoundComponent,
    StudentComponent,
    StudentDetailsComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
