import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { UserProfileComponent } from '../user/user-profile/user-profile.component';

@Injectable()
export class PreventUnsavedChanges
  implements CanDeactivate<UserProfileComponent> {
  canDeactivate(component: UserProfileComponent) {
    if (component.editForm!.dirty) {
      return confirm(
        'Are you sure you want to continue?  Any unsaved changes will be lost'
      );
    }
    return true;
  }
}
