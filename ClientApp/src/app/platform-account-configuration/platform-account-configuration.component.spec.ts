import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PlatformAccountConfigurationComponent } from './platform-account-configuration.component';

describe('PlatformAccountConfigurationComponent', () => {
  let component: PlatformAccountConfigurationComponent;
  let fixture: ComponentFixture<PlatformAccountConfigurationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PlatformAccountConfigurationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlatformAccountConfigurationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
