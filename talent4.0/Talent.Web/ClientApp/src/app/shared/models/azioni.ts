export class Azioni {

	azioneUteId: string;
	azioneTipo: string;
	azioneDettaglio01: string;
	azioneDettaglio02: string;
	azioneDettaglio03: string;
	azioneInsUteId: string;
	azioneModUteId: string;
	azioneCliId: string;
	azioneDescrizione: string;
	azioneInizio: Date;
	azioneModTimestamp: string;

	constructor(user: string, tipo: string, client: string, description: string) {
		this.azioneUteId = user;
		this.azioneInsUteId = user;
		this.azioneModUteId = user;
		this.azioneCliId = client;
		this.azioneTipo = tipo;
		this.azioneDescrizione = description;
	}

}
