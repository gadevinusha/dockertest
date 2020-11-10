import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { WorkorderViewModel } from '../workorder/workorder.component';

@Injectable({
  providedIn: 'root'
})
//@Injectable()
export class WorkorderService {
  wos: WorkorderViewModel[]= [];
  constructor(private httpClient: HttpClient) {
   
  }

  getWos() {
    this.httpClient.get<WorkorderViewModel[]>('https://localhost:44373/api/workorder').subscribe(result => {
      this.wos = result;
    }, error => console.error(error));
    return this.wos;
  }

}
