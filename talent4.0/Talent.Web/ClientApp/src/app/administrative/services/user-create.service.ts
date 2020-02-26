import { Utenti } from 'shared/models/utenti';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { CommonServiceOld } from './../../shared/services/common.service';
import { UserRoleAuths } from 'shared/models/UserRoleAuths';
import { UtentiOptimized } from 'shared/models/utenti-optimized';

@Injectable()
export class UtentiService extends CommonServiceOld {
  
  private baseUrl = 'api/Utenti/DeleteUtenti';

  /**
    Retrieve total records count in the database.
   * */
  public getCountAllRecord() : Observable<any> {
    return this.http.get('/api/RoleManagement/GetCountAllRecord/utenti/ute_cli_id/' + this.user.uteCliId);
  }

  /**
   * Fatch the specific record from database
   * @param id
   */
  getUser(uteId: string) {
    return this.http.get<Utenti>('/api/Utenti/getUtenti/' + this.user.uteCliId + '/' + uteId);
  }

  /**
   * Fill all the controls and store it
    to the database. Required check is happend
   * @param utentiDto
   */
  createUser(utentiDto: Object): Observable<Object> {
    return this.http.post('/api/Utenti/postUtenti', utentiDto);
  }

  /**
   * Select a record from list
      and update the record if it is needed.
   * @param user
   */
  updateUser(user: Object): Observable<Object> {
    return this.http.put('api/Utenti/updateUtenti', user);
  }
  
  /**
   * Fetching the list of utenti.
   * @param counter
   */
  getUsersList(): Observable<any> {
    return this.http.get('/api/Utenti/GetAllUtenti/' + this.user.uteCliId);
  }

  /**
   * Returns optimized user list depending on the user status flag.
   * To get only active users, set userStatusFlag = "S"
   * To get only inactive users, set userStatusFlag = "N"
   * To get only all users, set userStatusFlag = "A"
   * @param userStatusFlag 
   */
  getOptimizedUsersList(userStatusFlag : string): Observable<UtentiOptimized[]> {
    return this.http.get<UtentiOptimized[]>(`/api/Utenti/GetOptimizedUtentiList/${this.user.uteCliId}/${userStatusFlag}`);
  }

  /**Adding/updating a role or load
  the list of role while adding/updating a utrenti.
  @param uteCliId
  */
  getRoleList(): Observable<any> {
    return this.http.get('/api/rolemanagement/getUserAllRoles/' + this.user.uteCliId);
  }

 /**While creating a user, it is required to
    choose the titoli from the list
    for that specific user.
    @param uteCliId
  */
  getTitoliList(): Observable<any> {
    return this.http.get('/api/Utenti/GetAllTitoli/' + this.user.uteCliId);
  }

  /**While creating a user, it is required
     to choose the fillali from the list for that specific user.
   * @param uteCliId
   * */
  getGetAllFilialiList(): Observable<any> {
    return this.http.get('/api/Utenti/GetAllFiliali/' + this.user.uteCliId);
  }

  /**
    Load client list for dropdonl 
  */
  getClientList(): Observable<any> {
    return this.http.get('/api/Clienti/GetAllClienti');
  }

  /**
   * It is required while editing a ute data.
      load all the authentication list and those are
      already synced with that user is loaded as checked.
      check whether the ute id is null. If null
      then keep the auth as unchecked, otherwise checked.
   * @param uteId
   * @param clientId
   */
  getAllAuthHavingUtenti(uteId: string, clientId:string) {
    return this.http.get<UserRoleAuths[]>('/api/Utenti/GetAllAuthHavingUtenti/' + uteId + '/' + clientId);
  }

  getUserIsInAuth(uteId: string, auth:string) : Observable<any> {
    return this.http.get('/api/Utenti/GetUserIsInAuth/' + uteId + '/' + this.user.uteCliId + '/' + auth);
  }

  /**
   * While dropdown changing  a role, it is necessary
      to load all the auth.
      Here the auth list is loaded having two columns.
   * @param roleName
   * @param clientId
   */
  getAllAuthHavingRole(roleName: string, clientId: string): Observable<any> {
    return this.http.get('/api/RoleManagement/GetAllAuthHavingRole/' + roleName + '/' + clientId)
      .pipe(
        map((response: any) => {
          response.forEach(contact => {
            contact.uteabProcedura = contact.tipoabilit_procedura;
          });
          return response;
        })
      );
  }

  getRisorse(nome : string, cogNome : string) : Observable<any> {
    return this.http.get('/api/Risorse/GetRisInfoByRisNomeCognome/' + nome + '/' + cogNome + '/' + this.user.uteCliId);
  }

  getRisorseFromRisId(risId : number) : Observable<any> {
    return this.http.get('/api/Risorse/GetRisorseDetails/' + risId.toString());
  }

  // Get all the users assigned to a specific role.
  // Parameter is role name.
  // Returns observable of any type(UtentiOptimized list)
  getAllUtentiByRole(role : string) : Observable<any> {
    return this.http.get('/api/Utenti/getAllUtentiByRole/' + this.user.uteCliId + '/' + role);
  }  
}
