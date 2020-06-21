import { Component, OnInit } from '@angular/core';
import { PlatformConfigurationService } from '../services/platform-configuration.service';
import { CreatePlatformAccountConfigurationCommand } from '../models/commands/create-platform-account-configuration-command';
import { ConfiguredPlatformViewModel } from '../models/viewmodel/configured-platform-view-model';

@Component({
  selector: 'app-platform-account-configuration',
  templateUrl: './platform-account-configuration.component.html',
  styleUrls: ['./platform-account-configuration.component.css']
})
export class PlatformAccountConfigurationComponent implements OnInit {

  platformsConfigured: Array<ConfiguredPlatformViewModel>; 

  constructor(private platformConfigurationService: PlatformConfigurationService) { }

  ngOnInit() {
    this.platformConfigurationService.getConfiguredProducts().then(configuredPlatforms => this.platformsConfigured = configuredPlatforms);
  }

  createPlatformConfiguration() {
    const platformConfiguredCommand = new CreatePlatformAccountConfigurationCommand();
    this.platformConfigurationService.createConfigurationForProduct(platformConfiguredCommand);
  }
}
