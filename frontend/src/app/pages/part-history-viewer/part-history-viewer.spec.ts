import { ComponentFixture, TestBed } from '@angular/core/testing';
import { PartHistoryViewer } from './part-history-viewer';

describe('PartHistoryViewer', () => {
  let component: PartHistoryViewer;
  let fixture: ComponentFixture<PartHistoryViewer>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PartHistoryViewer]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PartHistoryViewer);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
