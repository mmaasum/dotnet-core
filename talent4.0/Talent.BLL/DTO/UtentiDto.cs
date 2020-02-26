using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Talent.DataModel.Models;

namespace Talent.BLL.DTO
{
    public class UtentiDto
    {

        [Required, StringLength(20)]
        public string UteId { get; set; }
        [Required, StringLength(10)]
        public string UtePassword { get; set; }
        [Required, StringLength(20)]
        public string UteNome { get; set; }
        [StringLength(15)]
        public string UteRuolo { get; set; }
        [Required]
        [StringLength(1)]
        public string UteAttivo { get; set; }
        [Required]
        public DateTime UteInsTimestamp { get; set; }
        [StringLength(20)]
        public string UteInsUteId { get; set; }
        [Required]
        public DateTime UteModTimestamp { get; set; }
        [StringLength(20)]
        public string UteModUteId { get; set; }
        [StringLength(10)]
        public string UteTitolo { get; set; }
        [StringLength(60)]
        public string UteProfilo { get; set; }

        [StringLength(150)]
        //[EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string UteMail { get; set; }

        public List<UtentiAbilitazioniDto> UtentiAbilitazioniDto { get; set; }

        [StringLength(20)] public string UteTelefono { get; set; }
        [StringLength(50)] public string UteAltriRiferimenti { get; set; }
        [StringLength(1)] public string UteDeveloper { get; set; }
        [StringLength(15)] public string UteTipoClientEmail { get; set; }
        [StringLength(30)] public string UteSede { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public short? UteLimiteMaxSms { get; set; }

        [StringLength(1000)] public string UteRapportiniEmailInvio { get; set; }
        [StringLength(350)] public string UteRapportiniUtentiGestiti { get; set; }
        [StringLength(1)] public string UteModalitaDebug { get; set; }
        [StringLength(1)] public string UteUsaVpn { get; set; }


        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int UteRicerchePortaliMaxNum { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int? UteRisId { get; set; }

        [Required] public string UteCliId { get; set; }



        public UtentiAbilitazioni MapDtoToUtentiAbilitazioni(UtentiAbilitazioniDto userAuthDto)
        {
            UtentiAbilitazioni utentiAbilitazioni = new UtentiAbilitazioni();
            utentiAbilitazioni.UteabId = userAuthDto.UteabId;
            utentiAbilitazioni.UteabUteId = userAuthDto.UteabUteId;
            utentiAbilitazioni.UteabProcedura = userAuthDto.TipoabilitProcedura;
            utentiAbilitazioni.UteabAbilitato = userAuthDto.UteabAbilitato;
            utentiAbilitazioni.UteabInsTimestamp = userAuthDto.UteabInsTimestamp;
            utentiAbilitazioni.UteabInsUteId = userAuthDto.UteabInsUteId;
            utentiAbilitazioni.UteabModTimestamp = userAuthDto.UteabModTimestamp;
            utentiAbilitazioni.UteabModUteId = userAuthDto.UteabInsUteId; // this is willingly set as ute_ins_id
            utentiAbilitazioni.UteabCliId = userAuthDto.UteabCliId;
            return utentiAbilitazioni;
        }

        public UtentiDto MapObjectToDto(Object iutenti)
        {
            Utenti utenti = (Utenti)iutenti;
            return MapUtentiToDto(utenti); ;
        }


        public Utenti MapDtoToUtenti(UtentiDto utentiDto)
        {
            Utenti utenti = new Utenti();
            utenti.UteId = utentiDto.UteId;
            utenti.UtePassword = utentiDto.UtePassword;
            utenti.UteNome = utentiDto.UteNome;
            utenti.UteRuolo = utentiDto.UteRuolo;
            utenti.UteAttivo = utentiDto.UteAttivo;
            utenti.UteInsTimestamp = utentiDto.UteInsTimestamp;
            utenti.UteInsUteId = utentiDto.UteInsUteId;
            utenti.UteModTimestamp = utentiDto.UteModTimestamp;
            utenti.UteModUteId = utentiDto.UteInsUteId; // this is willingly set as ins_ute_id
            utenti.UteTitolo = utentiDto.UteTitolo;
            utenti.UteProfilo = utentiDto.UteProfilo;
            utenti.UteMail = utentiDto.UteMail;
            utenti.UteTelefono = utentiDto.UteTelefono;
            utenti.UteAltriRiferimenti = utentiDto.UteAltriRiferimenti;
            utenti.UteDeveloper = utentiDto.UteDeveloper;
            utenti.UteTipoClientEmail = utentiDto.UteTipoClientEmail;
            utenti.UteSede = utentiDto.UteSede;
            utenti.UteLimiteMaxSms = utentiDto.UteLimiteMaxSms;
            utenti.UteRapportiniEmailInvio = utentiDto.UteRapportiniEmailInvio;
            utenti.UteRapportiniUtentiGestiti = utentiDto.UteRapportiniUtentiGestiti;
            utenti.UteModalitaDebug = utentiDto.UteModalitaDebug;
            utenti.UteUsaVpn = utentiDto.UteUsaVpn;
            utenti.UteRicerchePortaliMaxNum = utentiDto.UteRicerchePortaliMaxNum;
            utenti.UteRisId = utentiDto.UteRisId;
            utenti.UteCliId = utentiDto.UteCliId;
            return utenti;
        }

        public UtentiDto MapUtentiToDto(Utenti utenti)
        {
            UtentiDto utentiDto = new UtentiDto();
            utentiDto.UteId = utenti.UteId;
            utentiDto.UtePassword = utenti.UtePassword;
            utentiDto.UteNome = utenti.UteNome;
            utentiDto.UteRuolo = utenti.UteRuolo;
            utentiDto.UteAttivo = utenti.UteAttivo;
            utentiDto.UteInsTimestamp = utenti.UteInsTimestamp;
            utentiDto.UteInsUteId = utenti.UteInsUteId;
            utentiDto.UteModTimestamp = utenti.UteModTimestamp;
            utentiDto.UteModUteId = utenti.UteModUteId;
            utentiDto.UteTitolo = utenti.UteTitolo;
            utentiDto.UteProfilo = utenti.UteProfilo;
            utentiDto.UteMail = utenti.UteMail;
            utentiDto.UteTelefono = utenti.UteTelefono;
            utentiDto.UteAltriRiferimenti = utenti.UteAltriRiferimenti;
            utentiDto.UteDeveloper = utenti.UteDeveloper;
            utentiDto.UteTipoClientEmail = utenti.UteTipoClientEmail;
            utentiDto.UteSede = utenti.UteSede;
            utentiDto.UteLimiteMaxSms = utenti.UteLimiteMaxSms;
            utentiDto.UteRapportiniEmailInvio = utenti.UteRapportiniEmailInvio;
            utentiDto.UteRapportiniUtentiGestiti = utenti.UteRapportiniUtentiGestiti;
            utentiDto.UteModalitaDebug = utenti.UteModalitaDebug;
            utentiDto.UteUsaVpn = utenti.UteUsaVpn;
            utentiDto.UteRicerchePortaliMaxNum = utenti.UteRicerchePortaliMaxNum;
            utentiDto.UteRisId = utenti.UteRisId;
            utentiDto.UteCliId = utenti.UteCliId;
            return utentiDto;
        }

        public Utenti MapDtoToUpdateUtenti(UtentiDto utentiDto, Utenti utenti)
        {
            utenti.UteId = utentiDto.UteId;
            utenti.UtePassword = utentiDto.UtePassword;
            utenti.UteNome = utentiDto.UteNome;
            utenti.UteRuolo = utentiDto.UteRuolo;
            utenti.UteAttivo = utentiDto.UteAttivo;
            utenti.UteInsTimestamp = utentiDto.UteInsTimestamp;
            utenti.UteInsUteId = utentiDto.UteInsUteId;
            utenti.UteModTimestamp = utentiDto.UteModTimestamp;
            utenti.UteModUteId = utentiDto.UteInsUteId; //this is done willingly
            utenti.UteTitolo = utentiDto.UteTitolo;
            utenti.UteProfilo = utentiDto.UteProfilo;
            utenti.UteMail = utentiDto.UteMail;
            utenti.UteTelefono = utentiDto.UteTelefono;
            utenti.UteAltriRiferimenti = utentiDto.UteAltriRiferimenti;
            utenti.UteDeveloper = utentiDto.UteDeveloper;
            utenti.UteTipoClientEmail = utentiDto.UteTipoClientEmail;
            utenti.UteSede = utentiDto.UteSede;
            utenti.UteLimiteMaxSms = utentiDto.UteLimiteMaxSms;
            utenti.UteRapportiniEmailInvio = utentiDto.UteRapportiniEmailInvio;
            utenti.UteRapportiniUtentiGestiti = utentiDto.UteRapportiniUtentiGestiti;
            utenti.UteModalitaDebug = utentiDto.UteModalitaDebug;
            utenti.UteUsaVpn = utentiDto.UteUsaVpn;
            utenti.UteRicerchePortaliMaxNum = utentiDto.UteRicerchePortaliMaxNum;
            utenti.UteRisId = utentiDto.UteRisId;
            utenti.UteCliId = utentiDto.UteCliId;
            return utenti;
        }

        
    }
}
