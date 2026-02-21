import { ChangeDetectorRef, Component, OnDestroy, OnInit, inject } from '@angular/core';
import { EventData } from '../services/event-data';
import { BehaviorSubject, Observable, Subscription } from 'rxjs';
import { Events } from '../models/Events';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-event-logs-component',
  imports: [CommonModule],
  templateUrl: './event-logs-component.html',
  styleUrl: './event-logs-component.scss',
})
export class EventLogsComponent implements OnInit, OnDestroy {


  private readonly eventlogService = inject(EventData);
  public events : Events[] = [];
  private subscriptions? :Subscription ;
  private cdr = inject(ChangeDetectorRef);
  ngOnInit(): void {
    this.eventlogService.loadEvents();
    var eventSubs = this.eventlogService.events$.subscribe({
      next : (data)=> {
        this.events = data;
        this.cdr.detectChanges();
        console.log('Data Reveived: ', this.events);
      },
      error : (err)=> console.error('Error while receiving events', err)

    });
    this.subscriptions?.add(eventSubs);
  }

  ngOnDestroy(): void {
    this.subscriptions?.unsubscribe();
  }

}
