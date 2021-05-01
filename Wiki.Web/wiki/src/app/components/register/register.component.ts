import { Component, Injectable, OnInit } from '@angular/core';
import { WebClient } from '../../services/webClient.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  constructor(private webClient: WebClient) { }

  ngOnInit(): void {
  }

  username: string = "";
  password: string = "";

  register() {
    console.log(this.username);
    this.webClient.register({
      userName: this.username,
      password: this.password
    });
  }
}
