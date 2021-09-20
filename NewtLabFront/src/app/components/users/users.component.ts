import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { User } from 'src/app/models/models';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {

  constructor(private uServ: UserService) {

  }

  users: User[] = [];
  ngOnInit(): void {
    this.uServ.getAll().subscribe(us => {
      this.users = us
      console.log(this.users);
    })

    //   .pipe(map(us => {
    //     console.log(us)
    //     this.users = us
    //   }));
  }



}
