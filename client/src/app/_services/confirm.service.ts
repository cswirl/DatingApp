import { Injectable, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Injectable({
  providedIn: 'root'
})
export class ConfirmService {
  bsModelRef?: BsModalRef;
  message?: string;
  
  constructor(private modalService: BsModalService) {}

  // openModal(template: TemplateRef<any>) {
  //   this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  // }
 
  confirm(title = 'Confirmation', message = 'Are you sure you want to do this?', 
  btnOkText = 'Ok', btnCancelText = 'Cancel'): void {
    const config = {
      initialState: {
        title,
        message,
        btnOkText,
        btnCancelText
      }
    }
    
    this.bsModelRef = this.modalService.show('confirm', config)
    
    // this.message = 'Confirmed!';
    // this.modalRef?.hide();
  }
 
  decline(): void {
    this.message = 'Declined!';
    this.bsModelRef?.hide();
  }
}
