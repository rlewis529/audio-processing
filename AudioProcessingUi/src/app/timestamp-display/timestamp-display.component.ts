import { Component, OnInit } from '@angular/core';
import { TimestampService } from '../timestamp.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-timestamp-display',
  templateUrl: './timestamp-display.component.html',
  styleUrls: ['./timestamp-display.component.css'],
  standalone: true,
  imports:  [CommonModule]
})
export class TimestampDisplayComponent implements OnInit {
  timestamp: string | undefined;
  message: string | undefined;

  constructor(private timestampService: TimestampService) { }

  ngOnInit(): void {
    this.getTimestamp();
  }

  getTimestamp(): void {
    this.timestampService.getTimestamp().subscribe(
      data => {
        this.message = data.message; // Access the message property
        this.timestamp = data.utcTime; // Access the utcTime property
      },
      error => {
        console.error('Error fetching timestamp:', error);
      }
    );
  }
}
