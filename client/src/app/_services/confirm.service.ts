import { LiteralExpr } from '@angular/compiler';
import { Injectable, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Observable } from 'rxjs';
import { ConfirmDialogComponent } from '../modals/confirm-dialog/confirm-dialog.component';

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
  btnOkText = 'Ok', btnCancelText = 'Cancel'): Observable<boolean> {
    const config = {
      initialState: {
        title,
        message,
        btnOkText,
        btnCancelText
      }
    }
    
    this.bsModelRef = this.modalService.show(ConfirmDialogComponent, config);
    this.bsModelRef.onHide

    return new Observable<boolean>(this.getResult());

    // this.message = 'Confirmed!';
    // this.modalRef?.hide();
  }

  private getResult() {
    return (observer) => {

      const subscription = this.bsModelRef.onHidden.subscribe(() => {
        observer.next(this.bsModelRef.content.result);
        observer.complete();
      })

      return {
        unsubscribe() {
          subscription.unsubscribe();
        }
      }
    }
  }
 
  decline(): void {
    this.message = 'Declined!';
    this.bsModelRef?.hide();
  }
}
