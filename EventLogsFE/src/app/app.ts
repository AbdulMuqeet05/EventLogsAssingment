import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { EventLogsComponent } from "./features/event-logs-component/event-logs-component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, EventLogsComponent],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('EventLogsFE');
}
