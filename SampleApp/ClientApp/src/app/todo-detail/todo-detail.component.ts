import { Component, OnInit, OnDestroy } from '@angular/core';
import { TodoRepositoryService } from '../services/todo-repository.service';
import { ActivatedRoute } from '@angular/router';
import { ToDoItem } from '../services/todo';
import { flatMap } from 'rxjs/operators';
import { Subscription } from 'rxjs/Subscription';

@Component({
  selector: 'app-todo-detail',
  templateUrl: './todo-detail.component.html',
  styleUrls: ['./todo-detail.component.css']
})
export class TodoDetailComponent implements OnInit, OnDestroy {
  toDoItem?: ToDoItem

  private routeSubscription: Subscription;

  constructor(private toDoRepo: TodoRepositoryService,
              private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.routeSubscription = this.activatedRoute.params
      .pipe(
        flatMap(params => {
          const id = +params['id'];
          return this.toDoRepo.findItem(id);
        }
      )
    ).subscribe(toDoItem => this.toDoItem = toDoItem);
  }

  ngOnDestroy(): void {
    this.routeSubscription.unsubscribe();
  }
}
