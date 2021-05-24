import { Injectable } from '@angular/core';
import { URLHelper } from '../utils/url-helper';
import { APPHttpService } from './app-http.service';

@Injectable()
export class AdminService {

    constructor(private urlHelper: URLHelper, private httpSerivce: APPHttpService) { }

}