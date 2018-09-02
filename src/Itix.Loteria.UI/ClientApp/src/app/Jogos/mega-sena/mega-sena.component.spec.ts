import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MegaSenaComponent } from './mega-sena.component';

describe('MegaSenaComponent', () => {
  let component: MegaSenaComponent;
  let fixture: ComponentFixture<MegaSenaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MegaSenaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MegaSenaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
