import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ButtonType } from 'src/app/shared-app/components/generic/button/button.models';
import { AuthService } from '../../services';
import { OrganizationStateFacade } from '../../state/organization-state.facade';

@Component({
  selector: 'app-customer-main-view',
  templateUrl: './customer-main-view.component.html',
  styleUrls: ['./customer-main-view.component.scss']
})
export class CustomerMainViewComponent implements OnInit {
  public user$ = this.auth.currentUser();
  public services$ = this.organizationFacade.getOrganizationServices$;
  public showServicesSubmenu = false;
  public ButtonType = ButtonType;

  constructor(
    private auth: AuthService,
    private organizationFacade: OrganizationStateFacade,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((routeParams) => {
      this.organizationFacade.fetchOrganizationStateForPreview(routeParams.organizationUid);
    });
  }

  public logout(): void {
    this.auth.logout();
  }
}
