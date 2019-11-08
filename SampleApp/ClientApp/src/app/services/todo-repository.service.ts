import { Injectable, Inject } from '@angular/core';
import { ToDoItem } from './todo';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { HttpClient } from '@angular/common/http';
import { BASE_URL } from '../../baseUrl';
import { Subject } from 'rxjs/Subject';
import { tap, repeatWhen, repeat } from 'rxjs/operators';

@Injectable()
export class TodoRepositoryService {

  private refreshSubject = new Subject<any>();

  constructor(private http: HttpClient, @Inject(BASE_URL) private baseUrl: string) { }

  public get todoItems$() {
    return this.http.get<ToDoItem[]>(`${this.baseUrl}api/todos`)
      .pipe(
        repeatWhen(_ => this.refreshSubject.asObservable())
      )
      ;
  }

  public add(text: string) {
    return this.http.post(`${this.baseUrl}api/todos`, {
      id: 0,
      text: text
    })
    .pipe(
      tap(item => this.refreshSubject.next(item))
    )
    ;
  }

  public remove(itemId: number) {
    return this.http.delete(`${this.baseUrl}api/todos/${itemId}`)
      .pipe(
        tap(item => this.refreshSubject.next(item))
      );
  }

  public findItem(itemId: number) {
    return this.http.get<ToDoItem>(`${this.baseUrl}api/todos/${itemId}`);
  }

}
