import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NumeroListaComponent } from './numero-lista.component';

describe('NumeroListaComponent', () => {
  let component: NumeroListaComponent;
  let fixture: ComponentFixture<NumeroListaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NumeroListaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NumeroListaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
