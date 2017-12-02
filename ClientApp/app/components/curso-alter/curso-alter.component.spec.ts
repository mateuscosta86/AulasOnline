import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CursoAlterComponent } from './curso-alter.component';

describe('CursoAlterComponent', () => {
  let component: CursoAlterComponent;
  let fixture: ComponentFixture<CursoAlterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CursoAlterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CursoAlterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
