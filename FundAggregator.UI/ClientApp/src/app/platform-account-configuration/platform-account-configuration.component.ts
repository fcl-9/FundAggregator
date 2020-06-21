import { Component, OnInit } from '@angular/core';
import { PlatformConfigurationService } from '../services/platform-configuration.service';
import { CreatePlatformAccountConfigurationCommand } from '../models/commands/create-platform-account-configuration-command';
import { ConfiguredPlatformViewModel } from '../models/viewmodel/configured-platform-view-model';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-platform-account-configuration',
  templateUrl: './platform-account-configuration.component.html',
  styleUrls: ['./platform-account-configuration.component.css']
})
export class PlatformAccountConfigurationComponent implements OnInit {

  platforms: Array<string>;
  platformsConfigured: Array<ConfiguredPlatformViewModel>; 
  closeResult = '';

  newPlatformConfiguration: CreatePlatformAccountConfigurationCommand;

  constructor(private platformConfigurationService: PlatformConfigurationService, private modalService: NgbModal) { }

  ngOnInit() {
    this.platformConfigurationService.getConfiguredProducts().then(configuredPlatforms => this.platformsConfigured = configuredPlatforms);
    this.platformConfigurationService.getAvailablePlatforms().then(availablePlatforms => this.platforms = availablePlatforms);
  }

  createPlatformConfiguration() {
    this.platformConfigurationService.createConfigurationForProduct(this.newPlatformConfiguration);
  }

  open(content) {
    this.newPlatformConfiguration = new CreatePlatformAccountConfigurationCommand();
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }
}
