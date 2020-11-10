import { Component } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { MsalUserService } from "../Services/msaluser.service";


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.less']
})
export class DashboardComponent {
  ds: DashboardViewModel[] = [];
  constructor(private httpClient: HttpClient, private msalService: MsalUserService ) { }  
  //constructor(httpClient: HttpClient) {
  //  httpClient.get<DashboardViewModel[]>('https://localhost:44373/api/dashboard', this.httpOptions).subscribe(result => {
  //    this.ds = result;
  //  }, error => console.error(error));
  //}
  ngOnInit(): void {
    this.httpClient.get<DashboardViewModel[]>('https://localhost:44373/api/dashboard', this.httpOptions).subscribe(result => {
      this.ds = result;
    }, error => console.error(error));
  }
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + this.msalService.GetAccessToken()  //for azure ad only
      //'Authorization': 'Basic ' + btoa("username:password")//this is compulsory for basic authentication
    })
  }
  OnClick(item) {
    window.location.href = item.url;
  }
  getClass(item) {
    return "rite-widget-icon " + item.css;
  }
  getCurrentUserInfo() {
    this.msalService.getCurrentUserInfo();
  }

  logout() {
    this.msalService.logout();
  }  
}
//, { withCredentials: true }
interface DashboardViewModel {
  name :string,
  desc :string,
  css :string,
  url :string
}
