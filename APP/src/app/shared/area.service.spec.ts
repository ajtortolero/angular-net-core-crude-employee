import { TestBed } from '@angular/core/testing';
import { AreaService } from './area.service';

describe('AreaService', () => {
  let _Service: AreaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    _Service = TestBed.inject(AreaService);
  });

  it('should be created', () => {
    expect(_Service).toBeTruthy();
  });
});