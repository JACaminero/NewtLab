import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-banco-preg',
  templateUrl: './banco-preg.component.html',
  styleUrls: ['./banco-preg.component.scss']
})
export class BancoPregComponent implements OnInit {

  constructor() { }
  
  questionForm = new FormGroup({
    description: new FormControl('', [Validators.required]),
    answer1: new FormControl('', [Validators.required]),
    answer2: new FormControl('', [Validators.required]),
    answer3: new FormControl('', [Validators.required]),
    answer4: new FormControl('', [Validators.required]),
  });

  ngOnInit(): void {
  }

}
