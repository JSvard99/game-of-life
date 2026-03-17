import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ControlMenu } from './control-menu';

describe('ControlMenu', () => {
  let component: ControlMenu;
  let fixture: ComponentFixture<ControlMenu>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ControlMenu]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ControlMenu);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
