import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovementRegistration } from './movement-registration';

describe('MovementRegistration', () => {
  let component: MovementRegistration;
  let fixture: ComponentFixture<MovementRegistration>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MovementRegistration]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MovementRegistration);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
