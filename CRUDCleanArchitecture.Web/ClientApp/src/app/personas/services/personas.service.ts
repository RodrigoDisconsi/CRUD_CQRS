import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { GetPersonasResponse } from '../models/query/get-personas-response';
import { GetPersonasRequest } from '../models/query/get-personas-request';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { CreatePersonaRequest } from '../models/commands/create-persona-request';

@Injectable({
  providedIn: 'root'
})
export class PersonasService {
  public baseUrl = `${environment.rootApi}`;

  constructor(private httpClient: HttpClient) { }

  public GetPersonas(prestadoresRequest:GetPersonasRequest) : Observable<GetPersonasResponse> {
    var params = new HttpParams()
      .set('PageNumber', prestadoresRequest.pageNumber.toString())
      .set('PageSize', prestadoresRequest.pageSize.toString())
      .set('TextoBusqueda', prestadoresRequest.filters.textoBusqueda.toString())
      .set('OrderCriteria.Column', prestadoresRequest.orderCriteria.column)
      .set('OrderCriteria.Order', prestadoresRequest.orderCriteria.order);
    return this.httpClient.get<GetPersonasResponse>(this.baseUrl + `Personas`, {
      params: params
    });
  }

  public createPerson(createPersonaRequest: CreatePersonaRequest): Observable<any> {
  return this.httpClient.post<any>(this.baseUrl + `Personas`, createPersonaRequest);
  }

  public deletePerson(id: number): Observable<any> {
  const url = `${this.baseUrl}Personas/${id}`;
    return this.httpClient.delete(url);
  }
}
