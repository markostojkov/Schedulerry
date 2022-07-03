import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { ActivatedRoute, Router } from '@angular/router';
import { map, shareReplay } from 'rxjs/operators';

import { AuthService } from '../../services';
import { ButtonType } from 'src/app/shared-app/components/generic/button/button.models';
import { OrganizationStateFacade } from '../../state/organization-state.facade';
import { ServiceViewModel } from '../../state/organization-state/organization-view-models.models';

@Component({
  selector: 'app-organizer-main-view',
  templateUrl: './organizer-main-view.component.html',
  styleUrls: ['./organizer-main-view.component.scss']
})
export class OrganizerMainViewComponent implements OnInit {
  public isHandset$ = this.breakpointObserver.observe(Breakpoints.Handset).pipe(
    map((result) => result.matches),
    shareReplay()
  );
  public user$ = this.auth.currentUser();
  public services$ = this.organizationFacade.getOrganizationServices$;
  public showServicesSubmenu = false;
  public ButtonType = ButtonType;

  constructor(
    private breakpointObserver: BreakpointObserver,
    private auth: AuthService,
    private organizationFacade: OrganizationStateFacade,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((routeParams) => {
      this.organizationFacade.fetchOrganizationState(routeParams.organizationUid);
    });
  }

  public routeTo(route: string): void {
    this.router.navigate([route], { relativeTo: this.route });
  }

  public goToServiceOptions(service: ServiceViewModel): void {
    this.router.navigate(['services', service.uid], { relativeTo: this.route });
  }

  public logout(): void {
    this.auth.logout();
  }
}
