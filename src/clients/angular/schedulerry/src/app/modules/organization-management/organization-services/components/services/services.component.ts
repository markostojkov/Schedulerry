import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OrganizationStateFacade } from 'src/app/core/state/organization-state.facade';
import { ServiceViewModel } from 'src/app/core/state/organization-state/organization-view-models.models';
import { ButtonType } from 'src/app/shared-app/components/generic/button/button.models';
import { OrganizationServicesDialog } from '../../organization-services-dialog.service';

@Component({
  selector: 'app-services',
  templateUrl: './services.component.html',
  styleUrls: ['./services.component.scss']
})
export class ServicesComponent implements OnInit {
  public ButtonType = ButtonType;
  public services$ = this.organizationFacade.getOrganizationServices$;

  constructor(
    private organizationFacade: OrganizationStateFacade,
    private dialog: OrganizationServicesDialog,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {}

  public newService(): void {
    this.dialog.addServiceDialog().subscribe();
  }

  public goToServiceOptions(service: ServiceViewModel): void {
    this.router.navigate([service.uid], { relativeTo: this.route });
  }
}
