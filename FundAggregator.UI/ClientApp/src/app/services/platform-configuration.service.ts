import { Injectable, ɵConsole } from '@angular/core';
import { ConfiguredPlatformViewModel } from '../models/viewmodel/configured-platform-view-model';
import { CreatePlatformAccountConfigurationCommand } from '../models/commands/create-platform-account-configuration-command';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AppConfig } from '../config';

@Injectable({
  providedIn: 'root'
})
export class PlatformConfigurationService {

  constructor(private httpClient: HttpClient) {
  }

  getConfiguredProducts(): Promise<Array<ConfiguredPlatformViewModel>> {

  
    return this.httpClient.get<Array<ConfiguredPlatformViewModel>>(AppConfig.apiEndpoint + "/platform/accounts").toPromise();
  }

  getAvailablePlatforms(): Promise<Array<string>>{

    return this.httpClient.get<Array<string>>(AppConfig.apiEndpoint + "/platform").toPromise();
  }

  createConfigurationForProduct(createProductConfigurationCommand: CreatePlatformAccountConfigurationCommand) {
    let headers = new HttpHeaders({'Content-Type': 'application/json'});
    let options = { headers: headers };
    return this.httpClient.post(AppConfig.apiEndpoint + "/platform/accounts", JSON.stringify(createProductConfigurationCommand), options).toPromise();
  }
}
