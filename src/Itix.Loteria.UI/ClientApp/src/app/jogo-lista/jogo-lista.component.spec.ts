import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { JogoListaComponent } from './jogo-lista.component';

describe('JogoListaComponent', () => {
  let component: JogoListaComponent;
  let fixture: ComponentFixture<JogoListaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ JogoListaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(JogoListaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
