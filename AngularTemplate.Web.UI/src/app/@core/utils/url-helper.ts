import { Injectable } from '@angular/core';
import { APPHttpService } from '../data/app-http.service';

@Injectable()
export class URLHelper {
    constructor(private httpService: APPHttpService) {

    }

    private env: string = this.httpService.getCurrentEnvironment();
    private Server: string = this.getServerUrl(this.env);

    getServerUrl(env: string): string {
        let server = "";
        switch (env) {
            case "LOCALDEV": {
                server = "http://localhost/project/";
                break;
            }
            case "TEST": {
                server = "https://yourserver-dev-api.domain.com/";
                break;
            }
            case "PROD": {
                server = "https://yourserver-api.domain.com/";
                break;
            }
            default: {
                console.error('No Env Found');
                server = "https://yourserver-api.domain.com/";
            }
        }
        return server;
    }

    // Endpoints
    public DemoEndpoint = this.Server + 'api/<controller>/<function>';
    
}
