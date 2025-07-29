import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PartManagement } from './part-management';

describe('PartManagement', () => {
  let component: PartManagement;
  let fixture: ComponentFixture<PartManagement>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PartManagement]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PartManagement);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
