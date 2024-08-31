import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TimestampDisplayComponent } from './timestamp-display/timestamp-display.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, TimestampDisplayComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'AudioProcessingUi';
}
