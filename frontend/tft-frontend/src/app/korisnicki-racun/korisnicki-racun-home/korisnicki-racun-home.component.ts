import { ChangeDetectorRef, Component, OnInit } from "@angular/core";
import {  UserDetailModel, UserTableModel } from "../../models/user.models";
import { UserEntityService } from "../../services/user-entity.service";
import { UlogaLookup } from "../../models/uloga.model";

@Component({
    selector: 'app-korisnicki-racun-home',
    templateUrl: './korisnicki-racun-home.component.html',
    styleUrls: ['./korisnicki-racun-home.component.scss']
})
export class KorisnickiRacunHomeComponent implements OnInit{
    users: UserTableModel[] = [];
    userDetail: UserDetailModel = {};
    selectedId: number | null = null;

    uloge: UlogaLookup[] = [
    {
        Id: 0,
        Naziv: 'Administrator'
    },
    {
        Id: 2,
        Naziv: 'Direktor'
    },
    {
        Id: 3,
        Naziv: 'Glumac'
    }]

    isEdit = false;

    constructor(private userEntityService: UserEntityService, private cdref: ChangeDetectorRef) {}

    ngOnInit(): void {
        this.getUsers();
    }

    getUsers(): void {
        this.userEntityService.getUsers().subscribe((response: any) => {
            this.users = [];
            for (let i = 0; i < response.value.length; i++) {
                this.users.push( {
                        Id: response.value[i].id,
                        Ime: response.value[i].ime,
                        Prezime: response.value[i].prezime,
                        Email: response.value[i].email,
                        Uloga: response.value[i].roleId == 0 ? 'Administrator' : response.value[i].roleId == 1 ? 'Direktor' : response.value[i].roleId == 2 ? 'Glumac' : 'Nema ulogu'
                    });
            }        
        });

        
    }

    onEditUser(Id?: number): void {
        this.selectedId = Id ?? null;
        if (Id == null) 
        {
            this.userDetail = {};
        } else {
            this.userEntityService.getUser(Id).subscribe((result) => {
                this.userDetail = result;
            })
        }
        this.isEdit = true;
        this.cdref.detectChanges();
    }

    onEditDialogClose(): void {
        this.isEdit = false;
        this.selectedId = null;
    }

    onSubmit(): void {
        this.userDetail.RoleId = this.userDetail.Uloga?.Id
        this.userEntityService.saveUser(this.userDetail).subscribe(() => {
            this.isEdit = false;
            this.getUsers();
        })
    }
}

export interface ResponseModel {
    result: string;
    value: Array<any>
}