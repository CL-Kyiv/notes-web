import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-wheather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css'],
})
export class WeatherComponent implements OnInit {
  constructor(private service: SharedService) {}

  forecastData: any;

  ngOnInit(): void {
    this.refreshWheterForecast();
  }

  refreshWheterForecast() {
    this.service.getWheather().subscribe((data) => {
      this.forecastData = data;
    });
  }
}
