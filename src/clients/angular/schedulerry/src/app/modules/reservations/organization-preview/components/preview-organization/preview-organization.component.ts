import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';

import { OrganizationStateFacade } from 'src/app/core/state/organization-state.facade';
import { ServiceViewModel } from 'src/app/core/state/organization-state/organization-view-models.models';
import { OrganizationState } from 'src/app/core/state/organization-state/organization.state';
import { ButtonType } from 'src/app/shared-app/components/generic/button/button.models';

@Component({
  selector: 'app-preview-organization',
  templateUrl: './preview-organization.component.html',
  styleUrls: ['./preview-organization.component.scss']
})
export class PreviewOrganizationComponent implements OnInit {
  ButtonType = ButtonType;
  organization$!: Observable<OrganizationState>;
  constructor(private organizationFacade: OrganizationStateFacade, private router: Router, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.organization$ = this.organizationFacade.getOrganization$;
  }

  public goToService(service: ServiceViewModel): void {
    this.router.navigate(['services', service.uid], { relativeTo: this.route });
  }
}
