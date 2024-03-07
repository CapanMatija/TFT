import { DirektorLookupModel } from "./direktor.model";
import { Zanr } from "./zanr.models";

export interface FilmDetailModel {
    Id?: number;
    Naslov?: string;
    Opis?: string;
    Trajanje?: number;
    Budzet?: number;
    PocetakSnimanja?: Date;
    KrajSnimanja?: Date;
    Zanrovi?: Zanr[]; 
    Direktor?: DirektorLookupModel;
    DirektorId?: number;
}