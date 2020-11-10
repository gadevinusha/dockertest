import { TestBed } from '@angular/core/testing';

import { MsaluserService } from './msaluser.service';

describe('MsaluserService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: MsaluserService = TestBed.get(MsaluserService);
    expect(service).toBeTruthy();
  });
});
