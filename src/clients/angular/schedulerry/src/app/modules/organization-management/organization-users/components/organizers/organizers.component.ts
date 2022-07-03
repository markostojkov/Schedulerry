import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/operators';

import { OrganizationStateFacade } from 'src/app/core/state/organization-state.facade';
import { ButtonType } from 'src/app/shared-app/components/generic/button/button.models';
import { OrganizationUsersDialogService } from '../../organization-users-dialog.service';

@Component({
  selector: 'app-organizers',
  templateUrl: './organizers.component.html',
  styleUrls: ['./organizers.component.scss']
})
export class OrganizersComponent implements OnInit {
  public organizerColumns: string[] = ['username', 'email', 'isVerified'];
  public organizers$ = this.organizationFacade.getOrganizationOrganizers$.pipe(map((x) => (x !== null ? x : [])));
  public organizationName$ = this.organizationFacade.getOrganizationName$;
  public ButtonType = ButtonType;

  constructor(private organizationFacade: OrganizationStateFacade, private dialog: OrganizationUsersDialogService) {}

  ngOnInit(): void {}

  public newOrganizer(): void {
    this.dialog.addOrganizerDialog();
  }
}
