export interface GetPersonasRequest {
    pageNumber: number;
    pageSize: number;
    filters: PersonasFilterRequest;
    orderCriteria: OrderCriteria;
  }
  
  export class PersonasFilterRequest {
    public textoBusqueda?: string;
  
    constructor(init?: Partial<PersonasFilterRequest>) {
      Object.assign(this, init);
    }
  }
  
  export class PersonasFilterRequestModel implements PersonasFilterRequest{
    public textoBusqueda?: string = '';
  }


export interface OrderCriteria {
    column: string;
    order: string;
  }