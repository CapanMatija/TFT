import {NgModule} from '@angular/core';
import { KorisnickiRacunRoutingModule } from './korisnicki-racun-routing.module';
import { TableModule } from 'primeng/table';

import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { InputNumberModule } from 'primeng/inputnumber';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { CalendarModule } from 'primeng/calendar';
import { MultiSelectModule } from 'primeng/multiselect';
import { DropdownModule } from 'primeng/dropdown';

import { ToolbarModule } from 'primeng/toolbar';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { KorisnickiRacunHomeComponent } from './korisnicki-racun-home/korisnicki-racun-home.component';

@NgModule({
    declarations: [
        KorisnickiRacunHomeComponent
    ],
    imports: [
        KorisnickiRacunRoutingModule, 
        TableModule, 
        ButtonModule, 
        DialogModule, 
        ToolbarModule, 
        InputTextModule, 
        InputNumberModule, 
        InputTextareaModule, 
        CalendarModule, 
        MultiSelectModule,
        CommonModule,
        FormsModule,
        DropdownModule
    ]
})
export class KorisnickiRacunModule {}