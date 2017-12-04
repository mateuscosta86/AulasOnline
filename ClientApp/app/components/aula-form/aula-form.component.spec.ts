import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AulaFormComponent } from './aula-form.component';

describe('AulaFormComponent', () => {
  let component: AulaFormComponent;
  let fixture: ComponentFixture<AulaFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AulaFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AulaFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
