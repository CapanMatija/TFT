import {NgModule} from '@angular/core';
import { FilmHomeComponent } from './film-home/film-home.component';
import { FilmRoutingModule } from './film-routing.module';
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
import { FilmDetailComponent } from './film-detail/film-detail.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@NgModule({
    declarations: [FilmHomeComponent, FilmDetailComponent],
    imports: [
        FilmRoutingModule, 
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
export class FilmModule {}