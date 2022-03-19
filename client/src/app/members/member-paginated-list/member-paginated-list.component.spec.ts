import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MemberPaginatedListComponent } from './member-paginated-list.component';

describe('MemberPaginatedListComponent', () => {
  let component: MemberPaginatedListComponent;
  let fixture: ComponentFixture<MemberPaginatedListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MemberPaginatedListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MemberPaginatedListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
