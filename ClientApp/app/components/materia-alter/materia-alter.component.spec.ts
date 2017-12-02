import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MateriaAlterComponent } from './materia-alter.component';

describe('MateriaAlterComponent', () => {
  let component: MateriaAlterComponent;
  let fixture: ComponentFixture<MateriaAlterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MateriaAlterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MateriaAlterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
