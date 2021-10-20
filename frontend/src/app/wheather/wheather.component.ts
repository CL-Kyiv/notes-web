import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-wheather',
  templateUrl: './wheather.component.html',
  styleUrls: ['./wheather.component.css']
})
export class WheatherComponent implements OnInit {

  constructor(private service:SharedService) { }

  WheatherForecast:any;

  ngOnInit(): void {
    this.refreshWheterForecast();
  }

  refreshWheterForecast(){
    this.service.getWheather().subscribe(data=>{
      this.WheatherForecast=data;
    })
  }
}
