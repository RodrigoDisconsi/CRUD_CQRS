import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class QueryService {
  private readonly minQueryLength = 3;

  public queryIsValid = (query: string): boolean => (!!query && query.length >= this.minQueryLength) || this.queryEmpty(query);

  public queryEmpty = (query: string): boolean => !query || query.length === 0;

  public clearQuery = (query: string): string => query?.trim();

  constructor() { }
}
