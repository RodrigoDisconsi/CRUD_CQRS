export interface GetTodoItemsRequest {
    pageNumber: number;
    pageSize: number;
    filters: TodoItemsFilterRequest;
    orderCriteria: OrderCriteria;
  }
  
  export class TodoItemsFilterRequest {
    public textoBusqueda?: string;
  
    constructor(init?: Partial<TodoItemsFilterRequest>) {
      Object.assign(this, init);
    }
  }
  
  export class TodoItemsFilterRequestModel implements TodoItemsFilterRequest{
    public textoBusqueda?: string = '';
  }


export interface OrderCriteria {
    column: string;
    order: string;
  }