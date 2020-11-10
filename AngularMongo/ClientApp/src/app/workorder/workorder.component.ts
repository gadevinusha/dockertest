import { Component, OnInit } from "@angular/core";
import { WorkorderService } from "../Services/workorder.service";

@Component({
  selector: "app-workorder",
  templateUrl: "\workorder.component.html",
  styleUrls:["\workorder.component.css"]

})
export class WorkorderComponent implements OnInit {
 woData:WorkorderViewModel[]=[];
  //_service:WorkorderService;
  constructor(private service: WorkorderService) {
    //this._service = service;
  }
  ngOnInit(): void {
    this.woData = this.service.getWos();
    console.log(this.woData);
    //this._service.getWos((data: WorkorderViewModel[]) => {
    //  console.log(data);
    //  this.woData = data;
    //});

    }

  getWorkorders (){
    //this.woData = this._service.getWos();
    this.woData = this.service.getWos();
    console.log(this.woData);
 }
}

  export class WorkorderViewModel {
    workorder: string;
    equipmentCode: string;
    serialNo: string;
    status: string;
    testCode: string 
    testLevel :number
    actualEndDate: Date
    au:number
    auDesc :string
    assignedTo:string
}
