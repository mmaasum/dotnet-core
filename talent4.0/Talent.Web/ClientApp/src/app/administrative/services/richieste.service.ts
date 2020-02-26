import { Injectable } from '@angular/core';
import { CommonServiceOld } from 'shared/services/common.service';
import { Observable, throwError  } from 'rxjs';
import { Richieste } from 'shared/models/richieste';
import { retry, catchError } from 'rxjs/operators';
import { Email } from 'shared/models/email';
import { RichiesteListaRisorse } from 'shared/models/richiesteListaRisorse';

@Injectable({
  providedIn: 'root'
})
export class RichiesteService extends CommonServiceOld {

  handleError(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // client-side error
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(errorMessage);
  }

  getCandidateStatusData(): Observable<any> {
    return this.http.get('assets/candidateStatus.json');
  }

  insertRichieste(richieste: object): Observable<any> {
    return this.http.post('/api/Richieste/insertrichieste/', richieste);
  }

  manageTalentRichlistRisorse(richieste: object): Observable<any> {
    return this.http.post('/api/Richieste/ManageTalentRichlistRisorse/', richieste);
  }

  sendEmail(contId: number, risId: number, email: Email): Observable<any> {
    const formData = new FormData();
    for (const prop in email) {
      if (!email.hasOwnProperty(prop)) {
        continue;
      }
      formData.append(prop , email[prop]);
    }

    return this.http.post(`/api/Risorse/SendEmail/${contId}/${risId}`, formData);
  }

  editRichieste(richieste: object): Observable<any> {
    return this.http.put('/api/Richieste/updaterichieste/', richieste);
  }

  cloneRichieste(richId: string): Observable<any> {
    return this.http.get('/api/Richieste/clonerichieste/' + richId);
  }
  // Get all the aziende against logged in user's client id.
  // Returns observable of any type.rich
  getAllAziende(): Observable<any> {
    return this.http.get('/api/aziende/getlistaziende/' + this.user.uteCliId);
  }

  getSedeForEmail(azId: number): Observable<any> {
    return this.http.get('/api/SediAziende/GetAllSediAziendeByAzSedeAzId/' + azId);
  }

  getContattiForEmail(azId: number): Observable<any> {
    return this.http.get('/api/Contatti/GetAllContattiByAzId/' + azId);
  }
  getCitta(): Observable<any> {
    return this.http.get('/api/Richieste/GetAllCittaByCliId/' + this.user.uteCliId);
  }

  getAllCompetenzaByCliId() {
    return this.http.get('/api/Richieste/GetAllCompetenzaByCliId/' + this.user.uteCliId);
  }
  getOptimizedAziendeClientiFinaleByAzId(azId: number): Observable<any> {
    return this.http.get('/api/ClientFinale/GetOptimizedAziendeClientiFinaleByAzId/'
     + azId.toString());
  }

  getAllSediAziendeByAzSedeAzId(azId: number): Observable<any> {
    return this.http.get('/api/SediAziende/GetAllSediAziendeByAzSedeAzId/' + azId.toString());
  }

  getFindByAllContattiByContAzSedeId(sedeId: number): Observable<any> {
    return this.http.get('/api/Contatti/GetFindByAllContattiByContAzSedeId/'
     + sedeId);
  }

  getSedeAziende(azId: number): Observable<any> {
    return this.http.get('/api/SediAziende/GetAllSediAziendeByAzSedeAzId/' + azId.toString());
  }
  public insertTalentRichlistRisorse(richiesteListaRisorse: any): Observable<any> {
    return this.http.post('/api/Richieste/ManageTalentRichlistRisorse', richiesteListaRisorse);
  }

  /**
   *
   * @param richeId
   */
  public getRichiesteById(richeId: string): Observable<any> {
    return this.http.get('/api/Richieste/getdetailrichieste/' + richeId);
  }
  /**
   *
   * @param richeId
   */
  public getMatchingRecord(richeId: string): Observable<any> {
    return this.http.get('/api/Risorse/LaunchMachineLearning/' + richeId + '/' + this.user.uteCliId);
  }
  /**
  *Retrieve total records count in the database.
   For a specific client id, this action gets the
   total records in richieste table.
   */
  public getCountAllRecord(): Observable<any> {
    return this.http.get('/api/RoleManagement/GetCountAllRecord/richieste/rich_cli_id/' + this.user.uteCliId);
  }

  /**
   * Call this method when user want
   * to find the maching records
   * @param richid
   * @param pageIndex
   */
  public getMatchingRichieste(richid: string, status: number): Observable<any> {
    return this.http.get('/api/Richieste/matchingRichieste/' + richid + '/' + this.user.uteCliId + '/' + status.toString());
  }

  /**
   * Clicking on master list
   * the detailed data will
   * load using specific richid
   * to the detail pane
   * @param richid
   */
  public getRisorseDetails(richid: string): Observable<any> {
    return this.http.get('/api/Risorse/GetRisorseDetails/' + richid);
  }




  insertRichListRisorse(richieste: RichiesteListaRisorse): Observable<any> {
    return this.http.post<any>('/api/Richieste/InsertRichlistRisorse/', richieste);
  }

  /**
   * Grade is stored to the database
   * using some condition and
   * fatch the grade.
   * @param richieste
   */
  updateRichListRisorse(richieste: RichiesteListaRisorse): Observable<any> {
    return this.http.put('/api/Richieste/UpdateRichlistRisorse/', richieste);
  }


  getExistingRowCount(risId: number, richId: string) {
    return this.http.get<any>(`/api/Richieste/CountFindByRichlistRisorse/${richId}/${risId}/${this.user.uteCliId}`);
  }


  /**
   * The service launchRisourseSP executing the
   * store procedure named sp_ricerca_richiesta_query
   * and storing some data to database
   * if the data is stored to database using the
   * store procedure successfully then redirecto to another page.
   * @param richId
   * @param cvInviati
   * @param clientId
   */
  public launchRisorseSP(richId: string, cvInviati: string, clientId: string): Observable<any> {
    return this.http.get('/api/Risorse/LaunchRisorseSP/' + richId + '/' + cvInviati + '/' + clientId)
    .pipe(
      retry(1),
      catchError(this.handleError)
    );
  }

  /**
   * The service launchRisorseMachineLearningData executing
   * the Talent provided api 'http://192.168.1.135:5000/'
   * if found the data using the particular rich is
   * then redirect to anothe page
   * @param richeId
   */
  // public launchRisorseMachineLearningData(richeId: string, status : number): Observable<any> {
  //   return this.http.get('/api/Richieste/MatchingRichieste/' + richeId + "/" + this.user.uteCliId + "/" + status)
  //   .pipe(
  //     retry(1),
  //     catchError(this.handleError)
  //   );
  // }

  public launchMachineLearning(richeId: string): Observable<any> {
    return this.http.get('/api/Risorse/LaunchMachineLearning/' + richeId + '/' + this.user.uteCliId)
    .pipe(
      retry(1),
      catchError(this.handleError)
    );
  }
  /**
   * The service launchRisorseMachineLearningData executing
   * the Talent provided api 'http://192.168.1.135:5000/'
   * if found the data using the particular rich is
   * then redirect to anothe page
   * @param richeId
   */
  public launchLaunchMachineLearning(richeId: string): Observable<any> {
    return this.http.get('/api/Risorse/LaunchMachineLearning/' + richeId + '/' + this.user.uteCliId);
  }
  /**
   * Calling the getRisInfoByRichId method
   * gets all the related risorse/candidate related to a richiesta.
   * @param richeId
   */
  getRisInfoByRichId(richId: string): Observable<any> {
    return this.http.get('/api/Risorse/GetRisInfoByRichId/' + richId );
  }

  getStatiRichListRisDescr(): Observable<any> {
    return this.http.get('/api/Richieste/GetStatiRichListRisDescr/' + this.user.language );
  }

  getMultiLanguegeData(): Observable<any> {
    return this.http.get('assets/multiLanguage.json');
  }

  updateRichieste(richieste: Richieste): Observable<any> {
    return this.http.put('/api/Richieste/updateRichieste', richieste);
  }
}
