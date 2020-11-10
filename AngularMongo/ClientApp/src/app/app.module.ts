import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { DashboardComponent } from './Dashboard/dashboard.component';
import { WorkorderComponent } from './workorder/workorder.component';

import { WorkorderService } from './Services/workorder.service';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { MsalUserService } from './Services/msaluser.service';
import { MsalModule, MsalInterceptor, MsalGuard } from '@azure/msal-angular';  
import { environment } from '../environments/environment';
//added below for azure ad
export const protectedResourceMap: any =
  [
    [environment.baseUrl, environment.scopeUri
    ]
  ];  

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    DashboardComponent,
    WorkorderComponent,
    PageNotFoundComponent
  ],
  imports: [
    MsalModule.forRoot({
      clientID: environment.uiClienId,
      authority: 'https://login.microsoftonline.com/' + environment.tenantId,
      //cacheLocation: 'localStorage',  
      protectedResourceMap: protectedResourceMap,
      redirectUri: environment.redirectUrl
    }), //added for azure ad
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'dashboard', component: DashboardComponent },
      { path: 'workorder', component: WorkorderComponent },
      //{ path: '', component: DashboardComponent, pathMatch: 'full' },
      { path: '', component: DashboardComponent, pathMatch: 'full',canActivate: [MsalGuard]   },//added for azure ad
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      {path:'**',component:PageNotFoundComponent}
    ])
  ],
  providers: [WorkorderService,
    //added for azure ad
    MsalUserService,
    {
      provide: HTTP_INTERCEPTORS, useClass: MsalInterceptor, multi: true
    }
    //end for azure ad
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
