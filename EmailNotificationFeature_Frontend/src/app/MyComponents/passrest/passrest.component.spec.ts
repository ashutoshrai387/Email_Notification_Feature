import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PassrestComponent } from './passrest.component';

describe('PassrestComponent', () => {
  let component: PassrestComponent;
  let fixture: ComponentFixture<PassrestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PassrestComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PassrestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
