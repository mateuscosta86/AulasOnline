import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfessorAlterComponent } from './professor-alter.component';

describe('ProfessorAlterComponent', () => {
  let component: ProfessorAlterComponent;
  let fixture: ComponentFixture<ProfessorAlterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProfessorAlterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfessorAlterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
