import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { GetTodoItemsRequest } from '../models/query/get-todo-items-request';
import { GetTodoItemsResponse } from '../models/query/get-todo-items-response';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  public baseUrl = `${environment.rootApi}`;

  constructor(private httpClient: HttpClient) { }

  public GetTodoItemsWhitPagination(prestadoresRequest:GetTodoItemsRequest) : Observable<GetTodoItemsResponse> {
    var params = new HttpParams()
      .set('PageNumber', prestadoresRequest.pageNumber.toString())
      .set('PageSize', prestadoresRequest.pageSize.toString())
      .set('TextoBusqueda', prestadoresRequest.filters.textoBusqueda.toString())
      .set('OrderCriteria.Column', prestadoresRequest.orderCriteria.column)
      .set('OrderCriteria.Order', prestadoresRequest.orderCriteria.order);
    return this.httpClient.get<GetTodoItemsResponse>(this.baseUrl + `GetTodoItems`, {
      params: params
    });
  }
}
