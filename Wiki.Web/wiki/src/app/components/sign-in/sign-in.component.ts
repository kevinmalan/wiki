import { Component, OnInit } from '@angular/core';
import { WebClient } from '../../services/webClient.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent implements OnInit {

  constructor(private webClient: WebClient) { }

  ngOnInit(): void {
  }
  username: string = "";
  password: string = "";

  signIn() {
    this.webClient.signIn();
  }
}
