export interface GetPersonasResponse {
    personas: GetPersonasWithPaginationResponse;
}

export interface PersonaDto {
    personaId: number;
    dni: number;
    nombre: string;
    apellido: string;
}

export interface GetPersonasWithPaginationResponse {
  items: PersonaDto[];
  pageIndex: number;
  totalPages: number;
  totalCount: number;
}