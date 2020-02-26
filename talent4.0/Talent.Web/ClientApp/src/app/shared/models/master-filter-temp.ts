import { FilterSortingModel } from "./filter-sorting-model";

export class MasterFilterTemplate {
	tntfilFiltropagId: number;
	tntfilFiltropagCliId: string;
	tntfilFiltropagPaginaCodice: string;
	tntfilFiltropagNome: string;
	tntfilFiltropagNomeCorto: string;
	tntfilFiltropagPulisciPrecedenti: string;
	tntfilFiltropagPubblico: string;
	tntfilFiltropagDescrizione: string;

	tntfilFiltropagSelect1FiltropagcampoCodice: string;
	tntfilFiltropagSelect1Filtrocond: string;
	tntfilFiltropagSelect1FiltrocondDatafissa: string;
	tntfilFiltropagSelect1Valore: string;

	tntfilFiltropagSelect2FiltropagcampoCodice: string;
	tntfilFiltropagSelect2Filtrocond: string;
	tntfilFiltropagSelect2FiltrocondDatafissa: string;
	tntfilFiltropagSelect2Valore: string;

	tntfilFiltropagSelect3FiltropagcampoCodice: string;
	tntfilFiltropagSelect3Filtrocond: string;
	tntfilFiltropagSelect3FiltrocondDatafissa: string;
	tntfilFiltropagSelect3Valore: string;

	tntfilFiltropagOrder1FiltropagcampoCodice: string;
	tntfilFiltropagOrder1Ascending: string;

	tntfilFiltropagOrder2FiltropagcampoCodice: string;
	tntfilFiltropagOrder2Ascending: string;

	tntfilFiltropagQuery: string;
	tntfilFiltropagInternalRepresentation: string;
	tntfilFiltropagInsTimestamp?: Date;
	tntfilFiltropagInsUteId: string;
	tntfilFiltropagModTimestamp?: Date;
	tntfilFiltropagModUteId: string;

	tntfilFiltropagUteDefault: string;
	tntfilFiltropagUteButtonLabel: string;
	tntfilFiltropagUteOrdine: number;
	tntfilFiltropagUteButtonId: number;

	tntfilFiltropagUteId?: number;
}



export class DifferentFilterTypeWrapper {
	masterFilterDto: MasterFilterTemplate;
	filterSortingDto: FilterSortingModel;
}