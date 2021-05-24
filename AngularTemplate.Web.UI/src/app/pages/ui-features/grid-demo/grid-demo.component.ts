import { Component, OnInit } from '@angular/core';
import { SideBarDef, GridApi, ColumnApi, ColDef } from 'ag-grid-community';
import { UserInfo } from '../../../@core/interfaces/user-info';
import { NbThemeService } from '@nebular/theme';

@Component({
  selector: 'ngx-grid-demo',
  templateUrl: './grid-demo.component.html',
  styleUrls: ['./grid-demo.component.scss']
})
export class GridDemoComponent implements OnInit {

  users: UserInfo[] = [];
  noRowsMessage: string = 'No rows found';

  agGridThemeClass: string = "ag-theme-balham";
  public gridApi: GridApi;
  public gridColumnApi: ColumnApi;
  public columnDefs: ColDef[];
  public domLayout: string = 'autoHeight';
  public rowSelection: string = 'multiple';
  public rowGroupPanelShow: string;
  public sideBar: SideBarDef = this.getSideBarDefs();

  constructor(private themeService: NbThemeService) {
    this.themeService.onThemeChange()
          .subscribe((theme) => {
            this.agGridThemeClass = theme?.name == 'tgh-light' ? 'ag-theme-balham' : 'ag-theme-balham-dark';
          });
   }

  ngOnInit() {
    this.rowGroupPanelShow = "always";
    
    this.users = [
      {
        userID: 1,
        fullName: 'Brian Smith',
        email: 'briansmith@test.com',
        firstName: 'Brian',
        lastName: 'Smith',
        created: new Date(),
        createdBy: 'briansmith@test.com',
        modified: new Date(),
        modifiedBy: 'briansmith@test.com',
        isEnabled: true,
        userImage: '',
        title: 'Software Engineer'
      },
      {
        userID: 2,
        fullName: 'John Doe',
        email: 'jdoe@test.com',
        firstName: 'John',
        lastName: 'Doe',
        created: new Date(),
        createdBy: 'jdoe@test.com',
        modified: new Date(),
        modifiedBy: 'jdoe@test.com',
        isEnabled: true,
        userImage: '',
        title: 'Software Engineer'
      },
      {
        userID: 3,
        fullName: 'Jane Doe',
        email: 'janedoe@test.com',
        firstName: 'Jane',
        lastName: 'Doe',
        created: new Date(),
        createdBy: 'janedoe@test.com',
        modified: new Date(),
        modifiedBy: 'janedoe@test.com',
        isEnabled: true,
        userImage: '',
        title: 'Software Engineer'
      }
    ]
  }

  /****************************************************************************/
  /*                                  AG-GRID                                 */
  /****************************************************************************/
  onGridReady(params: any) {
    this.gridColumnApi = params.columnApi;
    this.gridApi = params.api;

    this.getColumnDefs();
  }

  getSideBarDefs(): SideBarDef {
    return {
        toolPanels: ['columns']
    }
  }

  getColumnDefs() {
      this.columnDefs = 
      [
          {
              headerName: 'UserID',
              field: 'userID',
              sortable: true,
              filter: true,
          },
          {
              headerName: 'Name',
              field: 'fullName',
              enableRowGroup: true,
              sortable: true,
              filter: true,
          },
          {
              headerName: 'Email',
              field: 'email',
              enableRowGroup: true,
              sortable: true,
              filter: true,
          },
      ]
  }

}
