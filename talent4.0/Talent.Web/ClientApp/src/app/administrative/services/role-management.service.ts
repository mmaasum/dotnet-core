import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CommonServiceOld } from 'shared/services/common.service';
import { Roles } from 'shared/models/roles';
import { HttpHeaders } from '@angular/common/http';

@Injectable({
	providedIn: 'root'
})
export class RoleManagementService extends CommonServiceOld {

	// Retrieving the role List through API.
	// For a specifc client id this method gets the role list. 
	getAllRoles(): Observable<any> {
		return this.http.get('/api/rolemanagement/getUserAllRoles/' + this.user.uteCliId);
	}

	// Get all authorizations for a role.
	// Parameter is role name.
	// Returns an observale of any type.
	getAllAuthentications(role: string): Observable<any> {
		return this.http.get('/api/rolemanagement/getAllAuthHavingRole/' + role + '/' + this.user.uteCliId);
	}

	// Get the total number of users assigned to a role.
	// Parameter is the role name.
	// Returns Observable of any type.
	getTotalUserInRoleCount(role: string): Observable<any> {
		return this.http.get('/api/rolemanagement/GetCountUtentiByRole/' + role + '/' + this.user.uteCliId);
	}

	// Get the total number of auths assigned to a role.
	// Parameter is the role name.
	// Returns Observable of any type.
	getTotalAuthsInRoleCount(role: string): Observable<any> {
		return this.http.get('/api/rolemanagement/GetCountAuthByRole/' + role + '/' + this.user.uteCliId);
	}

	// Update authorizations of selected role.
	// Parameter is selected authorizations and confirmation type;
	// Confirmation type means if user's auths are to be also updated or not.
	// Returns observable of any type.
	postAuthenticationsOfRole(auths: any[], confirmation: string): Observable<any> {
		return this.http.put('/api/rolemanagement/updateRoleAuth/' + confirmation, auths);
	}


	getAllUsersForRole(role: string) {
		return this.http.get(`/api/RoleManagement/GetActiveUserForRole/${role}/${this.user.uteCliId}`);
	}

	getAllPermissionsForRole(role: string) {
		return this.http.get(`/api/RoleManagement/GetActiverPermissionForRole/${role}/${this.user.uteCliId}`);
	}
	/**
	 * Store new role to the database
	 * @param roleName
	 */
	addNewRole(role: Roles): Observable<any> {
		return this.http.post('/api/rolemanagement/insertruolo', role);
	}

	updateRole(role: Roles, previousRoleName: string): Observable<any> {
		console.log(role);
		return this.http.put('/api/rolemanagement/updateruolo/' + previousRoleName, role);
	}

	deleteRole(roleName: string): Observable<any> {
		return this.http.delete('/api/rolemanagement/deleteruolo/' + roleName + '/' + this.user.uteCliId);
	}
}
