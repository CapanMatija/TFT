import { UlogaLookup } from "./uloga.model";

export interface UserDetailModel
{
    Id?: string;
    Ime?: string;
    Prezime?: string;
    Email?: string;
    Username?: string;
    InitPassword?: string;
    RoleId?: number;
    Uloga?: UlogaLookup
}

export interface UserTableModel
{
    Id: string;
    Ime?: string;
    Prezime?: string;
    Email?: string;
    Uloga?: string;
}