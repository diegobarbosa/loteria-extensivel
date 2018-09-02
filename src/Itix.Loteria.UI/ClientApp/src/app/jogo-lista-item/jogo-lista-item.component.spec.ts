import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { JogoListaItemComponent } from './jogo-lista-item.component';

describe('JogoListaItemComponent', () => {
  let component: JogoListaItemComponent;
  let fixture: ComponentFixture<JogoListaItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ JogoListaItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(JogoListaItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
