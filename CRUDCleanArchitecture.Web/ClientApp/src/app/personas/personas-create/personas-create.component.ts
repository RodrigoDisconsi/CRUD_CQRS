import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PersonaDto } from '../models/query/get-personas-response';

@Component({
  selector: 'app-personas-create',
  templateUrl: './personas-create.component.html',
  styleUrls: ['./personas-create.component.css']
})
export class PersonasCreateComponent implements OnInit {
  @Output() savePersonaEmitter: EventEmitter<any> = new EventEmitter();
  
  personaForm: FormGroup = this.formBuilder.group({
    dni: ['', [Validators.required]],
    nombre: ['', [Validators.required]],
    apellido: ['', [Validators.required]],
  });

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
  }

  get personaControl(): { [key: string]: AbstractControl } {
    return this.personaForm.controls;
  }

  getErrorMessage(field: string): string {
    let retorno = "";
    if(this.personaControl[field].hasError("required")) {
      retorno = "El campo es requerido.";
    }
    return retorno;
  }

  isNotValidField(field: string): boolean {
    return (this.personaControl[field].touched && this.personaControl[field].dirty);
  }


  emitPersona(){
    const personaDto: PersonaDto = this.personaForm.value as PersonaDto;
    this.savePersonaEmitter.emit(personaDto);
  }
}
