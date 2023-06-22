export interface GetTodoItemsResponse {
    todoItems: TodoItemsWithPaginationResponse;
}

export interface TodoItemsDto {
    id: number;
    listId: number;
    title: string;
    done: boolean;
}

export interface TodoItemsWithPaginationResponse {
  items: TodoItemsDto[];
  pageIndex: number;
  totalPages: number;
  totalCount: number;
}