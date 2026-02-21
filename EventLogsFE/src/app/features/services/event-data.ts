import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { EventLogResponse, Events } from '../models/Events';


@Injectable({
  providedIn: 'root',
})

export class EventData {
  private httpClient = inject(HttpClient);

  private eventSource = new BehaviorSubject<Events[]>([]);
  public events$ = this.eventSource.asObservable();

  loadEvents() {
    this.httpClient.get<EventLogResponse>('/EventLog').subscribe(
    {
      next: (data) => this.eventSource.next(data.data) ,
      error : (err) => console.error('Failed to load events', err)
    });
  }
}
