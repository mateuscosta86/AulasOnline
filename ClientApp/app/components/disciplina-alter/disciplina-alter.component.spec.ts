import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DisciplinaAlterComponent } from './disciplina-alter.component';

describe('DisciplinaAlterComponent', () => {
  let component: DisciplinaAlterComponent;
  let fixture: ComponentFixture<DisciplinaAlterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DisciplinaAlterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DisciplinaAlterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
