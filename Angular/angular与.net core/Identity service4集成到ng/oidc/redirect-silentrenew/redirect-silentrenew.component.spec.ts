import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RedirectSilentrenewComponent } from './redirect-silentrenew.component';

describe('RedirectSilentrenewComponent', () => {
  let component: RedirectSilentrenewComponent;
  let fixture: ComponentFixture<RedirectSilentrenewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RedirectSilentrenewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RedirectSilentrenewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
