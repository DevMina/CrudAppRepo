import { RouterModule, Routes } from '@angular/router';
import { EmployeeListComponent } from './Components/employee-list/employee-list.component';
import { EmployeeAddComponent } from './Components/employee-add/employee-add.component';
import { EmployeeEditComponent } from './Components/employee-edit/employee-edit.component';
import { EmployeeDetailsComponent } from './Components/employee-details/employee-details.component';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
export const routes: Routes = [
    { path: '', component: EmployeeListComponent },
    { path: 'employees', component: EmployeeListComponent },
    { path: 'employees/add', component: EmployeeAddComponent },
    { path: 'employees/edit/:id', component: EmployeeEditComponent },
    { path: 'employees/:id', component: EmployeeDetailsComponent },
];

@NgModule({
    declarations: [
      EmployeeListComponent,
      EmployeeAddComponent,
      EmployeeEditComponent,
      EmployeeDetailsComponent
    ],
    imports: [
      BrowserModule,
      FormsModule,
      RouterModule.forRoot(routes) // Add this line
    ],
    providers: [],
    bootstrap: []
  })
  export class AppModule { }