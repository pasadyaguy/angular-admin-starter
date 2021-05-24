import { Component, OnInit } from '@angular/core';
import { UserInfo } from '../../../@core/interfaces/user-info';
import { APPHttpService } from '../../../@core/data/app-http.service';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.scss']
})
export class SettingsComponent implements OnInit {

  user: UserInfo = new UserInfo();

  constructor(private httpService: APPHttpService) { }

  ngOnInit() {
    
  }

}
