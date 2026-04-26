import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface TodoTask {
  id?: string;
  title: string;
  description: string;
  status: string;
}

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  private apiUrl = 'http://localhost:5151/api/tasks';
  private analyticsUrl = 'http://localhost:8000/api/analytics/stats'; // Python port

  constructor(private http: HttpClient) { }
  getStats(): Observable<any> {
    return this.http.get<any>(this.analyticsUrl);
  }

  getTasks(): Observable<TodoTask[]> {
    return this.http.get<TodoTask[]>(this.apiUrl);
  }

  createTask(task: TodoTask): Observable<TodoTask> {
    return this.http.post<TodoTask>(this.apiUrl, task);
  }

  deleteTask(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
