import { Component, OnInit, OnDestroy } from '@angular/core';
import { TodoRepositoryService } from '../services/todo-repository.service';
import { Observable } from 'rxjs/Observable';
import { ToDoItem } from '../services/todo';
import { OAuthService } from 'angular-oauth2-oidc';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css']
})
export class TodoListComponent implements OnInit, OnDestroy {

  toDoItems$: Observable<ToDoItem[]>;

  newToDoItemText = '';

  public isLoggedIn = false;

  private authSubscription: Subscription;

  constructor(private toDoRepo: TodoRepositoryService, private oAuthService: OAuthService) {
    this.toDoItems$ = toDoRepo.todoItems$;
  }

  ngOnInit() {
    this.authSubscription = this.oAuthService.events.subscribe(() => this.updateAuthState());
    this.updateAuthState();
  }

  ngOnDestroy() {
    if (this.authSubscription) {
      this.authSubscription.unsubscribe();
    }
  }

  private updateAuthState() {
    this.isLoggedIn = this.oAuthService.hasValidAccessToken();
  }

  createNewToDoItem() {
    if (this.newToDoItemText) {
      this.toDoRepo.add(this.newToDoItemText).subscribe();
      this.newToDoItemText = '';
    }
  }

  removeToDoItem(todo: ToDoItem) {
    this.toDoRepo.remove(todo.id).subscribe();
  }

}
