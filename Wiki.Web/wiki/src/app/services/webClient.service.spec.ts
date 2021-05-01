import { TestBed } from '@angular/core/testing';

import { WebClient } from './webClient.service';

describe('ConfigServiceService', () => {
  let service: WebClient;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WebClient);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
