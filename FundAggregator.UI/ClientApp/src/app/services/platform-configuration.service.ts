import { Injectable } from '@angular/core';
import { ConfiguredPlatformViewModel } from '../models/viewmodel/configured-platform-view-model';
import { CreatePlatformAccountConfigurationCommand } from '../models/commands/create-platform-account-configuration-command';

@Injectable({
  providedIn: 'root'
})
export class PlatformConfigurationService {

  constructor() { }

  getConfiguredProducts(): Promise<Array<ConfiguredPlatformViewModel>> {
    const hlConfiguration: ConfiguredPlatformViewModel = {
      platformLogoName: "HargreavesLansdown",
      platformName: "Hargreaves Lansdown",
      username: "Username1",
      password: "Password1", 
      configurationStatus: "Invalid"
    };
    const vanguardConfiguration: ConfiguredPlatformViewModel = {
      platformLogoName: "Vanguard",
      platformName: "Vanguard",
      username: "Username1",
      password: "Password1",
      configurationStatus: "Active"
    };
    return Promise.resolve([hlConfiguration, vanguardConfiguration]);
  }

  createConfigurationForProduct(createProductConfigurationCommand: CreatePlatformAccountConfigurationCommand) {
    return Promise.resolve("");
  }
}
