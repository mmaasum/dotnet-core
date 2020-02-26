using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;


namespace Talent.Web.Controllers.Administrative
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlobalGridController : ControllerBase
    {

        private readonly IAzioniManager _azioniManager;
        private readonly IGlobalGridManager _globalGridManager;
        private readonly IUtilityManager _utilityManager;

        public GlobalGridController(IGlobalGridManager globalGridManager, IAzioniManager azioniManager, IUtilityManager utilityManager)
        {
            _globalGridManager = globalGridManager;
            _azioniManager = azioniManager;
            _utilityManager = utilityManager;
        }

        /// <summary>
        ///   To count the record of Master_Filter_User table by filter id.
        /// </summary>
        /// <param name="filterId"></param>
        /// <returns>int/number of record found</returns>
        [HttpGet]
        [Route("CountMasterFilterUtentiByFilterId/{filterId}")]
        public async Task<IActionResult> CountMasterFilterUtentiByFilterId(int filterId)
        {
            try
            {
                // passing the filter id to retrieve the number of record found for that filter.
                var data = await _globalGridManager.CountMasterFilterUtentiByFilterIdAsync(filterId);


                // creating the azioni object passing the related details and description.
                var azioniDto =  _utilityManager.GetAzioniDtoObject(User, "get", "Count Master Filter User Info By Filter" + "");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);

                return Ok(data);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Count Master Filter User Info By Filter");
                if (x.Message == "Token Expired")
                {
                    return Unauthorized();
                }
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///     To get the button group based on retrieve data.
        /// Like a set of button will be generated following the range like A-D,E-H,...,U-Z
        /// based on the retrieve data.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="clientId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="filterSortingDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetDynamicGroupButton/{tableName}/{clientId}/{pageIndex}/{pageSize}")]
        public async Task<IActionResult> GetDynamicGroupButton(string tableName, string clientId, int pageIndex, int pageSize, [FromBody]FilterSortingDto filterSortingDto)
        {
            try
            {
                var data = await _globalGridManager.GetDynamicGroupButtonAsync
                                        (tableName, clientId, pageIndex, pageSize,filterSortingDto);

                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "Dynamic Group Button");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);


                return Ok(data);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Dynamic Group Button");
                return BadRequest(errorObj);
            }
        }


        [HttpGet]
        [Route("GetGenericSearch/{moduleName}/{clientId}")]
        public async Task<IActionResult> GetGenericSearch(string moduleName, string clientId)
        {
            try
            {
                string searchedData = HttpContext.Request.Query["search"].ToString();
                var data = await _globalGridManager.GetGenericSearchedDataAsync(searchedData, moduleName, clientId);
              
                //// creating the azioni object passing the related details and description.
                //var azioniDto = await _utilityManager.GetAzioniDtoObject(User, "get", " Generic Search Data");
                //// logging the activity record by the user.
                //await _talentBLLWrapper.AzuiniBll.AzioniInsert(azioniDto);

                return Ok(data);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Error Generic Search Data");
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///     To store the order of saved search filter.
        /// </summary>
        /// <param name="savedFilterSortingDto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("SortingSavedSearch")]
        public async Task<IActionResult> SortingSavedFilter([FromBody] List<SavedFilterSortingDto> savedFilterSortingDto)
        {
            try
            {
                if (savedFilterSortingDto == null)
                {
                    return NotFound();
                }
                await _globalGridManager.SortingSavedFilterDataAsync(savedFilterSortingDto);

                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "update", "saved filter sorting");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok();
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Update saved filter sorting");
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///     To get the saved search of any ag-Grid datatable based on the several criteria posted through api body.
        /// </summary>
        /// <param name="gridPostDto">
        ///     dto object that contain the following attributes:
        ///     table name: in which table data the filter is applied,
        ///     client id: client id of the logged in utenti,
        ///     ute id: unique id of the logged in utenti,
        ///     accessLevel: to define which filters should be shown. private or public.
        /// </param>
        /// <returns>List of saved search</returns>
        // POST: api/GlobalGrid/getsearchnames/
        [HttpPost]
        [Route("getsearchnames")]
        public async Task<IActionResult> GetSearchNames([FromBody]GlobalGridPostDto gridPostDto)
        {
            try
            {
                var data = await _globalGridManager.FindByGridFiltriMasterDataAsync(gridPostDto);
                if (data == null)
                {
                    return NotFound();
                }

                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "search names");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(data);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Get Saved Search Names");
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///     To insert any filter/search pattern of any ag-Grid datatable.
        /// </summary>
        /// <param name="globalGridDto">dto object having all the related criteria of a search to be saved/inserted</param>
        /// <returns>general confirmation message</returns>
        // POST: api/GlobalGrid/postgridsearches/
        [HttpPost]
        [Route("postgridsearches")]
        public async Task<IActionResult> PostGridSearches(GlobalGridMasterDto globalGridDto)
        {
            try
            {
                if (globalGridDto == null)
                {
                    return NotFound();
                }
                await _globalGridManager.InsertGridSearchesDataAsync(globalGridDto);

                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "add", globalGridDto.SearchName + " filter on " + globalGridDto.TableName);
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok();
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Save Search Filter on " + globalGridDto.TableName);
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///     To get the specific search pattern from saved search list based on search name and client id.
        /// </summary>
        /// <param name="searchName">unique name to be found from saved search list</param>
        /// <param name="clientId">client id of the logged in user.</param>
        /// <returns>Search pattern</returns>
        // GET: api/GlobalGrid/GetSearchData/searchName/clientId
        [HttpGet]
        [Route("GetSearchData/{searchName}/{clientId}")]
        public async Task<IActionResult> GetSearchData(string searchName, string clientId)
        {
            try
            {
                var categories = await _globalGridManager.FindByGridMasterDataAsync(searchName, clientId);
                if (categories == null)
                {
                    return NotFound();
                }

                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", searchName + " filter ");
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok(categories);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Get Search Filter Data");
                return BadRequest(errorObj);
            }

        }


        /// <summary>
        ///     To get the table row data basedd on input params.
        /// </summary>
        /// <param name="tableName">database table name</param>
        /// <param name="clientId">user client id</param>
        /// <param name="pageNumber">pagination page number</param>
        /// <param name="pageSize">pagination page size</param>
        /// <param name="filterSortingDto">filter and sorting object</param>
        /// <returns>Table records</returns>
        // POST: api/GlobalGrid/Fetch/clientId/pageIndex/pageSize

        [Authorize]
        [HttpPost]
        [Route("Fetch/{tableName}/{clientId}/{pageIndex}/{pageSize}")]
        public async Task<IActionResult> Fetch(string tableName, string clientId, int pageIndex, int pageSize, [FromBody]FilterSortingDto filterSortingDto)
        {
            try
            {
                var data = await _globalGridManager.FindFilteredDataAsync(tableName, clientId, pageIndex, pageSize,
                            filterSortingDto);

                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "get", "AG GRID DATA of " + tableName);
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);

                return Ok(data);
            }catch(Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "AG GRID ERROR");
                if(x.Message == "Token Expired")
                {
                    return Unauthorized();
                }
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///     To get the table row count basedd on input params.
        /// </summary>
        /// <param name="tableName">database table name</param>
        /// <param name="clientId">user client id</param>
        /// <param name="filterSortingDto">filter and sorting object</param>
        /// <returns>Table records count</returns>
        // POST: api/GlobalGrid/Fetch/clientId/pageIndex/pageSize
        [HttpPost]
        [Route("TotalRecords/{tableName}/{clientId}")]
        public async Task<IActionResult> TotalRecords(string tableName, string clientId, [FromBody]FilterSortingDto filterSortingDto)
        {
            var data = await _globalGridManager.FindTotalRecordsAsync(tableName, clientId, filterSortingDto);
            return Ok(data);
        }



        [HttpPost]
        [Route("updategridsearches")]
        public async Task<IActionResult> UpdateGridSearches(GlobalGridMasterDto globalGridDto)
        {
            try
            {
                if (globalGridDto == null)
                {
                    return NotFound();
                }
                await _globalGridManager.UpdateGridSearchesDataAsync(globalGridDto);

                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "update", " search filter " + globalGridDto.SearchName);
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);
                return Ok();
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Update Search Filter " + globalGridDto.SearchName);
                return BadRequest(errorObj);
            }
        }

        /// <summary>
        ///  To delete any grid searches.
        /// </summary>
        /// <param name="searchName"></param>
        /// <param name="cliId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("deletegridsearches/{searchName}/{cliId}")]
        public async Task<IActionResult> DeleteGridSearches(string searchName, string cliId)
        {
            try
            {
                await _globalGridManager.DeleteGridSearchesDataAsync(searchName, cliId);
                return Ok();
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Delete Search Filter");
                return BadRequest(errorObj);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        ///     Get the fieldlist of grid by page name, language and filter type.
        /// </summary>
        /// <param name="pageName">Field of which page neet to be retrieved</param>
        /// <param name="langName">Field name should be shown of language name</param>
        /// <param name="fieldType">To define whether fields for sorting or filter need to be retrieved.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetFieldsByPage/{pageName}/{langName}/{fieldType}")]
        public async Task<IActionResult> GetFieldsByPage(string pageName, string langName, string fieldType)
        {
            try
            {
                var data = await _globalGridManager.GetFieldsByPageDataAsync(pageName, langName, fieldType);

 
                //// creating the azioni object passing the related details and description.
                //var azioniDto = await _utilityManager.GetAzioniDtoObject(User, "get", "AG GRID DATA of " + tableName);
                //// logging the activity record by the user.
                //await _talentBLLWrapper.AzuiniBll.AzioniInsert(azioniDto);

                return Ok(data);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "AG GRID ERROR");
                if (x.Message == "Token Expired")
                {
                    return Unauthorized();
                }
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///  To get the details of a filter by filter id.
        /// </summary>
        /// <param name="filterId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetMasterFilterDetailsById/{filterId}")]
        public async Task<IActionResult> GetFilterDetails(int filterId)
        {
            try
            {
             
                var data = await _globalGridManager.GetMasterFilterDetailsByIdAsync(filterId);


                //// creating the azioni object passing the related details and description.
                //var azioniDto = await _utilityManager.GetAzioniDtoObject(User, "get", "AG GRID DATA of " + tableName);
                //// logging the activity record by the user.
                //await _talentBLLWrapper.AzuiniBll.AzioniInsert(azioniDto);

                return Ok(data);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "AG GRID ERROR");
                if (x.Message == "Token Expired")
                {
                    return Unauthorized();
                }
                return BadRequest(errorObj);
            }
        }


        [HttpGet]
        [Route("GetMasterFilterUtentiDetailsByUtenti/{filterId}/{uteId}")]
        public async Task<IActionResult> GetMasterFilterUtentiDetailsByUtenti(int filterId, string uteId)
        {
            try
            {

                var data = await _globalGridManager.GetMasterFilterUtentiDetailsByUtentiAsync(filterId,uteId);
             

                //// creating the azioni object passing the related details and description.
                //var azioniDto = await _utilityManager.GetAzioniDtoObject(User, "get", "AG GRID DATA of " + tableName);
                //// logging the activity record by the user.
                //await _talentBLLWrapper.AzuiniBll.AzioniInsert(azioniDto);

                return Ok(data);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "AG GRID ERROR");
                if (x.Message == "Token Expired")
                {
                    return Unauthorized();
                }
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///   Create a new filter record in database.
        /// </summary>
        /// <param name="masterFilterDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PostMasterFilter")]
        public async Task<IActionResult> PostMasterFilter(MasterFilterDto masterFilterDto)
        {
            try
            {
                var data = await _globalGridManager.InsertMasterFilterDataAsync(masterFilterDto);


                //// creating the azioni object passing the related details and description.
                //var azioniDto = await _utilityManager.GetAzioniDtoObject(User, "get", "AG GRID DATA of " + tableName);
                //// logging the activity record by the user.
                //await _talentBLLWrapper.AzuiniBll.AzioniInsert(azioniDto);

                return Ok(data);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "AG GRID ERROR");
                if (x.Message == "Token Expired")
                {
                    return Unauthorized();
                }
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///     To get the data record set by a filter id.
        /// </summary>
        /// <param name="filterSortingDto"></param>
        /// <param name="filterId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="forCount"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("FetchMasterFilterData/{filterId}/{pageSize}/{langName}/{pageIndex}/{forCount}")]
        public async Task<IActionResult> FetchMasterFilterData([FromBody]FilterSortingDto filterSortingDto, int filterId, int pageSize, string langName, int pageIndex = 0, bool forCount = false)
        {
            try
            {
                var data = await _globalGridManager.GetMasterFilterAppliedDataAsync(filterId, pageSize, pageIndex, forCount, filterSortingDto,langName);

                //// creating the azioni object passing the related details and description.
                //var azioniDto = await _utilityManager.GetAzioniDtoObject(User, "get", "AG GRID DATA of " + tableName);
                //// logging the activity record by the user.
                //await _talentBLLWrapper.AzuiniBll.AzioniInsert(azioniDto);
                
                return Ok(data);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "AG GRID ERROR");
                if (x.Message == "Token Expired")
                {
                    return Unauthorized();
                }
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///  To get the data record set by filter object defined by the user.
        /// </summary>
        /// <param name="filterWrapDto"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="forCount"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("FetchMasterFilterDataByObj/{pageSize}/{langName}/{pageIndex}/{forCount}")]
        public async Task<IActionResult> FetchMasterFilterDataByObj([FromBody]FilterWrapDto filterWrapDto, int pageSize, string langName, int pageIndex = 0, bool forCount = false)
        {
            try
            {
                var data = await _globalGridManager.GetMasterFilterAppliedDataByObjAsync(filterWrapDto.masterFilterDto, pageSize, pageIndex, forCount, filterWrapDto.filterSortingDto,langName);

                //// creating the azioni object passing the related details and description.
                //var azioniDto = await _utilityManager.GetAzioniDtoObject(User, "get", "AG GRID DATA of " + tableName);
                //// logging the activity record by the user.
                //await _talentBLLWrapper.AzuiniBll.AzioniInsert(azioniDto);

                return Ok(data);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "AG GRID ERROR");
                if (x.Message == "Token Expired")
                {
                    return Unauthorized();
                }
                return BadRequest(errorObj);
            }
        }

        // this API will be deleted when the second one will be confirmed.
        [HttpGet]
        [Route("GetMasterFilterListByUtenti/{uteId}/{pageName}")]
        public async Task<IActionResult> GetMasterFilterListByUtenti(string uteId, string pageName)
        {
            try
            {

                var data = await _globalGridManager.GetMasterFilterListByUserAsync(uteId, pageName);

                //// creating the azioni object passing the related details and description.
                //var azioniDto = await _utilityManager.GetAzioniDtoObject(User, "get", "AG GRID DATA of " + tableName);
                //// logging the activity record by the user.
                //await _talentBLLWrapper.AzuiniBll.AzioniInsert(azioniDto);

                return Ok(data);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Master Filter Insert");
                if (x.Message == "Token Expired")
                {
                    return Unauthorized();
                }
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///     To get the saved filter list of a specific user for that specific page.
        /// </summary>
        /// <param name="uteId">user id of logged in user.</param>
        /// <param name="pageName">for which page the filters should be retreived.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetFilterListByUtenti/{uteId}/{pageName}/{langName}")]
        public async Task<IActionResult> GetFilterListByUtenti(string uteId, string pageName, string langName)
        {
            try
            {

                var data = await _globalGridManager.GetFilterListByUtentiDataAsync(User,uteId, pageName, langName);
                if(data == null)
                {
                    return NotFound();
                }

                //// creating the azioni object passing the related details and description.
                //var azioniDto = await _utilityManager.GetAzioniDtoObject(User, "get", "AG GRID DATA of " + tableName);
                //// logging the activity record by the user.
                //await _talentBLLWrapper.AzuiniBll.AzioniInsert(azioniDto);

                return Ok(data);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Master Filter Insert");
                if (x.Message == "Token Expired")
                {
                    return Unauthorized();
                }
                return BadRequest(errorObj);
            }
        }



        /// <summary>
        ///  To update/modify any saved filter.
        /// </summary>
        /// <param name="masterFilterDto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateMasterFilter")]
        public async Task<IActionResult> UpdateMasterFilter(MasterFilterDto masterFilterDto)
        {
            try
            {
                var data = await _globalGridManager.UpdateMasterFilterDataAsync(masterFilterDto, User);

                // creating the azioni object passing the related details and description.
                var azioniDto = _utilityManager.GetAzioniDtoObject(User, "update", " saved filter " + masterFilterDto.TntfilFiltropagId);
                // logging the activity record by the user.
                await _azioniManager.AzioniInsert(azioniDto);

                return Ok(data);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Master Filter Update");
                if (x.Message == "Token Expired")
                {
                    return Unauthorized();
                }
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///  To delete any saved filter.
        /// </summary>
        /// <param name="filterId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteMasterFilter/{filterId}")]
        public async Task<IActionResult> DeleteMasterFilter(int filterId)
        {
            try
            {
                var data = await _globalGridManager.DeleteMasterFilterDataAsync(filterId);


                //// creating the azioni object passing the related details and description.
                //var azioniDto = await _utilityManager.GetAzioniDtoObject(User, "get", "AG GRID DATA of " + tableName);
                //// logging the activity record by the user.
                //await _talentBLLWrapper.AzuiniBll.AzioniInsert(azioniDto);

                return Ok(data);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Master Filter Delete");
                if (x.Message == "Token Expired")
                {
                    return Unauthorized();
                }
                return BadRequest(errorObj);
            }
        }

        /// <summary>
        ///  To get all the font list saved in the database.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllFontList")]
        public async Task<IActionResult> GetAllFontList()
        {
            try
            {
                var data = await _globalGridManager.GetAllFontListDataAsync();
                
                //// creating the azioni object passing the related details and description.
                //var azioniDto = await _utilityManager.GetAzioniDtoObject(User, "get", "AG GRID DATA of " + tableName);
                //// logging the activity record by the user.
                //await _talentBLLWrapper.AzuiniBll.AzioniInsert(azioniDto);

                return Ok(data);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Master Filter Insert");
                if (x.Message == "Token Expired")
                {
                    return Unauthorized();
                }
                return BadRequest(errorObj);
            }
        }

        /// <summary>
        ///  To get all the font size saved in the database.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllFontSizeList")]
        public async Task<IActionResult> GetAllFontSizeList()
        {
            try
            {
                var data = await _globalGridManager.GetAllFontSizeListDataAsync();                
                //// creating the azioni object passing the related details and description.
                //var azioniDto = await _utilityManager.GetAzioniDtoObject(User, "get", "AG GRID DATA of " + tableName);
                //// logging the activity record by the user.
                //await _talentBLLWrapper.AzuiniBll.AzioniInsert(azioniDto);
                return Ok(data);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Master Filter Insert");
                if (x.Message == "Token Expired")
                {
                    return Unauthorized();
                }
                return BadRequest(errorObj);
            }
        }



        /// <summary>
        ///     To get the field name description by page name and language name.
        /// </summary>
        /// <param name="pageName"></param>
        /// <param name="langName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetGridFieldsDescrByPage/{pageName}/{langName}")]
        public async Task<IActionResult> GetGridFieldsDescrByPage(string pageName, string langName)
        {
            try
            {
                var data = await _globalGridManager.GetGridFieldsDescrByPageBllAsync(pageName, langName);

                //// creating the azioni object passing the related details and description.
                //var azioniDto = await _utilityManager.GetAzioniDtoObject(User, "get", "AG GRID DATA of " + tableName);
                //// logging the activity record by the user.
                //await _talentBLLWrapper.AzuiniBll.AzioniInsert(azioniDto);

                return Ok(data);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "AG GRID ERROR");
                if (x.Message == "Token Expired")
                {
                    return Unauthorized();
                }
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///   Get the grid user details for a specific user.
        /// </summary>
        /// <param name="uteId"></param>
        /// <param name="cliId"></param>
        /// <param name="gridName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTalentGridUserDetailsByUteInfo/{uteId}/{cliId}/{gridName}")]
        public async Task<IActionResult> GetTalentGridUserDetailsByUteInfo(string uteId, string cliId, string gridName)
        {
            try
            {
                var data = await _globalGridManager.GetTalentGridUserDetailsByUteInfoDataAsync(uteId, cliId, gridName);
                //// creating the azioni object passing the related details and description.
                //var azioniDto = await _utilityManager.GetAzioniDtoObject(User, "get", "AG GRID DATA of " + tableName);
                //// logging the activity record by the user.
                //await _talentBLLWrapper.AzuiniBll.AzioniInsert(azioniDto);

                return Ok(data);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "AG GRID ERROR");
                if (x.Message == "Token Expired")
                {
                    return Unauthorized();
                }
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///     To get grid fields user details for a specific user.
        /// </summary>
        /// <param name="uteId"></param>
        /// <param name="cliId"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTalentGridFieldsUserDetails/{uteId}/{cliId}/{fieldName}")]
        public async Task<IActionResult> GetTalentGridFieldsUserDetails(string uteId, string cliId, string fieldName)
        {
            try
            {
                var data = await _globalGridManager.GetTalentGridFieldsUserDetailsDataAsync(uteId, cliId, fieldName);
                //// creating the azioni object passing the related details and description.
                //var azioniDto = await _utilityManager.GetAzioniDtoObject(User, "get", "AG GRID DATA of " + tableName);
                //// logging the activity record by the user.
                //await _talentBLLWrapper.AzuiniBll.AzioniInsert(azioniDto);
                return Ok(data);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "AG GRID ERROR");
                if (x.Message == "Token Expired")
                {
                    return Unauthorized();
                }
                return BadRequest(errorObj);
            }
        }

        /// <summary>
        ///  To get the all the record of Grid Field User table for a specific user.
        /// </summary>
        /// <param name="uteId"></param>
        /// <param name="cliId"></param>
        /// <param name="gridName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTalentGridFieldsUserList/{uteId}/{cliId}")]
        public async Task<IActionResult> GetTalentGridFieldsUserList(string uteId, string cliId, string gridName)
        {
            try
            {
                var data = await _globalGridManager.GetTalentGridFieldsUserListDataAsync(uteId, cliId);
                //// creating the azioni object passing the related details and description.
                //var azioniDto = await _utilityManager.GetAzioniDtoObject(User, "get", "AG GRID DATA of " + tableName);
                //// logging the activity record by the user.
                //await _talentBLLWrapper.AzuiniBll.AzioniInsert(azioniDto);

                return Ok(data);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "AG GRID ERROR");
                if (x.Message == "Token Expired")
                {
                    return Unauthorized();
                }
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///     To get the user custom grid settings along with fields info.
        /// </summary>
        /// <param name="uteId"></param>
        /// <param name="cliId"></param>
        /// <param name="gridName"></param>
        /// <param name="langName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTalentGridUserDetailsWithFields/{uteId}/{cliId}/{gridName}/{langName}")]
        public async Task<IActionResult> GetTalentGridUserDetailsWithFields(string uteId, string cliId, string gridName, string langName)
        {
            try
            {
                var data = await _globalGridManager.GetTalentGridUserDetailsWithFieldsDataAsync(uteId, cliId, gridName, langName);
                //// creating the azioni object passing the related details and description.
                //var azioniDto = await _utilityManager.GetAzioniDtoObject(User, "get", "AG GRID DATA of " + tableName);
                //// logging the activity record by the user.
                //await _talentBLLWrapper.AzuiniBll.AzioniInsert(azioniDto);

                return Ok(data);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "AG GRID ERROR");
                if (x.Message == "Token Expired")
                {
                    return Unauthorized();
                }
                return BadRequest(errorObj);
            }
        }

   


        /// <summary>
        ///  To create new record for grid field user data.
        /// </summary>
        /// <param name="talentGridFieldsUser"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PostTalentGridFieldUser")]
        public async Task<IActionResult> PostTalentGridFieldUser([FromBody]TalentGridFieldsUser talentGridFieldsUser)
        {
            try
            {
                var data = await _globalGridManager.InsertTalentGridFieldUserAsync(talentGridFieldsUser);
                //// creating the azioni object passing the related details and description.
                //var azioniDto = await _utilityManager.GetAzioniDtoObject(User, "get", "AG GRID DATA of " + tableName);
                //// logging the activity record by the user.
                //await _talentBLLWrapper.AzuiniBll.AzioniInsert(azioniDto);
                return Ok(data);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "AG GRID ERROR");
                if (x.Message == "Token Expired")
                {
                    return Unauthorized();
                }
                return BadRequest(errorObj);
            }
        }

        /// <summary>
        ///  To update/modify the existing record of grid field user data.
        /// </summary>
        /// <param name="talentGridFieldsUser"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateTalentGridFieldUser")]
        public async Task<IActionResult> UpdateTalentGridFieldUser([FromBody]TalentGridFieldsUser talentGridFieldsUser)
        {
            try
            {
                var data = await _globalGridManager.UpdateTalentGridFieldUserDataAsync(talentGridFieldsUser);

                //// creating the azioni object passing the related details and description.
                //var azioniDto = await _utilityManager.GetAzioniDtoObject(User, "get", "AG GRID DATA of " + tableName);
                //// logging the activity record by the user.
                //await _talentBLLWrapper.AzuiniBll.A zioniInsert(azioniDto);

                return Ok(data);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Master Filter Update");
                if (x.Message == "Token Expired")
                {
                    return Unauthorized();
                }
                return BadRequest(errorObj);
            }
        }




        /// <summary>
        ///  To manager user grid field data. Here manage means, system check that there's any data
        ///  to update , otherwise insert new.
        /// </summary>
        /// <param name="talentGridUserWIthFieldsDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ManageTalentGridUserWithFields")]
        public async Task<IActionResult> ManageTalentGridUserWithFields([FromBody]TalentGridUserWIthFieldsDto talentGridUserWIthFieldsDto)
        {
            try
            {
                var data = await _globalGridManager.ManageTalentGridUserWithFieldsAsync(talentGridUserWIthFieldsDto);
                //// creating the azioni object passing the related details and description.
                //var azioniDto = await _utilityManager.GetAzioniDtoObject(User, "get", "AG GRID DATA of " + tableName);
                //// logging the activity record by the user.
                //await _talentBLLWrapper.AzuiniBll.AzioniInsert(azioniDto);
                return Ok(data);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "AG GRID ERROR");
                if (x.Message == "Token Expired")
                {
                    return Unauthorized();
                }
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///  To delete all the custom grid field settings of a user.
        /// </summary>
        /// <param name="uteId"></param>
        /// <param name="cliId"></param>
        /// <param name="gridName"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteAllCustomGridSettingByUser/{uteId}/{cliId}/{gridName}")]
        public async Task<IActionResult> DeleteAllCustomGridSettingByUser(string uteId, string cliId, string gridName)
        {
            try
            {
                var data = await _globalGridManager.DeleteAllCustomGridSettingByUserDataAsync(uteId, cliId, gridName);
                //// creating the azioni object passing the related details and description.
                //var azioniDto = await _utilityManager.GetAzioniDtoObject(User, "get", "AG GRID DATA of " + tableName);
                //// logging the activity record by the user.
                //await _talentBLLWrapper.AzuiniBll.AzioniInsert(azioniDto);
                return Ok(data);
            }
            catch (Exception x)
            {
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "AG GRID ERROR");
                if (x.Message == "Token Expired")
                {
                    return Unauthorized();
                }
                return BadRequest(errorObj);
            }
        }


    }
}
