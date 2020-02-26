import { Roles } from 'shared/models/roles';
import { Injectable } from '@angular/core';
import { CommonServiceOld } from 'shared/services/common.service';
import { of } from 'rxjs';

@Injectable({
	providedIn: 'root'
})
export class RuoloService extends CommonServiceOld {


	/**
	 * Add a new role in database.
	 * @param role 
	 */
	add(role : Roles) {
		//return of(role);
		return this.http.post<Roles>('/api/RoleManagement/ManageInsertNewRole', role);
	}

	/**
	 * Update a role.
	 * @param role 
	 */
	update(role : Roles) {
		return this.http.put<Roles>('/api/RoleManagement/ManageUpdateRole', role);
	}

	/**
	 * Delete a role from database.
	 * @param roleName 
	 */
	delete(roleName: string) {
		return this.http.delete<any>('/api/RoleManagement/deleteruolo/' + roleName + '/' + this.user.uteCliId);
	}

	detail(role: Roles) {
		return this.http.post<Roles>(`/api/RoleManagement/GetDetailsByObj`, role);
	}


	/**
	 * Get all the permissions of a role.
	 * @param role 
	 */
	getAllUsersForRole(role: string) {
		return this.http.get(`/api/RoleManagement/GetActiveUserForRole/${role}/${this.user.uteCliId}`);
	}

	/**
	 * Get all the assigned users of a role.
	 * @param role 
	 */
	getAllPermissionsForRole(role: string) {
		return this.http.get(`/api/RoleManagement/GetActiverPermissionForRole/${role}/${this.user.uteCliId}`);
	}

}
