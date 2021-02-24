import { Injectable } from '@angular/core';
import { Area } from '../models/area';
import { HttpClient } from "@angular/common/http";
import { Environment } from 'src/environments/environment';

@Injectable({
	providedIn: 'root'
})
export class AreaService {
	_AreaData: Area;
	_AreaList: Area[];

	readonly _ApiUri = Environment.api.uri;

	constructor(private pHttpClient: HttpClient) { }

	postArea(pData: Area) {
		return this.pHttpClient.post(this._ApiUri + '/Area/Areas', pData);
	}
	refreshList() {
		this.pHttpClient.get(this._ApiUri + '/Area/Areas/GetList').toPromise().then(res => this._AreaList = res as Area[]);
	}
	putArea(pData: Area) {
		return this.pHttpClient.put(this._ApiUri + '/Area/Areas/' + pData.AreaID, pData);

	}
	deleteArea(pID: number) {
		return this.pHttpClient.delete(this._ApiUri + '/Area/Areas/' + pID);
	}
}