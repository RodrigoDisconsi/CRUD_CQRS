import { Component, OnInit } from '@angular/core';
import { PersonasService } from '../services/personas.service';
import { GetPersonasRequest, PersonasFilterRequestModel } from '../models/query/get-personas-request';
import { PersonaDto } from '../models/query/get-personas-response';
import { FormArray, FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { Subject, debounceTime, distinctUntilChanged, filter, map } from 'rxjs';
import { QueryService } from 'src/app/shared/services/query.service';

const itemsPageOptions = [
  { key: 2, value: 2 },
  { key: 5, value: 5 },
  { key: 10, value: 10 },
];

const rowsLength: number = 1;

interface OrderCriteria {
  column: string;
  order: string;
}

@Component({
  selector: 'app-personas-list',
  templateUrl: './personas-list.component.html',
  styleUrls: ['./personas-list.component.css']
})
export class PersonasListComponent implements OnInit {
  public getPersonasRequest: GetPersonasRequest;
  public itemsPageOptions = itemsPageOptions;
  private order: OrderCriteria = { column: '', order: '' };
  activeSearch:boolean = false;
  // personas: PersonaDto[];
  rowsLength: number = 1;
  public formSearch!: FormGroup;
  public personas: Subject<PersonaDto[]> = new Subject<PersonaDto[]>();

  private get query() {
    return this.formSearch?.get('search') as FormArray;
  }


  constructor(private personasService: PersonasService, private formBuilder: FormBuilder, private queryService: QueryService) { 
    this.getPersonasRequest = {
      pageNumber: 1,
      pageSize: this.itemsPageOptions[0].value,
      filters: new PersonasFilterRequestModel(),
      orderCriteria: this.order,
    };
  }

  ngOnInit(): void {
    this.fillGrid();
    this.initForm(); 
    this.getPersonasByCriteria();
  }

  private initForm(): void {
    this.formSearch = this.formBuilder.group({
      search: new FormControl(''),
    });
  }

  public fillGrid = (): void => {
    this.personasService.GetPersonas(this.getPersonasRequest).subscribe(
      result => {
        this.setPaginationInfo(result.personas);
        this.personas.next(result.personas.items);
      }, err => this.personas.error(err)
    );
  }

  private setPaginationInfo(response: any): void {
    this.getPersonasRequest.pageNumber = response.pageIndex;
    this.rowsLength = response.totalCount;
  }

  private getPersonasByCriteria(): void {
    this.query?.valueChanges
      .pipe(
        map((query: string) => this.queryService.clearQuery(query)),
        debounceTime(600),
        distinctUntilChanged(),
        filter((query: string) => this.queryService.queryIsValid(query))
      )
      .subscribe((query: string) => {
        this.getPersonasRequest.filters.textoBusqueda = query;
        this.fillGrid();
      });
  }


  onSavePersona(persona){
    this.personasService.createPerson(persona).subscribe((resp) =>{
      this.fillGrid();
      console.log(resp);
    })
  }

  deletePersona(id:number){
    this.personasService.deletePerson(id).subscribe((resp) =>{
      this.fillGrid();
    })
  }

  public onPageChange(page): void {
    this.getPersonasRequest.pageNumber = page;
    this.fillGrid();
    console.log(this.getPersonasRequest.pageNumber);
  }

  onChangePageSize(){
    this.fillGrid();
    console.log(this.getPersonasRequest.pageSize);
  }
}
