import { Injectable } from '@angular/core';
import { DocumentType } from '../models/document-type';
import { HttpClient } from "@angular/common/http";
import { Environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class DocumentTypeService {
    _DocumentTypeData: DocumentType;
    _DocumentTypeList: DocumentType[];

    readonly _ApiUri = Environment.api.uri;

    constructor(private pHttpClient: HttpClient) { 
        
    }

    postArea(pData: DocumentType) {
        return this.pHttpClient.post(this._ApiUri + '/DocumentType/DocumentTypes', pData);
    }
    refreshList() {
        this.pHttpClient.get(this._ApiUri + '/DocumentType/DocumentTypes/GetList').toPromise().then(res => this._DocumentTypeList = res as DocumentType[]);
    }
    putArea(pData: DocumentType) {
        return this.pHttpClient.put(this._ApiUri + '/DocumentType/DocumentTypes/' + pData.DocumentTypeID, pData);

    }
    deleteArea(pID: number) {
        return this.pHttpClient.delete(this._ApiUri + '/DocumentType/DocumentTypes/' + pID);
    }
}