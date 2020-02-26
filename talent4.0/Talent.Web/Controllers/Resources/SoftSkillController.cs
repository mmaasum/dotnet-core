using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Talent.BLL;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;

namespace Talent.Web.Controllers.Resources
{
    [Route("api/")]
    [ApiController]
    public class SoftSkillController : ControllerBase
    {

        private readonly IAzioniManager _azioniManager;
        private readonly IEmailManager _emailManager;
        private readonly IUtilityManager _utilityManager;
        private readonly ISoftSkillManager _softSkillManager;

       
        public SoftSkillController(IAzioniManager azioniManager, IEmailManager emailManager, IUtilityManager utilityManager, ISoftSkillManager softSkillManager)
        {
            _azioniManager = azioniManager;
            _emailManager = emailManager;
            _utilityManager = utilityManager;
            _softSkillManager = softSkillManager;
        }


        [HttpGet]
        [Route("SoftSkill/GetSavedWsResultByRisId/{risId}/{langName}")]
        public async Task<IActionResult> GetSchedule(int risId, string langName)
        {
            try
            {
                // passing the ridId and language name to business logic layer to retreive the list data.
                var categories = await _softSkillManager.GetSavedWsResultByRisIdAsync(risId, langName);
                // Null Reference handling.
                if (categories == null)
                {
                    return NotFound();
                }

                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "saved web service result");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get saved web service result.");
                // Returning the error object.
                return BadRequest(errorObj);
            }

        }


        /// <summary>
        ///     To get the list of schedule based on provided codice processo name
        /// </summary>
        /// <purpose>
        ///     Currently this API is being used by the onsite team.
        /// </purpose>
        /// <param name="codiceProcesso">an attirbute value of the table. Need to retreived which record having this value</param>
        /// <returns>List object of schedulazione</returns>
        [Authorize]
        [HttpGet]
        [Route("robot/GetSchedule/{codiceProcesso}")]
        public async Task<IActionResult> GetSchedule(string codiceProcesso)
        {
            try
            {
                // passing the codio_processo to business logic layer to retreive the list data.
                var categories = await _softSkillManager.GetScheduleAsync(codiceProcesso);
                if (categories == null)
                {
                    return NotFound();
                }
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "scedule based on codiceProcesso");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get scedule based on codiceProcesso");
                // Returning the error object.
                return BadRequest(errorObj);
            }

        }

        /// <summary>
        ///  To get the all skill list based on the language name;
        /// </summary>
        /// <param name="languageName">Of which language the list should be loiaded</param>
        /// <returns>List object of Skills.</returns>
        [HttpGet]
        [Route("SoftSkill/GetAllSkill/{languageName}")]
        public async Task<IActionResult> GetAllCompetenze(string languageName)
        {
            try
            {
                // Retrieving all the skill list based on the selected language.
                var categories = await _softSkillManager.GetFindSkillDataByLangAsync(languageName);
                if (categories == null)
                {
                    return NotFound();
                }
                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "all skill by language");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(categories);
                
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get all skill");
                // Returning the error object.
                return BadRequest(errorObj);
            }

        }



        /// <summary>
        ///     To get the soft skill ws result profile description based on rich_id
        /// </summary>
        /// <param name="richId">Select rich_id of richieste grid</param>
        /// <returns></returns>
        [HttpGet]
        [Route("SoftSkill/GetSoftSkillProfileDescription/{richId}")]
        public async Task<IActionResult> GetSoftSkillProfileDescription(string richId)
        {
            try
            {
                // Retrieving data from business layer by providing rich id
                var ssProfiloDesc = await _softSkillManager.GetSoftSkillProfileDescriptionAsync(richId);

                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "soft skill profile descr");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                // Returning the softskill profile description
                return Ok(ssProfiloDesc);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get soft skill profile descr");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }

        // Static Question List in 3 different language
        // Questions are kept static following the requirement.
        [NonAction]
        private string returnQuestion(int index)
        {
            string[] quesArray =
                {
                   // Italian Question
				    "Genere",
                    "Con che frequenza usi i videogiochi?",
                    "A quali giochi in prevalenza? Nel caso in cui non giochi, pensa a quale categoria preferiresti giocare??  <br />avventura (es. swordigo, criminal case, badland)",
                    "azione (temple run, crossy road, dude perfect)",
                    "giochi di ruolo (taichi panda, marvel future fight, storm of hunter)",
                    "puzzle (cut the rope, unblock, candy crush)",
                    "simulazione (simcity, bus simulator, the sims)",
                    "strategia (clash of clans, clash of kinks, empire: four kingdoms)",

                    "Intervallare le mie mosse con quelle del rivale/nemico",
                    "Provare paura",
                    "Sostenere un ritmo serrato di gioco",
                    "Poter compiere un numero definito di mosse",
                    "Dover seguire poche regole",
                    "Potermi muovere liberamente nello scenario di gioco",
                    "Usare tanto pistole e fucili",
                    "Agire per indebolire il rivale  on ogni movimento",
                    "Proteggere il mio territorio dalle offese dell’avversario",
                    "Acquisire un numero di punti sempre più elevato",
                    "Poter fare fuoco con le armi",
                    "Avere la possibilità di dirigere un veicolo",
                    "Sostenere livelli sempre più complessi",
                    "Far fronte a difficoltà inaspettate",
                    "Dover gestire un solo avatar per volta",
                    "Dover combattere a mani nude con i miei rivali",
                    "Vendere e comprare le risorse personali con i miei compagni ",
                    "Poter scegliere quale personaggio impersonare",
                    "Poter accrescere le competenze del mio avatar",
                    "Poter compiere azioni online con i miei compagni",
                    "Dover prendere decisioni velocemente",
                    "Compiere scelte che cambiano la trama del gioco",
                    "Affrontare prove impegnative a livello cerebrale",
                    "Poter fare paragoni tra i miei punti e quelli degli altri",
                    "Dover iniziare nuovamente il gioco ogni volta che compio errori",
                    "Imitare scenari del mondo reale",
                    "Affrontare contesti di gioco dove provo forti emozioni",
                    "Far esplodere le cose",
                    "Impegnarmi in livelli complicati che richiedono diverse prove prima di essere risolti",
                    "Poter comprare rarità che mi differenziano rispetto agli altri giocatori",
                    "Completare ogni livello e compito previsto dal gioco",
                    "Avere a che fare con elementi di gioco che danno risposte autonome o si comportano come intelligenze artificiali",
                    "Affrontare sfide sportive",
                    "Modificare la storia del gioco arricchendola di elementi coinvolgenti	",
                    "Avere la possibilità di scegliere diversi elementi specifici con cui differenziare il mio personaggio (dotazioni, attrezzature, armamentari)",
                    "Scegliere il livello più complesso o il massimo della difficoltà possibile",
                    "Governare o controllare delle risorse",
                    "Sondare e costruire relazioni con altri personaggi",
                    "Andare alla ricerca di personaggi, elementi o scenari nascosti",
                    "Perfezionare le prestazioni e gli attributi delle mie risorse (umane o materiali)",
                    "Invadere territori e sottomettere gli avversari",
                    "Individuare nuove modalità per ottimizzare la mia prestazione di gioco",
                    "Ottenere tutti i riconoscimenti di efficacia delle mie prestazioni di gioco",
                    "Avere un ottimo posizionamento nella graduatoria generale",
                    "Essere d’aiuto agli altri giocatori",
                    "Essere impegnato in sfide logiche e rompicapo",
                    "Pianificare e individuare con criterio i movimenti successivi per avanzare nel gioco",
                    "Invitare gli altri giocatori a sostenere scontri a due o sfide",
                    "Muovermi con precisione nel campo di gioco",
                    "Mettermi in gioco insieme ad altri per raggiungere un obiettivo comune",
                    "Prendermi tutto il tempo necessario per risolvere livelli e raggiungere gli obiettivi di gioco",
                    "Impegnare le mie energie e il mio tempo a giocare con i videogiochi",
			
				    // English Question
				    "Gender",
                    "How often do you play videgames",
                    "Which games predominantly? In case you don't play, think about which category would you prefer to play? <br />adventure(es. swordigo, criminal case, badland)",
                    "action(temple run, crossy road, dude perfect)",
                    "Role playing(taichi panda, marvel future fight, storm of hunter)",
                    "puzzle(cut the rope, unblock, candy crush)",
                    "simulation(simcity, bus simulator, the sims)",
                    "strategy(clash of clans, clash of kinks, empire: four kingdoms)",

                    "Interval my moves with those of the rival/enemy",
                    "Feel the fear",
                    "Support a fast pace of play",
                    "Being able to perform a definite number of moves",
                    "Having to follow a few rules",
                    "Being able to move freely in the game scenario",
                    "Use a lot of guns and shotguns",
                    "Act to weaken my rival on every move",
                    "Protect my territory from the opponents offenses",
                    "Score a higher number of points",
                    "Being able to fire with weapons",
                    "Having the possibility to manage a vehicle",
                    "Perform in increasingly complex levels",
                    "Cope with unexpected difficulties",
                    "Having to manage only one avatar at time",
                    "Having to fight bare hands with my rivals",
                    "Sell ​​and buy personal resources with my game mates",
                    "Being able to choose which character to play with",
                    "To increase my avatar’s skills",
                    "Being able to take game actions online with my mates",
                    "Having to make decisions quickly",
                    "Make choices that change the plot of the game",
                    "Tackle challenging brain tests",
                    "Being able to make comparisons between my points and those of others",
                    "Having to start the game again every time I make mistakes",
                    "Imitate scenarios of the real world",
                    "Tackling game contexts where I feel strong emotions",
                    "To blow things up",
                    "Being engaged in complicated levels that require different tests before being solved",
                    "Being able to buy rarities that differentiate me from other players	",
                    "Complete each level and task provided by the game",
                    "To deal with elements of play that give autonomous answers or behave like artificial intelligences",
                    "Being involved in sports challenges",
                    "Change the history of the game enriching it with engaging elements",
                    "Being able to choose different specific elements with which to differentiate my character (equipment or armaments)",
                    "Choose the most complex level or the maximum difficulty possible",
                    "Govern or control resources",
                    "To build relationships with other characters",
                    "Go in search of hidden characters, elements or scenarios",
                    "Refining the performance and attributes of my resources (human or material)",
                    "Invade territories and subjugate opponents",
                    "Identify new ways to optimize my gaming performance",
                    "Get all the information of the effectiveness of my gaming performance",
                    "Having a good ranking in the general ranking",
                    "Be helpful to other players",
                    "Being engaged in logical challenges and puzzles	",
                    "Plan and identify the next movements with a criterion to advance in the game",
                    "Invite other players to fight duels or challenges",
                    "Move with accuracy in the field of play",
                    "Get involved with others to achieve a common goal",
                    "Take all the time necessary to solve levels and achieve the game objectives",
                    "Occupy my energies and my time playing video games",
				
				
				    // Spanish Question
				    "Género",
                    "¿Que tan seguido juegas videojuegos?",
                    "¿Prevalentemente a que juegos? En el caso que no juegues, piensa: ¿A cual categoria preferirías jugar? <br />aventura(es. swordigo, criminal case, badland)",
                    "acción(temple run, crossy road, dude perfect)",
                    "juegos de rol(taichi panda, marvel future fight, storm of hunter)",
                    "puzzle(cut the rope, unblock, candy crush)",
                    "simuladores(simcity, bus simulator, the sims)",
                    "estrategia(clash of clans, clash of kinks, empire: four kingdoms)",

                    "Alternar mis movimientos con los del rival/enemigo",
                    "Sentir temor",
                    "Tener un ritmo frenético en el juego",
                    "Poder realizar un numero limitado de movimientos",
                    "Tener que respetar pocas reglas",
                    "Poder moverme libremente en la zona de juego",
                    "Usar mucho pistolas y fuciles",
                    "Hacer cada movimiento con el fin de debilitar al rival",
                    "Proteger mi territorio de los ataques del adversario",
                    "Adquirir una puntuación siempre más alta",
                    "Poder abrir fuego con tus armas",
                    "Tener la posibilidad de manejar un vehículo",
                    "Enfrentarse a niveles cada vez más complejos",
                    "Afrontar adversidades inesperadas",
                    "Tener que manejar un solo avatar a la vez",
                    "Tener que combatir cuerpo a cuerpo con tus rivales",
                    "Vender y comprar recursos personales a mis compañeros",
                    "Poder elegir que personaje interpretar",
                    "Poder enriquecer las competencias de mi avatar",
                    "Poder realizar acciones online con mis compañeros",
                    "Tener que decidir en modo veloz",
                    "Tomar decisiones que cambiarán la trama del juego",
                    "Enfrentarse a pruebas exigentes a nivel cerebral",
                    "Poder comparar mi puntuación con los de otros",
                    "Tener que iniciar de nuevo el juego cada vez que cometo errores",
                    "Simular situaciones del mundo real",
                    "Enfrentarse a situaciones del juego en las cuales pruebo emociones fuertes",
                    "Hacer explotar cosas",
                    "Esforzarme en niveles complicados que necesitan diferentes pruebas antes de completados",
                    "Poder comprar rarezas que me distinguen respecto a los jugadores",
                    "Completar todos los niveles que el juego tiene previsto",
                    "Lidiar con elementos del juego que dan respuestas autónomas o que se comportan como inteligencias artificiales",
                    "Abordar retos deportivos",
                    "Cambiar la historia del juego enriqueciéndola con elementos intrigantes",
                    "Tener la posibilidad de elegir entre diferentes objetos en específico, con los cuales personalizar mi personaje (dotaciones, herramientas, armamentísca)",
                    "Seleccionar el nivel más complejo o el que más dificultad tiene",
                    "Monopolizar o controlar los recursos",
                    "Tantear el terreno para contruir una relación con otros personajes",
                    "Ir en búsqueda de personajes, elementos o escenarios secretos",
                    "Perfecciona el rendimiento y las características de mis recursos (humanos o material)",
                    "Invadir territorios y someter adversarios",
                    "Individuar nuevos modos para optimizar mi rendimiento en el juego",
                    "Obtener todos los resultados de eficacia de mi rendimiento en el juego",
                    "Estar en una buena posición en la clasificación general",
                    "Ser de ayuda a los otros jugadores",
                    "Estar ocupado en retos de lógica y rompecabezas",
                    "Planear e individuar con criterio los siguientes movimientos para avanzar en el juego",
                    "Proponer a otros jugadores un enfrentamiento entre los dos o retos",
                    "Moverme con precisión en la zona de juego",
                    "Ponte a prueba junto a otros para alcanzar un objetivo en común",
                    "Tomarme todo el tiempo que sea necesario para completar niveles y alcanzar los objetivos del juego",
                    "Usar mi energía y tiempo parar jugar a videojuegos"
            };
            return quesArray[index];
        }
        // Static Selected Answer List in 3 different language
        [NonAction]
        private string returnSelectedAnswer(int index)
        {
            string[] answerList =
                {
                   // Italian Options
				    "totalmente in disaccordo","abbastanza in disaccordo","abbastanza d’accordo","totalmente d’accordo",
                    // English Options
                    "totally disagree","quite disagree","quite agree","totally agree",
                    // Spanish Options
                    "totalmente en desacuerdo","en desacuerdo","de acuerdo","totalmente de acuerdo"
            };
            return answerList[index];
        }
        // Static Gender List in 3 different language
        [NonAction]
        private string returnSelectedGender(int index)
        {
            string[] genderList =
                {
                    // Italian GenderList
                    "Maschio","Femmina",
                    // English GenderList
                    "Male","Female", 
                    // Spanish GenderList
                    "Masculino","Femenino"  
            };
            return genderList[index];
        }
        // Static Drop down answer List in 3 different language
        [NonAction]
        private string returnDropDown(int index)
        {
            string[] dropDownList =
                {
                    // Italian Options
                    "Mai","Mensilmente","Settimanalmente","Tutti i giorni","Più volte al giorno",
                    // English Options
                    "Never","Monthly","Weekly","Everyday","More than once a day",
                     // Spanish Options
                    "Nunca","Mensualmente","Semanalmente","Todos los días","Más de una vez al día"
            };
            return dropDownList[index];
        }



        /// <summary>
        ///     To submit the survey form attended by a surveyor and store data comes from web service.
        /// </summary>
        /// <param name="surveyData">
        ///         An object that contain the first_name , last_name,
        ///         mail, selected language and provided answer list
        /// </param>
        /// <returns>general confirmation message.</returns>
        [EnableCors("AllowMyOrigin")]
        [HttpPost]
        [Route("SoftSkill/submitSurvey")]
        public async Task<IActionResult> submitSurvey([FromBody]SurveyData surveyData)
        {
           
            // checking whether the web service is responding properly or not.
            if (returnGetProfileWSResultDto(surveyData) == null)
            {
                // returning the exception result by mentioning the exact reason.
                var result = new
                {
                    error = "Web Service Failed.",
                    error_type = "",
                    message = "Web Service isn't responding properly."
                };
                return BadRequest(result);
            }

            try
            {
                // Inserting into the softskill test web service result table.
                var softSkillTestWsId = await _softSkillManager.InsertSoftSkillTestWSResultAsync(returnGetProfileWSResultDto(surveyData));
                // creating the azioni object passing the related details and description.
                //var azioniDto =  await _utilityManager.GetAzioniDtoObject(User, "add", "soft skill web service result.");
                // logging the activity record by the user.
                //await _talentBLLWrapper.AzuiniBll.AzioniInsert(azioniDto);
                // Sending the feedback email to the surveyor mail 
                // along with the answer provided by the surveyor against a set of question.

                sendFeedbackMail(surveyData);
                // creating the azioni object passing the related details and description.
                //var iAzioniDto =  await _utilityManager.GetAzioniDtoObject(User, "email", "survey_form");
                // logging the activity record by the user.
                //await _talentBLLWrapper.AzuiniBll.AzioniInsert(iAzioniDto);

                return Ok("ok");
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Submit Survey");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///     To get the skillCodeArray and then call the web service GetSkilProfile.
        /// </summary>
        /// <param name="skillDescriptionArray">Array of the skill that selected by the user (max 6 out of 24)</param>
        /// <returns>General confirmation message</returns>
        [HttpPost]
        [Route("SoftSkill/PostSoftSkillProfile/{richId}")]
        public async Task<IActionResult> PostSoftSkillProfile([FromBody]string[] skillDescriptionArray,string richId)
        {
            try
            {
                // Retrieving the skill code array based on the skill description array.
                var skillCodeArray =await _softSkillManager.PostSoftSkillProfileAsync(skillDescriptionArray);
                if(returnGetSkillProfileWSResultDto(skillCodeArray.ToList(), richId) == null)
                {
                    // Defining error object by defining the proper reason of error.
                    var result = new
                    {
                        error = "Web Service Failed.",
                        error_type = "",
                        message = "Web Service isn't responding properly."
                    };
                    return BadRequest(result);
                }
                var softSkillTestWsId = await _softSkillManager
                    .InsertSoftSkillTestWSResultAsync(returnGetSkillProfileWSResultDto(skillCodeArray.ToList(), richId));

                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "add", "soft skill profile");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok("ok");
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Submit sofr skill profile");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }

        // Function to send the mail to the surveyor who have attended the survey
        [NonAction]
        public async void sendFeedbackMail(SurveyData surveyData)
        {
            // Static Number of Questions
            var numberOfQuestion = 60;
            // Static Number of Options
            var numberOfOption = 4;
            // Static Number of Gender Data
            var numberOfGender = 2;
            // Static Number of Dropdown data
            var numberOfDropdown = 5;
            // Declaring the empty mail content
            var mailContent = "";

            var i = 0;
            var j = 0;
            // Loop in the question array to load all the question along with the answers
            for (int x = 0; x < numberOfQuestion; x++)
            {
                // Embedding the specific questions to the mail content based on language.
                mailContent += "Q " + (x + 1) + ": " + returnQuestion(x + (numberOfQuestion * surveyData.LangIndex)) + " : <b>";
                // Checking whether the question is about general info or radio options or select list options.
                if (x < 2)
                {
                    // Checking whether this is first question which related to gender.
                    if (x == 0)
                    {
                        // Embedding the answers provided by the surveyor following the selcted language.
                        mailContent += returnSelectedGender((numberOfGender * surveyData.LangIndex) +
                            (Int32.Parse(surveyData.FeedbackArray[j])) - 1) + "</b><br />";
                        j++;
                    }
                    else
                    {
                        mailContent += returnDropDown((numberOfDropdown * surveyData.LangIndex) +
                            (Int32.Parse(surveyData.FeedbackArray[j])) - 1) + "</b><br />";
                        j++;
                    }
                }
                else
                {
                    // Cheking the whether these questions are radio option type or select type.
                    if (x < 8)
                    {
                        mailContent += surveyData.FeedbackArray[j] + "</b><br />";
                        j++;
                    }
                    else
                    {
                        mailContent += returnSelectedAnswer((numberOfOption * surveyData.LangIndex) +
                            (Int32.Parse(surveyData.SelectListArray[i])) - 1) + "</b><br />";
                        i++;
                    }
                }
            }

            // Creating the mail body by concatanating the surveyor name and others info along with the provided answers
            var mailbody = "<br />Dear " + surveyData.FirstName + " " + surveyData.LastName + ",<br /><br /> <br/>" + "Here is your provided feedback : <br /> " + mailContent + "<br /><br /><b> N.B:  Please do not reply in this mail </b><br /><br /> Thanks, <br /> Talent Team";
            // Initiating the recipient mail address. 
            _emailManager.To.Add(surveyData.Email);
            // Initiating the mail subject.
            _emailManager.Subject = "Talent_Survey_Form";
            // Initiating the mail body.
            _emailManager.Body = mailbody.ToString();
            // Sending the mail to specific recipient.
            _emailManager.Send();

            // creating the azioni object passing the related details and description.
            var azioniDto = _utilityManager.GetAzioniDtoObject(User, "email", "survey_feedback_mail");
            // logging the activity record by the user.
            await _azioniManager.AzioniInsert(azioniDto);

        }

        /// <summary>
        ///     To get the Dto object made from the result of GetProfile web service.
        /// </summary>
        /// <param name="surveyData"></param>
        /// <returns></returns>
        [NonAction]
        public GetWSResultDto returnGetProfileWSResultDto([FromBody]SurveyData surveyData)
        {
            // Setting up the configuration for consuming web service
            SoftSkill.wsTestPlayPublicSoapClient.EndpointConfiguration endpointConfiguration
              = new SoftSkill.wsTestPlayPublicSoapClient.EndpointConfiguration();

            // Consuming the web service providing necessary credentials.
            SoftSkill.wsTestPlayPublicSoapClient wsTestPlayPublicSoapClient =
                new SoftSkill.wsTestPlayPublicSoapClient(endpointConfiguration,
                "http://wsplay.laborplay.com/wsTestPlayPublic.asmx");

            // Converting the answer array to web service supported ArrayOfInt1 format
            // Declaring an empty array of ArrayOfInt1
            SoftSkill.ArrayOfInt1 iSelectListArray = new SoftSkill.ArrayOfInt1();
            for (int i = 0; i < 52; i++)
            {
                // Assigning the data into the list
                iSelectListArray.Add(Int32.Parse(surveyData.SelectListArray[i]));
            }

            // Calling the web service GetProfile
            var result =
                wsTestPlayPublicSoapClient.GetProfileAsync(
                    Int32.Parse(surveyData.FeedbackArray[0]),
                    Int32.Parse(surveyData.FeedbackArray[1]),
                    bool.Parse(surveyData.FeedbackArray[2]),
                    bool.Parse(surveyData.FeedbackArray[3]),
                    bool.Parse(surveyData.FeedbackArray[4]),
                    bool.Parse(surveyData.FeedbackArray[5]),
                    bool.Parse(surveyData.FeedbackArray[6]),
                    bool.Parse(surveyData.FeedbackArray[7]),
                    iSelectListArray
               );

            try
            {
                // Declaring and initializing the web service result data to dto object.
                GetWSResultDto getProfileWSResultDto = new GetWSResultDto();
                // Assigning the value of P from web service result
                getProfileWSResultDto.P = result.Result.Body.GetProfileResult.P;
                // Assigning the value of L from web service result
                getProfileWSResultDto.L = result.Result.Body.GetProfileResult.L;
                // Assigning the value of A from web service result
                getProfileWSResultDto.A = result.Result.Body.GetProfileResult.A;
                // Assigning the value of Y from web service result
                getProfileWSResultDto.Y = result.Result.Body.GetProfileResult.Y;
                getProfileWSResultDto.ProfileIdProp = result.Result.Body.GetProfileResult.ProfileIDProp;
                // Assigning static 2 as the value of soft skill test id to define
                // that which method is calling from the web service.
                getProfileWSResultDto.SoftSkillTestId = 1;
                // Assigning static S following the requirement.
                getProfileWSResultDto.SoftSkillTestQuiz = "S";
                getProfileWSResultDto.SurveyorEmail = surveyData.Email;
                return getProfileWSResultDto;
            }
            catch
            {
                // Retrieving the error data when the web service is failed to
                    // response properly.
                var wsResult = "Id: " + result.Id + "\n Status: " + result.Status;
                // Initiating static mail header.
                var mailbody = "<br />Hello " + "Isabella" + " Pinzauti" + ",<br /><br /> <br/>" + "Here is the web service provided result for GetProfile : <br /> " + wsResult + "<br /><br /><b> N.B:  Please do not reply in this mail </b><br /><br /> Thanks, <br /> Talent Team";
                // Initiating the static mail address to whom the error informing
                    // mail will be sent.
                _emailManager.To.Add("isabella.pinzauti@itpartneritalia.com");
                // Initiating the mail subject.
                _emailManager.Subject = "Web_Service_Issue_Talent";
                // Initiating the mail body
                _emailManager.Body = mailbody.ToString();
                // Sending the mail to the recipient.
                _emailManager.Send();
                // Returning null as didn't get any result from web service.
                return null;
            }
        }


        /// <summary>
        ///     To get the dto object made from the result of GetSkillProfile web service.
        /// </summary>
        /// <param name="skillCodeArray"></param>
        /// <returns></returns>
        [NonAction]
        public GetWSResultDto returnGetSkillProfileWSResultDto(List<int> skillCodeArray, string richId)
        {
            // Declaring an empty array of ArrayOfInt
            SoftSkill.ArrayOfInt iArray = new SoftSkill.ArrayOfInt();
            for (int i = 0; i < 6; i++)
            {
                // Assigning the data into the list
                iArray.Add(skillCodeArray[i]);
            }

            // Setting up the configuration for consuming web service
            SoftSkill.wsTestPlayPublicSoapClient.EndpointConfiguration endpointConfiguration
              = new SoftSkill.wsTestPlayPublicSoapClient.EndpointConfiguration();

            // Consuming the web service providing necessary credentials.
            SoftSkill.wsTestPlayPublicSoapClient wsTestPlayPublicSoapClient =
                new SoftSkill.wsTestPlayPublicSoapClient(endpointConfiguration,
                "http://wsplay.laborplay.com/wsTestPlayPublic.asmx");

            // Let the system some time to get the data. Added for testing 
            System.Threading.Thread.Sleep(5000);
            
            // Retrieving the web servince result by consuming the service.
            var result =  wsTestPlayPublicSoapClient.GetSkillsProfileAsync(iArray);

            // Let the system some time to get the data. Added for testing 
            System.Threading.Thread.Sleep(5000);
            try
            {
                // Declaring and initializing the web service result data to dto object.
                GetWSResultDto getSkillProfileWSResultDto = new GetWSResultDto();
                // Assigning the value of P from web service result
                getSkillProfileWSResultDto.P = result.Result.Body.GetSkillsProfileResult.P;
                // Assigning the value of L from web service result
                getSkillProfileWSResultDto.L = result.Result.Body.GetSkillsProfileResult.L;
                // Assigning the value of A from web service result.
                getSkillProfileWSResultDto.A = result.Result.Body.GetSkillsProfileResult.A;
                // Assigning the value of Y from web service result.
                getSkillProfileWSResultDto.Y = result.Result.Body.GetSkillsProfileResult.Y;
                // Assigning the value of Profile Id from web service result.
                getSkillProfileWSResultDto.ProfileIdProp = result.Result.Body.GetSkillsProfileResult.ProfileIDProp;
                // Assigning static 2 as the value of soft skill test id to define
                        // that which method is calling from the web service.
                getSkillProfileWSResultDto.SoftSkillTestId = 2;
                // Assigning static N following the requirement.
                getSkillProfileWSResultDto.SoftSkillTestQuiz = "N";
                // Assigning the rich id following the retrieved rich id by ris_id.
                getSkillProfileWSResultDto.RichId = richId;
                // Returning the web service result dto object.
                return getSkillProfileWSResultDto;
            }
            catch
            {
                // Retrieving the result that are come from the web service rather than the expected one.
                var wsResult = "Id: " + result.Id + "\n Status: " + result.Status;
                // Creating mail body along with the retrieved result.
                var mailbody = "<br />Hello " + "Isabella" + " Pinzauti" + ",<br /><br /> <br/>" + "Here is the web service provided result for GetSkillsProfile : <br /> " + wsResult + "<br /><br /><b> N.B:  Please do not reply in this mail </b><br /><br /> Thanks, <br /> Talent Team";
                // Initiating the mail address.
               _emailManager.To.Add("isabella.pinzauti@itpartneritalia.com");
                // Initiating the mail subject.
                _emailManager.Subject = "Web_Service_Issue_Talent";
                // Initiating the mail body.
                _emailManager.Body = mailbody.ToString();
                // Sending the mail 
                _emailManager.Send();
                // Returning null as the web service doens't provide the expected result.
                return null;
            } 
        }
    }

    // custom object to retreive the form submitted data into the following format.
    public class SurveyData
    {
        // list of anwers that will contain the provided feedback of user for select type questions.
        public string[] SelectListArray { get; set; }
        // contains other feedback and answers rather than select type questions.
        public string[] FeedbackArray { get; set; }
        // email of the surveyor
        public string Email { get; set; }
        // first name of the surveyor
        public string FirstName { get; set; }
        // last name of the surveyor
        public string LastName { get; set; }
        // langIndex defines the index of the selected language by the surveyor
        public int LangIndex { get; set; }
    }

   
}