import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TaskService, TodoTask } from './services/task';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class AppComponent implements OnInit {
  tasks: TodoTask[] = [];
  stats: any = null;
  newTask: TodoTask = { title: '', description: '', status: 'Todo' };

  constructor(private taskService: TaskService) {}

  ngOnInit() {
    this.loadTasks();
    this.loadStats();
  }

  loadStats() {
    this.taskService.getStats().subscribe(data => this.stats = data);
  }

  loadTasks() {
    this.taskService.getTasks().subscribe(data => this.tasks = data);
    this.loadStats();
  }

  addTask() {
    if (this.newTask.title) {
      this.taskService.createTask(this.newTask).subscribe(() => {
        this.newTask = { title: '', description: '', status: 'Todo' };
        this.loadTasks();
      });
    }
  }

  deleteTask(id: string | undefined) {
    if (id) {
      this.taskService.deleteTask(id).subscribe(() => this.loadTasks());
    }
  }
}
