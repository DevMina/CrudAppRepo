import { Component } from '@angular/core';
import { Employee } from '../../models/employee';
import { EmployeeService } from '../../services/employee.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-employee-add',
  templateUrl: './employee-add.component.html',
  styleUrl: './employee-add.component.css'
})
export class EmployeeAddComponent {
  employee: Employee = { id: 0, name: '', address: '', mobile: '', email: '' };

  constructor(private employeeService: EmployeeService, private router: Router) { }

  addEmployee(): void {
    this.employeeService.createEmployee(this.employee).subscribe(() => this.router.navigate(['/employees']));
  }
}
