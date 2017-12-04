import { TestBed, inject } from '@angular/core/testing';

import { AulaService } from './aula.service';

describe('AulaService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AulaService]
    });
  });

  it('should be created', inject([AulaService], (service: AulaService) => {
    expect(service).toBeTruthy();
  }));
});
