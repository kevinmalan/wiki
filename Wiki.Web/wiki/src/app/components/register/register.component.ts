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

  register() {
    console.log("clicked register button");
    this.webClient.register();
  }

}
