export class MLKeywords {
	update: string;
	start_date: string;
	time_delta: string;
	language: string;
	max_ngrams: number;
	min_freq_ngrams: number;
	entropy_threshold: number;
	accepted_patterns: string;
	weighting_measure: string;

	constructor() {
		this.update = "True";
		this.language = "it";
		this.max_ngrams = 3;
		this.weighting_measure = "ppmi";
		this.accepted_patterns = "..\\resources\\terms_keywords\\POS_patterns.txt";
	}
}