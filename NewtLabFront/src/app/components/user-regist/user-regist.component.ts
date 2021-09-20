import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { User } from 'src/app/models/models';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-user-regist',
  templateUrl: './user-regist.component.html',
  styleUrls: ['./user-regist.component.scss']
})
export class UserRegistComponent {

  userForm = new FormGroup({
    firstName: new FormControl('', [Validators.required]),
    lastName1: new FormControl('', [Validators.required]),
    lastName2: new FormControl('', [Validators.required]),
    birth: new FormControl('', [Validators.required]),
    cedula: new FormControl('', [Validators.required]),
    pass: new FormControl('', [Validators.required]),
    phone: new FormControl('', [Validators.required]),
    role: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email])
  });

  constructor(private uServ: UserService) {
  }

  registrar() {
    let u = new User();
    u.name = this.userForm.controls.firstName.value;
    u.lastName1 = this.userForm.controls.lastName1.value;
    u.lastName2 = this.userForm.controls.lastName2.value;
    u.username = this.userForm.controls.email.value;
    u.cedula = this.userForm.controls.cedula.value;
    u.password = this.userForm.controls.pass.value;
    u.phone = this.userForm.controls.phone.value;
    u.birth = this.userForm.controls.birth.value;
    u.role = this.userForm.controls.role.value;
    this.uServ.insert(u).subscribe();
  }
}
