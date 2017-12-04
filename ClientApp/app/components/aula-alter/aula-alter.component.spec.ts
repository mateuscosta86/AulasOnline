import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AulaAlterComponent } from './aula-alter.component';

describe('AulaAlterComponent', () => {
  let component: AulaAlterComponent;
  let fixture: ComponentFixture<AulaAlterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AulaAlterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AulaAlterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
