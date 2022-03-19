import { Component, OnInit } from '@angular/core';
import { Member } from 'src/app/_models/member';
import { Pagination } from 'src/app/_models/pagination';
import { UserParams } from 'src/app/_models/userParams';
import { GuestService } from 'src/app/_services/guest.service';

@Component({
  selector: 'app-member-paginated-list',
  templateUrl: './member-paginated-list.component.html',
  styleUrls: ['./member-paginated-list.component.css']
})
export class MemberPaginatedListComponent implements OnInit {
  userParams: UserParams;
  members: Member[] = [];
  pagination: Pagination;
  genderList = [{value: 'all', display: 'All'}, {value: 'male', display: 'Males'}, {value: 'female', display: 'Females'}];

  constructor(private guest_srv: GuestService) {
    this.userParams = new UserParams(null);
   }

  ngOnInit(): void {
    this.loadMembers();
  }


  loadMembers() {
    this.guest_srv.getMembers(this.userParams).subscribe(response => {
      this.members = response.result;
      this.pagination = response.pagination;
    })
  }

  resetFilters() {
    this.userParams = new UserParams(null);
    this.loadMembers();
  }

  pageChanged(event: any) {
    this.userParams.pageNumber = event.page;
    //this.memberService.setUserParams(this.userParams);
    this.loadMembers();
  }

}
