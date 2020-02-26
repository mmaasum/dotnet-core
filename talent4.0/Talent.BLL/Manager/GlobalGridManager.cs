using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;
using Talent.Common.Enums;
using Talent.Common.ExtensionMethods;
using Talent.DataModel;
using Talent.DataModel.DataModels;
using Talent.DataModel.Models;

namespace Talent.BLL.Manager
{
    public class GlobalGridManager : IGlobalGridManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        // These fields will be removed in refactoring..
        private readonly GlobalGridMasterDto _gridMasterDto;
        private readonly UtentiDto _utentiDto;
        private readonly GenericSearchedDataDto _genericSearchedDataDto;
        private readonly MasterFilterFieldsDto _filterPageFieldsDto;
        private readonly MasterFilterDto _masterFilterDto;
        private readonly MasterFilterCustomDto _masterFilterCustomDto;
        private readonly MasterGridFieldDto _masterGridFieldDto;
        private readonly TalentGridFieldsUser _talentGridFieldsUser;
        private readonly TalentGridUser _talentGridUser;
        private readonly IUtilityManager _utilityManager;


        public GlobalGridManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;


            // these fields will be removed in refactoring..
            _gridMasterDto = new GlobalGridMasterDto();
            _utentiDto = new UtentiDto();
            _genericSearchedDataDto = new GenericSearchedDataDto();
            _filterPageFieldsDto = new MasterFilterFieldsDto();
            _masterFilterDto = new MasterFilterDto();;
            _masterFilterCustomDto = new MasterFilterCustomDto();
            _masterGridFieldDto = new MasterGridFieldDto();
            _talentGridUser = new TalentGridUser();
            _talentGridFieldsUser = new TalentGridFieldsUser();
            _utilityManager = new UtilityManager();
        }


        public async Task<IEnumerable<GridFiltriMaster>> FindByGridFiltriMasterDataAsync(GlobalGridPostDto gridPostDto)
        {
            if (gridPostDto.AccessLevel)
            {
                var gridFiltriMasterList = await _unitOfWork.GridFiltriMaster
                    .FindInOrderAsync(
                        x => (x.GridfilmaAccessLevel == true || x.GridfilmaInsUteId == gridPostDto.UteId)
                            && x.GridfilmaGridtabNome.Equals(gridPostDto.TableName)
                            && x.GridfilmaCliId.Equals(gridPostDto.CliId),
                        x => x.GridfilmaAccessLevel,
                        OrderType.Descending
                    );

                return gridFiltriMasterList.ToList();
            }
            else
            {
                var gridFiltriMasterList = await _unitOfWork.GridFiltriMaster
                    .FindInOrderAsync(
                        x => (x.GridfilmaAccessLevel == false && x.GridfilmaInsUteId == gridPostDto.UteId)
                            && x.GridfilmaGridtabNome.Equals(gridPostDto.TableName)
                            && x.GridfilmaCliId.Equals(gridPostDto.CliId),
                        x => x.GridfilmaAccessLevel,
                        OrderType.Descending
                    );

                return gridFiltriMasterList.ToList();
            }

        }

        public async Task<string> InsertGridSearchesDataAsync(GlobalGridMasterDto gridMasterDto)
        {
            // Model class mapping from GlobalGridMasterDto to GridMaster.
            var gridMaster = _gridMasterDto.MapForInsert(gridMasterDto);
            gridMaster.GridfilmaInsTimestamp = DateTime.Now;
            gridMaster.GridfilmaModTimestamp = DateTime.Now;

            if (gridMasterDto.AccessLevel == false)
            {
                var data = await _unitOfWork.GridFiltriMaster
                    .CountAsync(
                        x => x.GridfilmaUteId.Equals(gridMasterDto.UteId)
                             && x.GridfilmaCliId.Equals(gridMasterDto.CliId)
                             && x.GridfilmaAccessLevel == false
                             && x.GridfilmaGridtabNome.Equals(gridMaster.GridfilmaGridtabNome)
                    );

                gridMaster.GridfilmaNomeOrder = data + 1;
            }
            else
            {
                gridMaster.GridfilmaNomeOrder = 0;
            }


            // Insert data
            _unitOfWork.GridFiltriMaster.Add(gridMaster);
            await _unitOfWork.CompleteAsync();

            return gridMaster.GridfilmaNome;
        }

        public async Task<string> UpdateGridSearchesDataAsync(GlobalGridMasterDto gridMasterDto)
        {
            var updatableGridMaster = await _unitOfWork.GridFiltriMaster
                .FindAndOrderByAccessLevelDescendingThenByNameAscendingAsync(
                    x =>
                            x.GridfilmaNome == gridMasterDto.SearchName
                            && x.GridfilmaCliId.Equals(gridMasterDto.CliId)
                 );



            // Model class mapping from GlobalGridMasterDto to GridMaster.
            var gridMaster = _gridMasterDto.MapForUpdate(gridMasterDto, updatableGridMaster.First());
            gridMaster.GridfilmaModTimestamp = DateTime.Now;


            await _unitOfWork.CompleteAsync();

            return gridMaster.GridfilmaNome;
        }

        public async Task<string> DeleteGridSearchesDataAsync(string searchName, string cliId)
        {
            var gridFiltriMaster = await _unitOfWork.GridFiltriMaster
                .FirstOrDefaultAsync(c => c.GridfilmaNome.Equals(searchName) && c.GridfilmaCliId.Equals(cliId));

            _unitOfWork.GridFiltriMaster.Remove(gridFiltriMaster);
            await _unitOfWork.CompleteAsync();

            return searchName;
        }

        public async Task<GridFiltriMaster> FindByGridMasterDataAsync(string searchName, string clientId)
        {
            var gridFiltriMaster = await _unitOfWork.GridFiltriMaster
                .FirstOrDefaultAsync(x => x.GridfilmaNome.Equals(searchName) && x.GridfilmaCliId.Equals(clientId));

            return gridFiltriMaster;
        }

        public async Task<ReturnSearchDataDto> FindFilteredDataAsync(string tableName, string clientId, int pageIndex, int pageSize,
            FilterSortingDto filterSortingDto)
        {
            ReturnSearchDataDto returnSearchDataDto = new ReturnSearchDataDto();

            var query = GenerateFilterSortingQuery(tableName, clientId, pageIndex, pageSize, filterSortingDto, "fetch");
            Console.WriteLine(query);
            var data = await _unitOfWork.GenericQuery.FindDataFromRawQueryAsync(query, tableName);
            var datas = data;
            switch (tableName)
            {
                case "utenti":
                    datas = data.Select(x => _utentiDto.MapObjectToDto(x));
                    //var dt1 = data.Select(x => x as UtentiDto).ToList();
                    //datas = dt1;
                    break;
                case "v_risorse_no_allegati":
                    var dt = data.Select(x => x as RisorseDto).ToList();
                    datas = dt;
                    break;
                case "termini":
                    var terminiData = data.Select(x => x as ViewTermini).ToList();
                    datas = terminiData;
                    break;
                case "gestione_termini":
                    var iTerminiData = data.Select(x => x as ViewTermini).ToList();
                    datas = iTerminiData;
                    break;
                case "azioni":
                    var azioniData = data.Select(x => x as ViewAzioni).ToList();
                    datas = azioniData;
                    var groupData1 = azioniData
                                    .GroupBy(c => c.tipi_azione_descr_OF_tpazdescr_descrizione)
                                    .Select(group => new
                                    {
                                        GroupByFieldName = group.Key,
                                        GroupByCount = group.Count()
                                    }).ToList();
                    returnSearchDataDto.GroupData1 = groupData1;
                    var groupData2 = azioniData
                                   .GroupBy(c => c.tipi_azione_categoria_descr_OF_tpazcatdescr_descrizione)
                                   .Select(group => new
                                   {
                                       GroupByFieldName = group.Key,
                                       GroupByCount = group.Count()
                                   }).ToList();
                    returnSearchDataDto.GroupData2 = groupData2;
                    break;
                default:
                    break;
            }

            // Total row counts begin
            query = GenerateFilterSortingQuery(tableName, clientId, 0, 0, filterSortingDto, "count");
            var rowCountData = await _unitOfWork.GenericQuery.FindDataFromRawQueryAsync(query, "row_count");
            var rowCountObj = (TableRecordCount)rowCountData.ToList().FirstOrDefault();
            int totalRecords = rowCountObj.number_of_record;

            // Total row counts end
            //var dataObj = await _wrapper.GridRepo.FindByGridTalentFiltriPagineAsync(x => x.TntfilFiltropagId == masterFilterDto.TntfilFiltropagId);
            //MasterFilterDto mfDto = _masterFilterDto.MapTalentFiltriPagineCampiToDto(dataObj);

            returnSearchDataDto.TotalRecords = totalRecords;
            returnSearchDataDto.data = datas;
            return returnSearchDataDto;
        }

        public async Task<int> FindTotalRecordsAsync(string tableName, string clientId, FilterSortingDto filterSortingDto)
        {
            var query = GenerateFilterSortingQuery(tableName, clientId, 0, 0, filterSortingDto, "count");
            var data = await _unitOfWork.GenericQuery.FindDataFromRawQueryAsync(query, "row_count");
            var rowCountObj = (TableRecordCount)data.ToList().FirstOrDefault();
            return rowCountObj.number_of_record;
        }

        public async Task<string> SortingSavedFilterDataAsync(List<SavedFilterSortingDto> savedFilterSortingDto)
        {
            foreach (var savedFilter in savedFilterSortingDto)
            {
                var updatableGridMaster = await _unitOfWork.GridFiltriMaster
                                    .FirstOrDefaultAsync(x =>
                                    x.GridfilmaNome == savedFilter.SearchName
                                    && x.GridfilmaCliId.Equals(savedFilter.CliId));

                updatableGridMaster.GridfilmaNomeOrder = savedFilter.FilterOrder;
                updatableGridMaster.GridfilmaModTimestamp = DateTime.Now;
            }

            await _unitOfWork.CompleteAsync();

            return "ok";
        }

        public async Task<IEnumerable<GenericSearchedDataDto>> GetGenericSearchedDataAsync(string searchedData, string moduleName, string clientId)
        {
            List<GenericSearchDto> genericSearchDto = new List<GenericSearchDto>();
            genericSearchDto = GenerateGenericSearchObjList(searchedData, moduleName);

            String[] castedColumnName = new string[3] { "RetrievedDataName", "RetrievedDataKey", "RetrievedDataClientId" };

            List<GenericSearchedDataDto> gsdDtoList = new List<GenericSearchedDataDto>();

            foreach (var genericSearch in genericSearchDto)
            {
                var retrievedColumnIndex = 0;
                var conditionedColumnIndex = 0;

                var query = " SELECT ";
                foreach (var retrieveColumn in genericSearch.RetrievedColumns)
                {
                    if (retrievedColumnIndex > 0) { query += " , "; }
                    query += " CONVERT(varchar(30), " + retrieveColumn + " ) AS " + castedColumnName[retrievedColumnIndex];
                    retrievedColumnIndex++;
                }

                query += " FROM " + genericSearch.TableName;
                query += " WHERE " + genericSearch.ClientColumn + " = '" + clientId + "'";

                foreach (var conditionedColumn in genericSearch.ConditionedColumns)
                {
                    if (conditionedColumnIndex == 0) { query += " AND ( "; } else { query += " OR "; }
                    query += conditionedColumn + " LIKE " + "'%" + genericSearch.SearchedData + "%'";
                    conditionedColumnIndex++;
                }

                if (conditionedColumnIndex > 0) { query += " ) "; }

                var dataObjList = await _unitOfWork.GenericQuery.FindDataFromRawQueryAsync(query, "generic_search");

                foreach (var dataObj in dataObjList)
                {
                    GenericSearchedDataDto gsdDto = _genericSearchedDataDto.MapObjectToDto(dataObj, genericSearch.TableName);
                    gsdDtoList.Add(gsdDto);
                }
            }

            IEnumerable<GenericSearchedDataDto> gsdDtoIEnumerable = gsdDtoList;
            return gsdDtoIEnumerable;
        }

        public async Task<IEnumerable<string>> GetDynamicGroupButtonAsync(string tableName, string clientId, int pageNumber, int pageSize,
            FilterSortingDto filterSortingDto)
        {
            TableInfoDto tblInfo = new TableInfoDto();
            tblInfo = GenerateTableInfoDto(tableName);

            List<string> buttonGroupList = new List<string>();
            var query = " SELECT ";
            query += "LEFT(UPPER(" + tblInfo.RetrievedColumn + "),1)";
            query += " AS " + "ContentFirstLetter";
            query += " FROM " + tableName;

            //query += " WHERE " + tblInfo.ClientColumn + " = '" + clientId + "'";

            query += GenerateFilterSortingQuery(tableName, clientId, pageNumber, pageSize, filterSortingDto, "dynamicButton");

            query += " GROUP BY " + "LEFT(UPPER(" + tblInfo.RetrievedColumn + "),1)";
            query += " ORDER BY " + "ContentFirstLetter";


            var dataObjList = await _unitOfWork.GenericQuery.FindDataFromRawQueryAsync(query, "content_first_letter");

            //foreach (var dataObj in dataObjList)
            //{
            //    DynamicButton dynamicButton = (DynamicButton)dataObj;
            //    buttonGroupList.Add(dynamicButton.ContentFirstLetter);
            //}
            var isAtoD = false;
            var isEtoH = false;
            var isItoL = false;
            var isMtoP = false;
            var isQtoT = false;
            var isUtoZ = false;

            foreach (var dataObj in dataObjList)
            {
                DynamicButton dynamicButton = (DynamicButton)dataObj;

                foreach (char c in dynamicButton.ContentFirstLetter)
                {
                    var asciiValue = (int)c;

                    if (asciiValue >= 65 && asciiValue <= 68 && isAtoD == false)
                    {
                        buttonGroupList.Add("A-D");
                        isAtoD = true;
                    }
                    else if (asciiValue >= 69 && asciiValue <= 72 && isEtoH == false)
                    {
                        buttonGroupList.Add("E-H");
                        isEtoH = true;
                    }
                    else if (asciiValue >= 73 && asciiValue <= 76 && isItoL == false)
                    {
                        buttonGroupList.Add("I-L");
                        isItoL = true;
                    }
                    else if (asciiValue >= 77 && asciiValue <= 80 && isMtoP == false)
                    {
                        buttonGroupList.Add("M-P");
                        isMtoP = true;
                    }
                    else if (asciiValue >= 81 && asciiValue <= 84 && isQtoT == false)
                    {
                        buttonGroupList.Add("Q-T");
                        isQtoT = true;
                    }
                    else if (asciiValue > 84 && isUtoZ == false)
                    {
                        buttonGroupList.Add("U-Z");
                        isUtoZ = true;
                    }
                }
            }

            return buttonGroupList;
        }

        public async Task<IEnumerable<MasterFilterFieldsDto>> GetFieldsByPageDataAsync(string pageName, string langName, string fieldType)
        {
            var data = await _unitOfWork.TalentFiltriPagineCampi.GetFieldsDescrByPageDal(pageName, langName, fieldType);
            return new List<MasterFilterFieldsDto>(data.Select(x => _filterPageFieldsDto.MapTalentFiltriPagineCampiToDto(x))).OrderBy(c => c.TntfilFiltropagcampoFiltroOrdineVis);

            //if (fieldType == "filter")
            //{
            //    // Fetching data from dal.
            //    var data = await _wrapper.GridRepo.FindByGridFiltriPagineCampiAsync(
            //                                      x => x.TntfilFiltropagcampoPagina.Equals(pageName)
            //                                        && x.TntfilFiltropagcampoAttivo.Equals("S"));
            //    // Returning the retrieved data to controller end
            //    return new List<MasterFilterFieldsDto>(data.Select(x => _filterPageFieldsDto.MapTalentFiltriPagineCampiToDto(x))).OrderBy(c => c.TntfilFiltropagcampoFiltroOrdineVis);
            //}
            //else
            //{
            //    // only order fields will be loaded
            //    var data = await _wrapper.GridRepo.FindByGridFiltriPagineCampiAsync(
            //                            x => x.TntfilFiltropagcampoPagina.Equals(pageName)
            //                              && x.TntfilFiltropagcampoSoloFiltro.Equals("N")
            //                              && x.TntfilFiltropagcampoAttivo.Equals("S"));
            //    // Returning the retrieved data to controller end
            //    return new List<MasterFilterFieldsDto>(data.Select(x => _filterPageFieldsDto.MapTalentFiltriPagineCampiToDto(x))).OrderBy(c => c.TntfilFiltropagcampoSortOrdineVis);
            //}
        }

        public async Task<MasterFilterDto> GetMasterFilterDetailsByIdAsync(int filterId)
        {
            var data = await _unitOfWork.TalentFiltriPagine
                            .FirstOrDefaultAsync(x => x.TntfilFiltropagId == filterId);

            return _masterFilterDto.MapTalentFiltriPagineCampiToDto(data);
        }

        public async Task<IEnumerable<MasterFilterDto>> GetMasterFilterListByUserAsync(string uteId, string pageName)
        {
            // Fetching data from dal.
            var dataList = await _unitOfWork.TalentFiltriPagine
                            .FindAsync(x => x.TntfilFiltropagPaginaCodice == pageName
                                && (x.TntfilFiltropagInsUteId == uteId || x.TntfilFiltropagPubblico == "S"));


            // retrieving the default user filter of user
            TalentFiltriPagineUtenti defaultUserFilterObj = await _unitOfWork.MasterFilterUtenti
                                        .FirstOrDefaultAsync(x => x.TntfilFiltropaguteDefault == "S"
                                                 && x.TntfilFiltropaguteUteId == uteId);
            long id = 0;
            if (defaultUserFilterObj != null)
            {
                // retreving the filter master id
                id = defaultUserFilterObj.TntfilFiltropaguteFiltropagId;
            }

            List<MasterFilterDto> masterFilterDtoList = new List<MasterFilterDto>();
            foreach (var data in dataList)
            {
                MasterFilterDto masterFilterDto = new MasterFilterDto();
                masterFilterDto = _masterFilterDto.MapTalentFiltriPagineCampiToDto(data);
                if (data.TntfilFiltropagId == id)
                {
                    masterFilterDto.TntfilFiltropagUteDefault = "S";
                }
                masterFilterDtoList.Add(masterFilterDto);
            }

            return masterFilterDtoList;
        }

        public async Task<IEnumerable<MasterFilterCustomDto>> GetFilterListByUtentiDataAsync(ClaimsPrincipal User, string uteId, string pageName, string langName)
        {
            // Fetching data from dal.
            var data = await _unitOfWork.MasterFilterUtenti.GetFilterListByUtentiAsync(uteId, pageName);
            var dataList = data.ToArray();
            var translatedButtonName = _utilityManager.GetTranslatedData(langName, "filter_loc_", "$.filter.usrmsg_info.L7524_buttonNotAssigned");

            var masterFilterCustomDtoList = new MasterFilterCustomDto[4];
            for (var i = 0; i < masterFilterCustomDtoList.Length; i++)
            {
                MasterFilterCustomDto masterFilterCustomDto = new MasterFilterCustomDto
                {
                    TntfilFiltropagUteButtonId = (i + 1),
                    TntfilFiltropagUteButtonLabel = translatedButtonName,
                    TntfilFiltropagUteFiltroPagId = -1
                };
                masterFilterCustomDtoList[i] = masterFilterCustomDto;
            }

            foreach (var item in dataList)
            {
                if (item.TntfilFiltropagUteButtonId != null)
                {
                    var btnId = item.TntfilFiltropagUteButtonId.Value;
                    if (btnId != 0)
                    {
                        masterFilterCustomDtoList[btnId - 1] = item;
                    }
                }
            }

            return masterFilterCustomDtoList.ToList();
        }

        public async Task<long> InsertMasterFilterDataAsync(MasterFilterDto masterFilterDto)
        {
            TalentFiltriPagine masterFilterObj = _masterFilterDto.MapForInsert(masterFilterDto);

            masterFilterObj.TntfilFiltropagInsTimestamp = DateTime.Now;
            masterFilterObj.TntfilFiltropagModTimestamp = DateTime.Now;

            _unitOfWork.TalentFiltriPagine.Add(masterFilterObj);
            await _unitOfWork.CompleteAsync();

            // check whether the current filter is saves as default.
            if (masterFilterDto.TntfilFiltropagUteDefault == "S")
            {
                // retrieving all the other existing default filters.
                var existingDefaultFilterList = await _unitOfWork.MasterFilterUtenti
                                        .FindAsync(x => x.TntfilFiltropaguteDefault == "S"
                                                  && x.TntfilFiltropaguteUteId == masterFilterDto.TntfilFiltropagInsUteId);
                // Checking if the list have any data
                if (existingDefaultFilterList != null)
                {
                    // Run a loop over all the filters which are set default earlier.
                    foreach (var existingDefaultFilter in existingDefaultFilterList)
                    {
                        // Setting the default status as 'N' which had status 'S' earlier
                        existingDefaultFilter.TntfilFiltropaguteDefault = "N";
                        // updating the default status.
                        //var updatedRecordId = await _wrapper.GridRepo.UpdateMasterFilterUtentiAsync(existingDefaultFilter);
                    }
                }
            }
           

            TalentFiltriPagineUtenti mfu = CreateMasterFilterUtentiDmoObj(masterFilterDto, masterFilterObj.TntfilFiltropagId);
            if (String.IsNullOrEmpty(masterFilterDto.TntfilFiltropagUteButtonLabel))
            {
                mfu.TntfilFiltropaguteBottone = 0;
                mfu.TntfilFiltropaguteBottoneLabel = "";
            }

            _unitOfWork.MasterFilterUtenti.Add(mfu);

            await _unitOfWork.CompleteAsync();

            return masterFilterObj.TntfilFiltropagId;
        }

        public async Task<long> UpdateMasterFilterDataAsync(MasterFilterDto updatedMasterFilterDto, ClaimsPrincipal User)
        {
            // retrieving the updatable filter from system.
            var updatableMasterFilter = await _unitOfWork.TalentFiltriPagine.FirstOrDefaultAsync
                                        (x => x.TntfilFiltropagId == updatedMasterFilterDto.TntfilFiltropagId);
            // Converting to talent filtri pagine from dto object to pass into dal.
            updatableMasterFilter = _masterFilterDto.MapForUpdate(updatedMasterFilterDto, updatableMasterFilter);
            updatableMasterFilter.TntfilFiltropagModTimestamp = DateTime.Now;


            // Filter which aren't set as default and also removed from the synced button
            // isn't necessary to keep in user filter record table.
            var deletableRowList = await _unitOfWork.MasterFilterUtenti.FindAsync(
                                              x => x.TntfilFiltropaguteDefault == "N"
                                              && x.TntfilFiltropaguteBottone == 0
                                              && x.TntfilFiltropaguteId != updatedMasterFilterDto.TntfilFiltropagUteId);
            
            _unitOfWork.MasterFilterUtenti.RemoveRange(deletableRowList);

            await _unitOfWork.CompleteAsync();



            // retrieving all filters have the same button id but not the same filtropagId.
            var existingFilterListHavingSameButtonId
                    = await _unitOfWork.MasterFilterUtenti.FindAsync(
                            x => x.TntfilFiltropaguteBottone == updatedMasterFilterDto.TntfilFiltropagUteButtonId
                                && x.TntfilFiltropaguteUteId == updatedMasterFilterDto.TntfilFiltropagInsUteId
                                && x.TntfilFiltropaguteId != updatedMasterFilterDto.TntfilFiltropagUteId);

            // run loop over the list
            foreach (var existingFilter in existingFilterListHavingSameButtonId)
            {
                // setting the button label as empty string
                existingFilter.TntfilFiltropaguteBottoneLabel = "";
                // setting the button id 0 as it's id is being used by updated filter.
                existingFilter.TntfilFiltropaguteBottone = 0;
            }



            // check whether the current filter is saves as default.
            if (updatedMasterFilterDto.TntfilFiltropagUteDefault == "S")
            {
                // retrieving all the other existing default filters.
                var existingDefaultFilterList = await _unitOfWork.MasterFilterUtenti.FindAsync(
                                                x => x.TntfilFiltropaguteDefault == "S"
                                                  && x.TntfilFiltropaguteUteId == updatedMasterFilterDto.TntfilFiltropagInsUteId);
                // Checking if the list have any data
                if (existingDefaultFilterList != null)
                {
                    // Run a loop over all the filters which are set default earlier.
                    foreach (var existingDefaultFilter in existingDefaultFilterList)
                    {
                        // Setting the default status as 'N' which had status 'S' earlier
                        existingDefaultFilter.TntfilFiltropaguteDefault = "N";
                    }
                }
            }



            updatedMasterFilterDto.TntfilFiltropagInsUteId = User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"))?.Value;

            await _unitOfWork.CompleteAsync();


            // check if the user filter data is exist earlier or not. 0 means not.
            if (updatedMasterFilterDto.TntfilFiltropagUteId == 0)
            {
                if (!String.IsNullOrEmpty(updatedMasterFilterDto.TntfilFiltropagUteButtonLabel)
                    || updatedMasterFilterDto.TntfilFiltropagUteDefault == "S")
                {
                    // create the user filter record as it doesn't exist earlier but exist now.
                    TalentFiltriPagineUtenti mfu = CreateMasterFilterUtentiDmoObj(updatedMasterFilterDto, updatableMasterFilter.TntfilFiltropagId);

                    _unitOfWork.MasterFilterUtenti.Add(mfu);
                }
            }
            else
            {
                try
                {
                    // update theuser filter record as it was exists earlier and now as well.
                    TalentFiltriPagineUtenti updatableRow = await _unitOfWork.MasterFilterUtenti.FirstOrDefaultAsync(
                                     x => x.TntfilFiltropaguteId == updatedMasterFilterDto.TntfilFiltropagUteId);

                    updatableRow.TntfilFiltropaguteBottoneLabel = updatedMasterFilterDto.TntfilFiltropagUteButtonLabel;
                    updatableRow.TntfilFiltropaguteBottone = updatedMasterFilterDto.TntfilFiltropagUteButtonId;
                    updatableRow.TntfilFiltropaguteDefault = updatedMasterFilterDto.TntfilFiltropagUteDefault;

                    await _unitOfWork.CompleteAsync();
                }
                catch
                {
                    if (!String.IsNullOrEmpty(updatedMasterFilterDto.TntfilFiltropagUteButtonLabel)
                        || updatedMasterFilterDto.TntfilFiltropagUteDefault == "S")
                    {

                        // create the user filter record as it doesn't exist earlier but exist now.
                        TalentFiltriPagineUtenti mfu = CreateMasterFilterUtentiDmoObj(updatedMasterFilterDto, updatableMasterFilter.TntfilFiltropagId);
                        _unitOfWork.MasterFilterUtenti.Add(mfu);
                        await _unitOfWork.CompleteAsync();
                    }
                }

            }

            return updatableMasterFilter.TntfilFiltropagId;
        }

        public async Task<long> DeleteMasterFilterDataAsync(int filterId)
        {

            // Filter which aren't set as default and also removed from the synced button
            // isn't necessary to keep in user filter record table.
            var deletableRowList = await _unitOfWork.MasterFilterUtenti.FindAsync(
                                              x => x.TntfilFiltropaguteDefault == "N"
                                              && x.TntfilFiltropaguteBottone == 0);

            _unitOfWork.MasterFilterUtenti.RemoveRange(deletableRowList);

            await _unitOfWork.CompleteAsync();

            var masterFilter = await _unitOfWork.TalentFiltriPagine.FirstOrDefaultAsync(x => x.TntfilFiltropagId == filterId);

            _unitOfWork.TalentFiltriPagine.Remove(masterFilter);
            await _unitOfWork.CompleteAsync();

            return masterFilter.TntfilFiltropagId;
        }

        public async Task<ReturnSearchDataDto> GetMasterFilterAppliedDataAsync(int filterId, int pageSize, int pageIndex, bool forCount,
            FilterSortingDto filterSortingDto, string langName)
        {
            var masterFilter = await _unitOfWork.TalentFiltriPagine.FirstOrDefaultAsync(x => x.TntfilFiltropagId == filterId);
            MasterFilterDto masterFilterDto = _masterFilterDto.MapTalentFiltriPagineCampiToDto(masterFilter);

            var data = await GetMasterFilterAppliedDataByObjAsync(masterFilterDto, pageSize, pageIndex, forCount, filterSortingDto, langName);
            return data;
        }

        public async Task<ReturnSearchDataDto> GetMasterFilterAppliedDataByObjAsync(MasterFilterDto masterFilterDto, int pageSize, int pageIndex, bool forCount,
            FilterSortingDto filterSortingDto, string langName)
        {
            ReturnSearchDataDto returnSearchDataDto = new ReturnSearchDataDto();
            if (forCount == false)
            {
                var query = await GenerateMasterFilterGetDataQuery(masterFilterDto, pageIndex, pageSize, filterSortingDto, langName);
              
                var queryString = new StringBuilder(query);
                queryString = queryString.Replace("@userlanguage", langName);
                var finalQuery = queryString.ToString();
                Console.WriteLine(queryString);
                var data = await _unitOfWork.GenericQuery.FindDataFromRawQueryAsync(query, masterFilterDto.TntfilFiltropagPaginaCodice);
                var datas = data;
                switch (masterFilterDto.TntfilFiltropagPaginaCodice)
                {
                    case "utenti":
                        datas = data.Select(x => _utentiDto.MapObjectToDto(x));
                        break;
                    case "v_risorse_no_allegati":
                        // datas = data.Select(x => _risorseDto.MapObjectToDto(x));
                        datas = data.Select(x => x as RisorseDto);
                        break;
                    case "azioni":
                        var azioniData = data.Select(x => x as ViewAzioni).ToList();
                        datas = azioniData;
                        var groupData1 = azioniData
                                        .GroupBy(c => c.tipi_azione_descr_OF_tpazdescr_descrizione)
                                        .Select(group => new
                                        {
                                            GroupByFieldName = group.Key,
                                            GroupByCount = group.Count()
                                        }).ToList();
                        returnSearchDataDto.GroupData1 = groupData1;
                        var groupData2 = azioniData
                                       .GroupBy(c => c.tipi_azione_categoria_descr_OF_tpazcatdescr_descrizione)
                                       .Select(group => new
                                       {
                                           GroupByFieldName = group.Key,
                                           GroupByCount = group.Count()
                                       }).ToList();
                        returnSearchDataDto.GroupData2 = groupData2;
                        break;
                    default:
                        break;

                }

                //Total row counts begin
                var countQuery = await GenerateMasterFilterRowCountQuery(masterFilterDto, filterSortingDto, langName);
                var rowCountData = await _unitOfWork.GenericQuery.FindDataFromRawQueryAsync(countQuery, "row_count");
                var rowCountObj = (TableRecordCount)rowCountData.ToList().FirstOrDefault();
                int totalRecords = rowCountObj.number_of_record;

                returnSearchDataDto.TotalRecords = totalRecords;
                returnSearchDataDto.data = datas;
                return returnSearchDataDto;


                //Total row counts end
                //return new ReturnSearchDataDto(totalRecords, datas);
            }
            else
            {
                // Total row counts begin
                var countQuery = await GenerateMasterFilterRowCountQuery(masterFilterDto, filterSortingDto, langName);
                var rowCountData = await _unitOfWork.GenericQuery.FindDataFromRawQueryAsync(countQuery, "row_count");
                var rowCountObj = (TableRecordCount)rowCountData.ToList().FirstOrDefault();
                int totalRecords = rowCountObj.number_of_record;

                returnSearchDataDto.TotalRecords = totalRecords;
                //returnSearchDataDto.data = datas;
                return returnSearchDataDto;

                // Total row counts end
                //return new ReturnSearchDataDto(totalRecords, null);
            }
        }

        public async Task<MasterFilterCustomDto> GetMasterFilterUtentiDetailsByUtentiAsync(int filterId, string uteId)
        {
            var data = await _unitOfWork.MasterFilterUtenti.FirstOrDefaultAsync(
                x => x.TntfilFiltropaguteFiltropagId == filterId
                     && x.TntfilFiltropaguteUteId == uteId);

            if (data != null)
            {
                return _masterFilterCustomDto.MapMasterFilterUtentiToCustomDto(data);
            }
            MasterFilterCustomDto masterFilterCustomDto = new MasterFilterCustomDto();
            return masterFilterCustomDto;
        }

        public async Task<int> CountMasterFilterUtentiByFilterIdAsync(int filterId)
        {
            var data = await _unitOfWork.MasterFilterUtenti.CountAsync(
                x => x.TntfilFiltropaguteFiltropagId == filterId
                     && (x.TntfilFiltropaguteBottone != 0
                         || x.TntfilFiltropaguteDefault != "N"));

            return data;
        }

        public async Task<IEnumerable<TalentFontNameDto>> GetAllFontListDataAsync()
        {
            var fonts = await _unitOfWork.TalentFontNomi.FindAsync(x => x.TntfontNomeFont != null);
            return _mapper.Map<List<TalentFontNameDto>>(fonts.ToList());
        }

        public async Task<IEnumerable<TalentFontSizeDto>> GetAllFontSizeListDataAsync()
        {
            var sizes = await _unitOfWork.TalentFontDimensioni.FindAsync(x => x.TntszFontDimensione != 0);
            return _mapper.Map<List<TalentFontSizeDto>>(sizes.ToList());
        }

        public async Task<IEnumerable<TalentGridFieldsUser>> GetGridFieldsDescrByPageBllAsync(string gridName, string langName)
        {
            var data = await _unitOfWork.TalentGriglieCampi.GetGridFieldsDescrByPageDal(gridName, langName);

            return new List<TalentGridFieldsUser>(data.Select(x => _masterGridFieldDto.MapGridFieldToGridFieldUserDto(x))).OrderBy(c => c.TntgcuFieldName);
        }

        public async Task<TalentGridUser> GetTalentGridUserDetailsByUteInfoDataAsync(string uteId, string cliId, string gridName)
        {
            var data = await _unitOfWork.TalentGriglieUtenti.FirstOrDefaultAsync(
                x => x.TntgruUteId == uteId
                     && x.TntgruCliId == cliId
                     && x.TntgruNomeGriglia == gridName);

            if (data == null)
            {
                TalentGridUser talentGridUser = new TalentGridUser();
                return talentGridUser;
            }
            return _talentGridUser.MapToDto(data);
        }

        public async Task<TalentGridFieldsUser> GetTalentGridFieldsUserDetailsDataAsync(string uteId, string cliId, string fieldName)
        {
            var data = await _unitOfWork.TalentGriglieCampiUtenti.FirstOrDefaultAsync(
                x => x.TntgcuUteId == uteId
                     && x.TntgcuCliId == cliId
                     && x.TntgcuTntgcNomeCampo == fieldName);

            if (data != null)
            {
                return _talentGridFieldsUser.MapToDto(data);
            }

            TalentGridFieldsUser talentGridFieldsUser = new TalentGridFieldsUser();
            return talentGridFieldsUser;
        }

        public async Task<IEnumerable<TalentGridFieldsUser>> GetTalentGridFieldsUserListDataAsync(string uteId, string cliId)
        {
            var data = await _unitOfWork.TalentGriglieCampiUtenti.FindAsync(
                x => x.TntgcuUteId == uteId
                     && x.TntgcuCliId == cliId);
            return new List<TalentGridFieldsUser>(data.Select(x => _talentGridFieldsUser.MapToDto(x))).OrderBy(c => c.TntgcuOrderPosition);
        }

        public async Task<TalentGridUserWIthFieldsDto> GetTalentGridUserDetailsWithFieldsDataAsync(string uteId, string cliId, string gridName, string langName)
        {
            var talentGridUserData = await _unitOfWork.TalentGriglieUtenti.FirstOrDefaultAsync(
                                           x => x.TntgruUteId == uteId
                                             && x.TntgruCliId == cliId
                                             && x.TntgruNomeGriglia == gridName);
            if (talentGridUserData == null)
            {
                talentGridUserData = await _unitOfWork.TalentGriglieUtenti.FirstOrDefaultAsync(
                                       x => x.TntgruUteId == "system"
                                         && x.TntgruCliId == cliId
                                         && x.TntgruNomeGriglia == gridName);
            }

            var iTalentGridUserData = _talentGridUser.MapToDto(talentGridUserData);

            //var talentGridFieldsUserListData = await _wrapper.GridRepo.GetTalentGridFieldsUserListAsync(
            //                x => x.TntgcuUteId == uteId
            //                  && x.TntgcuCliId == cliId);

            var talentGridFieldsUserListData = await _unitOfWork.TalentGriglieCampiUtenti.GetJoinTalentGridFieldsUserListAsync(uteId, cliId, gridName, langName);

            if (talentGridFieldsUserListData.Count() == 0)
            {
                talentGridFieldsUserListData = await _unitOfWork.TalentGriglieCampiUtenti.GetJoinTalentGridFieldsUserListAsync("system", cliId, gridName, langName);
            }

            var iTalentGridFieldsUserListData = new List<TalentGridFieldsUser>(talentGridFieldsUserListData.Select(x => _talentGridFieldsUser.MapToDto(x))).OrderBy(c => c.TntgcuOrderPosition);
            foreach (var itgfuld in iTalentGridFieldsUserListData)
            {
                itgfuld.TntgcuFieldLabelDescription = await _unitOfWork.TalentGriglieCampiUtenti.GetSpecificFieldDescription(itgfuld.TntgcuFieldName, langName);
            }

            return new TalentGridUserWIthFieldsDto(iTalentGridUserData, iTalentGridFieldsUserListData);
        }

        public async Task<int> InsertTalentGridFieldUserAsync(TalentGridFieldsUser talentGridFieldsUserDto)
        {
            var talentGriglieCampiUtenti = _talentGridFieldsUser.MapForInsert(talentGridFieldsUserDto);

            _unitOfWork.TalentGriglieCampiUtenti.Add(talentGriglieCampiUtenti);
            await _unitOfWork.CompleteAsync();

            return talentGriglieCampiUtenti.TntgcuId;
        }

        public async Task<int> UpdateTalentGridFieldUserDataAsync(TalentGridFieldsUser talentGridFieldsUserDto)
        {
            var updatableModelObj = await _unitOfWork.TalentGriglieCampiUtenti.FirstOrDefaultAsync(
                x => x.TntgcuUteId == talentGridFieldsUserDto.TntgcuUteId
                     && x.TntgcuCliId == talentGridFieldsUserDto.TntgcuCliId
                     && x.TntgcuTntgcNomeCampo == talentGridFieldsUserDto.TntgcuFieldName);

            updatableModelObj = _talentGridFieldsUser.MapForUpdate(talentGridFieldsUserDto, updatableModelObj);

            await _unitOfWork.CompleteAsync();

            return updatableModelObj.TntgcuId;
        }

        public async Task<int> ManageTalentGridUserWithFieldsAsync(TalentGridUserWIthFieldsDto talentGridUserWIthFieldsDto)
        {
            TalentGridUser talentGridUser = talentGridUserWIthFieldsDto.TalentGridUser;

            var updatableTalentGridUserData = await _unitOfWork.TalentGriglieUtenti.FirstOrDefaultAsync(
                                       x => x.TntgruUteId == talentGridUser.TntgruUteId
                                         && x.TntgruCliId == talentGridUser.TntgruCliId
                                         && x.TntgruNomeGriglia == talentGridUser.TntgruGridName);

            // Checking whether the data exist or not.
            if (updatableTalentGridUserData == null)
            {
                // If doesn't exist , then insert the data into the master table.
                var talentGriglieUtenti = _talentGridUser.MapForInsert(talentGridUser);
                talentGriglieUtenti.TntgruInsTimestamp = DateTime.Now;
                talentGriglieUtenti.TntgruModTimestamp = DateTime.Now;
                talentGriglieUtenti.TntgruId = 0;

                _unitOfWork.TalentGriglieUtenti.Add(talentGriglieUtenti);
                await _unitOfWork.CompleteAsync();
            }
            else
            {
                // If exists, then update the master table data.
                var talentGriglieUtenti = _talentGridUser.MapForUpdate(talentGridUser, updatableTalentGridUserData);
                talentGriglieUtenti.TntgruModTimestamp = DateTime.Now;

                var query = "Update talent_griglie_utenti ";
                query += "Set ";
                query += "tntgru_tntfont_nome_font = '" + talentGriglieUtenti.TntgruTntfontNomeFont + "' , ";
                query += "tntgru_tntsz_font_dimensione = " + talentGriglieUtenti.TntgruTntszFontDimensione + " , ";
                query += "tntgru_mostra_numeri_riga = '" + talentGriglieUtenti.TntgruMostraNumeriRiga + "' , ";
                query += "tntgru_colore_righe_pari = '" + talentGriglieUtenti.TntgruColoreRighePari + "' , ";
                query += "tntgru_colore_righe_dispari = '" + talentGriglieUtenti.TntgruColoreRigheDispari + "' , ";
                query += "tntgru_mod_timestamp = '" + talentGriglieUtenti.TntgruModTimestamp + "' ";

                query += "Where ";
                query += "tntgru_nome_griglia = '" + talentGriglieUtenti.TntgruNomeGriglia + "' AND ";
                query += "tntgru_ute_id = '" + talentGriglieUtenti.TntgruUteId + "' AND ";
                query += "tntgru_cli_id = '" + talentGriglieUtenti.TntgruCliId + "' ";

                query += "Select * from talent_griglie_utenti";

                Console.WriteLine(query);
                var data = await _unitOfWork.GenericQuery.FindDataFromRawQueryAsync(query, "talent_griglie_utenti");
                var dataList = data.ToList();
                //return await Task.FromResult(talentGriglieUtenti.TntgruId);
            }

            IEnumerable<TalentGridFieldsUser> talentGridFieldsUserList = talentGridUserWIthFieldsDto.TalentGridFieldsUserList;

            foreach (var gfuData in talentGridFieldsUserList)
            {
                var updatableGfuData = await _unitOfWork.TalentGriglieCampiUtenti.FirstOrDefaultAsync(
                                      x => x.TntgcuUteId == gfuData.TntgcuUteId
                                        && x.TntgcuCliId == gfuData.TntgcuCliId
                                        && x.TntgcuTntgcNomeCampo == gfuData.TntgcuFieldName);

                // Checking whether the data exist or not.
                if (updatableGfuData == null)
                {
                    // if not exist and current state is selected, means need to insert
                    if (gfuData.isActive == true)
                    {
                        // inserting the custom settings for the specific field
                        var talentGriglieCampiUtenti = _talentGridFieldsUser.MapForInsert(gfuData);

                        _unitOfWork.TalentGriglieCampiUtenti.Add(talentGriglieCampiUtenti);
                    }
                }
                else // If the data already exist
                {
                    // if already exist and current state is selected, means need to update
                    if (gfuData.isActive == true)
                    {
                        // updating the custom settings for the specific field
                        updatableGfuData = _talentGridFieldsUser.MapForUpdate(gfuData, updatableGfuData);
                    }
                    else // if already exist and current state is not selected, means need to delete
                    {
                        // Deleting the data for the specific field 
                        updatableGfuData = _talentGridFieldsUser.MapForUpdate(gfuData, updatableGfuData);
                        _unitOfWork.TalentGriglieCampiUtenti.Remove(updatableGfuData);
                    }

                }

                await _unitOfWork.CompleteAsync();
            }
            return talentGridUser.TntgruId;
        }

        public async Task<int> DeleteAllCustomGridSettingByUserDataAsync(string uteId, string clientId, string gridName)
        {
            var masterData = await _unitOfWork.TalentGriglieUtenti.FirstOrDefaultAsync(
                x => x.TntgruUteId == uteId
                     && x.TntgruCliId == clientId
                     && x.TntgruNomeGriglia == gridName);

            if (masterData != null)
            {
                _unitOfWork.TalentGriglieUtenti.Remove(masterData);
            }


            var fieldDataList = await _unitOfWork.TalentGriglieCampiUtenti.FindAsync(
                x => x.TntgcuUteId == uteId
                     && x.TntgcuCliId == clientId);

            _unitOfWork.TalentGriglieCampiUtenti.RemoveRange(fieldDataList.ToList());

            await _unitOfWork.CompleteAsync();
            return 0;
        }















        private async Task<string> GenerateMasterFilterGetDataQuery(MasterFilterDto masterFilterDto, int pageNumber, int pageSize, FilterSortingDto filterSortingDto, string langName)
        {
            //var retrieveFieldCount = 0;
            var masterFilterField = await _unitOfWork.TalentFiltriPagineCampi.FirstOrDefaultAsync(x =>
                                      x.TntfilFiltropagcampoCodice.Equals(masterFilterDto.TntfilFiltropagSelect1FiltropagcampoCodice));
            MasterFilterFieldsDto masterFilterFieldsDto = new MasterFilterFieldsDto();

            masterFilterFieldsDto = _filterPageFieldsDto.MapTalentFiltriPagineCampiToDto(masterFilterField);

            string query = " Select  ";
            query += returnSelectFieldListByPageName(masterFilterDto.TntfilFiltropagPaginaCodice);
            //foreach (var retField in masterFilterDto.TableRetreivedFields)
            //{
            //    if (retrieveFieldCount == 0) { query += retField; }
            //    else { query += " , " + retField; }
            //}

            //query += masterFilterDto.TntfilFiltropagInternalRepresentation;
            //query += GetClientColumnNameByTable();
            query += " FROM ";
            //query += masterFilterFieldsDto.TntfilFiltropagcampoFromList;

            // Add all the join table query
            query += await GenerateMasterFilterJoinTableQuery(masterFilterDto);
            // Add all the where clause.
            query += await GenerateWhereClause(masterFilterDto, filterSortingDto, langName);

            if (!string.IsNullOrEmpty(masterFilterDto.TntfilFiltropagOrder1FiltropagcampoCodice))
            {
                query += " ORDER BY ";
                masterFilterField = await  _unitOfWork.TalentFiltriPagineCampi.FirstOrDefaultAsync(x =>
                                     x.TntfilFiltropagcampoCodice.Equals(masterFilterDto.TntfilFiltropagOrder1FiltropagcampoCodice));

                masterFilterFieldsDto = _filterPageFieldsDto.MapTalentFiltriPagineCampiToDto(masterFilterField);
                query += masterFilterFieldsDto.TntfilFiltropagcampoCampoTabellaDb;
                if (masterFilterDto.TntfilFiltropagOrder1Ascending == "S")
                {
                    query += " ASC ";
                }
                else
                {
                    query += " DESC ";
                }
            }
            else
            {
                query += " ORDER BY " + GetClientColumnNameByTable(masterFilterDto.TntfilFiltropagPaginaCodice);
            }


            if (!string.IsNullOrEmpty(masterFilterDto.TntfilFiltropagOrder2FiltropagcampoCodice))
            {
                query += " , ";
                masterFilterField = await _unitOfWork.TalentFiltriPagineCampi.FirstOrDefaultAsync(x =>
                                     x.TntfilFiltropagcampoCodice.Equals(masterFilterDto.TntfilFiltropagOrder2FiltropagcampoCodice));

                masterFilterFieldsDto = _filterPageFieldsDto.MapTalentFiltriPagineCampiToDto(masterFilterField);
                query += masterFilterFieldsDto.TntfilFiltropagcampoCampoTabellaDb;
                if (masterFilterDto.TntfilFiltropagOrder2Ascending == "S")
                {
                    query += " ASC ";
                }
                else
                {
                    query += " DESC ";
                }
            }

            if (pageSize > 0)
            {
                var offset = " OFFSET " + (pageNumber - 1) * pageSize + " ROWS";
                var take = " FETCH NEXT " + pageSize + " ROWS ONLY";
                query += offset;
                query += take;
            }


            return query;

        }

        private async Task<string> GenerateMasterFilterJoinTableQuery(MasterFilterDto masterFilterDto)
        {
            var query = "";
            var joinTablequery = "";
            var queryCount = 0;
            // retreiving the talent_filtri_pagine_campi records by page_name
            var masterFilterFieldList = (await _unitOfWork.TalentFiltriPagineCampi.FindAsync(x =>
                                        x.TntfilFiltropagcampoPagina.Equals(masterFilterDto.TntfilFiltropagPaginaCodice))
                                        ).Where(c => c.TntfilFiltropagcampoFromList != null).ToList()
                                        .Select(c => c.TntfilFiltropagcampoFromList).Distinct();
            //Loop on the retreived talent_filtri_pagine_campi records
            foreach (var masterFilterField in masterFilterFieldList)
            {
                joinTablequery += masterFilterField + " ";
            }

            //var filteredJoinTableNameList = joinTableNameList.Distinct().ToList();

            //List<string> finalJoinTablesList = new List<string>();
            //foreach (var filteredJoinTableName in filteredJoinTableNameList)
            //{
            //    List<string> tableList = filteredJoinTableName.Split(',').ToList<string>();
            //    foreach (var table in tableList)
            //    {
            //        finalJoinTablesList.Add(table);
            //    }
            //}

            //var filteredFinalJoinTablesList = finalJoinTablesList.Distinct().ToList();
            //foreach (var filteredFinalJoinTables in filteredFinalJoinTablesList)
            //{
            //    joinTablequery += filteredFinalJoinTables + " ";
            //}

            var joinTableNameList = joinTablequery.Split(new string[] { " LEFT JOIN " }, StringSplitOptions.None)
                                    .ToList().Distinct().ToList();
            foreach (var joinTableName in joinTableNameList)
            {
                if (queryCount > 0)
                {
                    query += " LEFT JOIN ";
                }
                query += joinTableName;
                queryCount++;
            }
            return query;
        }


        private async Task<string> GenerateMasterFilterRowCountQuery(MasterFilterDto masterFilterDto, FilterSortingDto filterSortingDto, string langName)
        //private string GenerateMasterFilterRowCountQuery(MasterFilterDto masterFilterDto)
        {
            var countQuery = "SELECT  COUNT(*) As number_of_record FROM ";
            //countQuery += returnActualTableName(masterFilterDto.TntfilFiltropagPaginaCodice);
            countQuery += await GenerateMasterFilterJoinTableQuery(masterFilterDto);
            // Add all the where clause.
            countQuery += await GenerateWhereClause(masterFilterDto, filterSortingDto, langName);
            return countQuery;
        }

        private async Task<string> GenerateWhereClause(MasterFilterDto masterFilterDto, FilterSortingDto filterSortingDto, string langName)
        //private string GenerateWhereClause(MasterFilterDto masterFilterDto)
        {
            var fieldCount = 0;
            var masterFilterField = await _unitOfWork.TalentFiltriPagineCampi.FirstOrDefaultAsync(x =>
                                      x.TntfilFiltropagcampoCodice.Equals(masterFilterDto.TntfilFiltropagSelect1FiltropagcampoCodice));
            MasterFilterFieldsDto masterFilterFieldsDto = new MasterFilterFieldsDto();

            masterFilterFieldsDto = _filterPageFieldsDto.MapTalentFiltriPagineCampiToDto(masterFilterField);



            var whereQuery = " WHERE (";
            whereQuery += GetClientColumnNameByTable(masterFilterDto.TntfilFiltropagPaginaCodice) + " = '" + masterFilterDto.TntfilFiltropagCliId + "')";
            whereQuery += " AND (";
            whereQuery += GetFixedWhereConditionByTable(masterFilterDto.TntfilFiltropagPaginaCodice, langName);


            if (masterFilterDto.TntfilFiltropagPulisciPrecedenti != "S")
            {
                whereQuery += GenerateFetchWhereClause(masterFilterDto.TntfilFiltropagPaginaCodice,
                                                 masterFilterDto.TntfilFiltropagCliId,
                                                 filterSortingDto, "fetch");
                whereQuery += ") AND (";
            }

            List<string> fieldList = masterFilterFieldsDto.TntfilFiltropagcampoCampoTabellaDb.Split(',').ToList<string>();
            fieldList.Reverse();
            foreach (var fieldName in fieldList)
            {
                if (fieldCount > 0)
                {
                    whereQuery += " OR ";
                }
                whereQuery += fieldName;
                whereQuery += ReturnSymbolForDescription(masterFilterDto.TntfilFiltropagSelect1Filtrocond, masterFilterDto.TntfilFiltropagSelect1Valore, fieldName);
                fieldCount++;
            }



            if (masterFilterDto.TntfilFiltropagSelect2FiltropagcampoCodice != null)
            {
                fieldCount = 0;
                whereQuery += ") AND (";
                masterFilterField = await _unitOfWork.TalentFiltriPagineCampi.FirstOrDefaultAsync(x =>
                                     x.TntfilFiltropagcampoCodice.Equals(masterFilterDto.TntfilFiltropagSelect2FiltropagcampoCodice));

                masterFilterFieldsDto = _filterPageFieldsDto.MapTalentFiltriPagineCampiToDto(masterFilterField);

                fieldList = masterFilterFieldsDto.TntfilFiltropagcampoCampoTabellaDb.Split(',').ToList<string>();
                fieldList.Reverse();
                foreach (var fieldName in fieldList)
                {
                    if (fieldCount > 0)
                    {
                        whereQuery += " OR ";
                    }
                    whereQuery += fieldName;
                    whereQuery += ReturnSymbolForDescription(masterFilterDto.TntfilFiltropagSelect2Filtrocond, masterFilterDto.TntfilFiltropagSelect2Valore, fieldName);


                    fieldCount++;
                }
            }

            if (masterFilterDto.TntfilFiltropagSelect3FiltropagcampoCodice != null)
            {
                fieldCount = 0;
                whereQuery += ") AND (";
                masterFilterField = await _unitOfWork.TalentFiltriPagineCampi.FirstOrDefaultAsync(x =>
                                     x.TntfilFiltropagcampoCodice.Equals(masterFilterDto.TntfilFiltropagSelect3FiltropagcampoCodice));

                masterFilterFieldsDto = _filterPageFieldsDto.MapTalentFiltriPagineCampiToDto(masterFilterField);
                fieldList = masterFilterFieldsDto.TntfilFiltropagcampoCampoTabellaDb.Split(',').ToList<string>();
                fieldList.Reverse();
                foreach (var fieldName in fieldList)
                {
                    if (fieldCount > 0)
                    {
                        whereQuery += " OR ";
                    }
                    whereQuery += fieldName;
                    whereQuery += ReturnSymbolForDescription(masterFilterDto.TntfilFiltropagSelect3Filtrocond, masterFilterDto.TntfilFiltropagSelect3Valore, fieldName);
                    fieldCount++;
                }


                //query += masterFilterFieldsDto.TntfilFiltropagcampoCampoTabellaDb;
                //query += returnSymbolForDescription(masterFilterDto.TntfilFiltropagSelect3Filtrocond, masterFilterDto.TntfilFiltropagSelect2Valore);
            }

            whereQuery += ") ";
            return whereQuery;
        }

        private TalentFiltriPagineUtenti CreateMasterFilterUtentiDmoObj(MasterFilterDto masterFilterDto, long id)
        {
            TalentFiltriPagineUtenti mfu = new TalentFiltriPagineUtenti();
            mfu.TntfilFiltropaguteFiltropagId = id;
            mfu.TntfilFiltropaguteUteId = masterFilterDto.TntfilFiltropagInsUteId;
            mfu.TntfilFiltropaguteCliId = masterFilterDto.TntfilFiltropagCliId;
            mfu.TntfilFiltropaguteDefault = masterFilterDto.TntfilFiltropagUteDefault;
            //mfu.TntfilFiltropagUteOrdine = 1;
            mfu.TntfilFiltropaguteBottone = masterFilterDto.TntfilFiltropagUteButtonId;
            mfu.TntfilFiltropaguteBottoneLabel = masterFilterDto.TntfilFiltropagUteButtonLabel;
            mfu.TntfilFiltropaguteInsUteId = masterFilterDto.TntfilFiltropagInsUteId;
            mfu.TntfilFiltropaguteModUteId = masterFilterDto.TntfilFiltropagInsUteId;
            mfu.TntfilFiltropaguteInsTimestamp = DateTime.Now;
            mfu.TntfilFiltropaguteModTimestamp = DateTime.Now;
            return mfu;
        }

        private TableInfoDto GenerateTableInfoDto(string tableName)
        {
            TableInfoDto tblInfoDto = new TableInfoDto();
            tblInfoDto.TableName = tableName;

            if (tableName == "risorse")
            {
                tblInfoDto.RetrievedColumn = "ris_nome";
                tblInfoDto.ClientColumn = "ris_cli_id";
            }
            else if (tableName == "aziende")
            {
                tblInfoDto.RetrievedColumn = "az_rag_sociale";
                tblInfoDto.ClientColumn = "az_cli_id";
            }
            else if (tableName == "contatti")
            {
                tblInfoDto.RetrievedColumn = "cont_nome";
                tblInfoDto.ClientColumn = "cont_cli_id";
            }
            return tblInfoDto;
        }

        private string ReturnSymbolForDescription(string symbolDesc, string value, string fieldName)
        {
            symbolDesc = symbolDesc.ToLower();
            string symbol = "";
            //if (symbolDesc == "equal") { symbol = " = " + value; }
            if (symbolDesc == "lower") { symbol = " < " + value.ParseInt().ToString(); }
            else if (symbolDesc == "greater") { symbol = " > " + value.ParseInt().ToString(); }
            else if (symbolDesc == "lowerorequal") { symbol = " <= " + value.ParseInt().ToString(); }
            else if (symbolDesc == "greaterorequal") { symbol = " >= " + value.ParseInt().ToString(); }

            else if (symbolDesc == "contains") { symbol = " like '%" + value + "%'"; }
            else if (symbolDesc == "notcontains") { symbol = " not like '%" + value + "%'"; }
            else if (symbolDesc == "begins") { symbol = " like '" + value + "%'"; }
            else if (symbolDesc == "notbegins") { symbol = " not like '" + value + "%'"; }
            else if (symbolDesc == "finish") { symbol = " like '%" + value + "'"; }
            else if (symbolDesc == "notfinishes") { symbol = " not like '%" + value + "'"; }
            else if (symbolDesc == "equal") { symbol = " = '" + value + "'"; }
            else if (symbolDesc == "notequal") { symbol = " != '" + value + "'"; }
            else if (symbolDesc == "me") { symbol = " = '" + value + "'"; }

            else if (symbolDesc == "empty") { symbol = " is null "; }
            else if (symbolDesc == "notempty") { symbol = " is not null"; }

            else if (symbolDesc == "before") { symbol = " < '" + ReturnFormattedDateString(value, symbolDesc) + "'"; }
            else if (symbolDesc == "after") { symbol = " > '" + ReturnFormattedDateString(value, symbolDesc) + "'"; }
            else if (symbolDesc == "sameorbefore") { symbol = " <= '" + ReturnFormattedDateString(value, symbolDesc) + "'"; }
            else if (symbolDesc == "sameorafter") { symbol = " >= '" + ReturnFormattedDateString(value, symbolDesc) + "'"; }

            else if (symbolDesc == "range")
            {
                List<string> dateDataList = value.Split('-').ToList<string>();
                //dateDataList.Reverse();

                var count = 0;
                foreach (var dateData in dateDataList)
                {
                    var iDateData = dateData.Trim();
                    if (count == 0)
                    {
                        symbol += " >= '" + ReturnFormattedDateString(iDateData, symbolDesc) + "'" + " and ";
                    }
                    else
                    {
                        symbol += fieldName + " <= '" + ReturnFormattedDateString(iDateData, "sameorbefore") + "'";
                    }
                    count++;
                }
            }

            //if (symbolDesc == "same") { symbol = " > '" + ReturnFormattedDateString(value, symbolDesc) + "'"; }


            return symbol;
        }

        private string ReturnFormattedDateString(string dateString, string symbolDesc)
        {
            var sqlServerDateFormat = AppSettingsDto.SqlServerDateFormat;
            DateTime dateData;
            dateData = FromStringToDate(dateString);

            if (symbolDesc == "after" || symbolDesc == "sameorbefore")
            {
                dateData = FromStringToDate(dateString).AddDays(1).Date;
            }


            return dateData.ToString(sqlServerDateFormat);
        }

        // Generate raw sql query based on Filter Sorting model, table name, client id, pagination information.
        private string GenerateFilterSortingQuery(string tableName, string clientId, int pageNumber, int pageSize,
                                                    FilterSortingDto filterSortingDto, string queryType)
        {
            bool isAdded = false;
            var sqlServerDateFormat = AppSettingsDto.SqlServerDateFormat;
            var selectQuery = " SELECT ";
            var query = "";

            if (queryType == "fetch")
            {
                selectQuery += tableName + ".* ";
            }
            else
            {
                selectQuery += " COUNT(*) As number_of_record ";
            }


            try
            {
                //// To select all the necessary field of other tables.
                if (queryType == "fetch")
                {
                    foreach (var retField in filterSortingDto.JoinTableQueryDto.JoinTableRetreivedFields)
                    {
                        selectQuery += " , " + retField;
                    }
                }

                // From the base table
                selectQuery += " FROM " + tableName;
                isAdded = true;
                // Loop to join several tables in the query.
                foreach (var joinTable in filterSortingDto.JoinTableQueryDto.JoinTable)
                {
                    // Joining the join table one by one.
                    selectQuery += " LEFT JOIN " + joinTable.JoinTableName + " ON ";
                    // Loop to define the joining condition 
                    foreach (var joinField in joinTable.JoinFields.Select((value, index) => new { value, index }))
                    {
                        // Adding 'AND' keyword in case of several field join 
                        if (joinField.index > 0) { selectQuery += " AND "; }
                        selectQuery += joinField.value.BaseTableJoinFieldName + " = " + joinField.value.JoinTableJoinFieldName;

                       
                    }
                }
            }
            catch
            {
                if (!isAdded) { selectQuery += " FROM " + tableName; }
            }

            // For Complex Query retreived from several tables.
            query += " WHERE ";

            //var filters = filterSortingDto.ClientColumn + " = '" + clientId + "'";
            //foreach (var filt in filterSortingDto.Filters)
            //{
            //    //if (filt.DataType == "text")
            //    //{
            //    //    filters += " AND ( ISNULL(" + filt.ColumnName +",'') LIKE '%" + filt.Option1 + "%'";
            //    //    if (!string.IsNullOrEmpty(filt.Option2)) // Here option 2 will be used for the second column which may contain the same data provided in option 2 through column name field.
            //    //    {
            //    //        var allSecondaryColumns = filt.Option2.Split(';');
            //    //        foreach (var secondaryColumn in allSecondaryColumns)
            //    //        {
            //    //            filters += " OR ISNULL(" + secondaryColumn + ",'') LIKE '%" + filt.Option1 + "%'";
            //    //        }                        
            //    //    }
            //    //    filters += ")";
            //    //}
            //    if (filt.DataType == "text")
            //    {
            //        switch (filt.FilterType)
            //        {
            //            case "like":
            //                filters += " AND ( ISNULL(" + filt.ColumnName + ",'') LIKE '%" + filt.Option1 + "%'";
            //                if (!string.IsNullOrEmpty(filt.Option2)) // Here option 2 will be used for the second column which may contain the same data provided in option 2 through column name field.
            //                {
            //                    var allSecondaryColumns = filt.Option2.Split(';');
            //                    foreach (var secondaryColumn in allSecondaryColumns)
            //                    {
            //                        filters += " OR ISNULL(" + secondaryColumn + ",'') LIKE '%" + filt.Option1 + "%'";
            //                    }
            //                }
            //                filters += ")";
            //                break;
            //            case "range":
            //                if (!string.IsNullOrEmpty(filt.Option1) && queryType != "dynamicButton")
            //                {
            //                    var firstChar = filt.Option1[0];
            //                    filters += " AND ( ISNULL(" + filt.ColumnName + ",'') LIKE '" + firstChar + "%'";

            //                    if (filt.Option1.Length > 1)
            //                    {
            //                        var lastChar = filt.Option1[2];
            //                        for (char a = ++firstChar; a <= lastChar; a++)
            //                        {
            //                            filters += " OR ISNULL(" + filt.ColumnName + ",'') LIKE '" + a + "%'";
            //                        }
            //                    }

            //                    filters += ")";
            //                }
            //                break;
            //            default:
            //                break;
            //        }

            //    }
            //    else if (filt.DataType == "datetime" && !string.IsNullOrEmpty(filt.Option1))
            //    {
            //        DateTime option1;
            //        DateTime option2;
            //        switch (filt.FilterType)
            //        {
            //            case "range":
            //                option1 = FromStringToDate(filt.Option1);
            //                if (string.IsNullOrEmpty(filt.Option2))
            //                {
            //                    option2 = DateTime.Now;
            //                }
            //                else
            //                {
            //                    option2 = FromStringToDate(filt.Option2);
            //                    option2 = option2.AddDays(1);
            //                }
            //                filters += " AND " + filt.ColumnName + " >= '" + option1.ToString(sqlServerDateFormat) + "'";
            //                filters += " AND " + filt.ColumnName + " < '" + option2.ToString(sqlServerDateFormat) + "'";
            //                break;
            //            case "equal":

            //                option1 = FromStringToDate(filt.Option1);
            //                option2 = option1.AddDays(1);
            //                filters += " AND " + filt.ColumnName + " >= '" + option1.ToString(sqlServerDateFormat) + "'";
            //                filters += " AND " + filt.ColumnName + " < '" + option2.ToString(sqlServerDateFormat) + "'";
            //                break;
            //            case "greater":
            //                option1 = FromStringToDate(filt.Option1);
            //                filters += " AND " + filt.ColumnName + " >= '" + option1.ToString(sqlServerDateFormat) + "'";
            //                break;
            //            case "smaller":
            //                option1 = FromStringToDate(filt.Option1);
            //                filters += " AND " + filt.ColumnName + " < '" + option1.ToString(sqlServerDateFormat) + "'";
            //                break;
            //            default:
            //                break;
            //        }
            //    }

            //    else if (filt.DataType == "number" && !string.IsNullOrEmpty(filt.Option1))
            //    {
            //        switch (filt.FilterType)
            //        {
            //            case "range":
            //                filters += " AND " + filt.ColumnName + " >= " + filt.Option1;
            //                if (string.IsNullOrEmpty(filt.Option2))
            //                {
            //                    filters += " AND " + filt.ColumnName + " <= " + filt.Option1;
            //                }
            //                else
            //                {
            //                    filters += " AND " + filt.ColumnName + " <= " + filt.Option2;
            //                }

            //                break;
            //            case "equal":
            //                filters += " AND " + filt.ColumnName + " = " + filt.Option1;
            //                break;
            //            case "not_equal":
            //                filters += " AND " + filt.ColumnName + " != " + filt.Option1;
            //                break;
            //            case "greater":
            //                filters += " AND " + filt.ColumnName + " > " + filt.Option1;
            //                break;
            //            case "greater_or_equal":
            //                filters += " AND " + filt.ColumnName + " >= " + filt.Option1;
            //                break;
            //            case "smaller":
            //                filters += " AND " + filt.ColumnName + " < " + filt.Option1;
            //                break;
            //            case "smaller_or_equal":
            //                filters += " AND " + filt.ColumnName + " <= " + filt.Option1;
            //                break;
            //            default:
            //                break;
            //        }
            //    }

            //}



            //if (!String.IsNullOrEmpty(filterSortingDto.Sorting.ColumnName))
            //{
            //    sorting = " ORDER BY " + filterSortingDto.Sorting.ColumnName + " " + filterSortingDto.Sorting.Type;
            //}

            query += GenerateFetchWhereClause(tableName, clientId,
                                                filterSortingDto, queryType);

            if (queryType == "fetch")
            {
                //var sorting = " ORDER BY " + filterSortingDto.DefaultSortingColumn;
                var sorting = " ORDER BY " + filterSortingDto.Sorting.ColumnName + " " + filterSortingDto.Sorting.Type;
                query += sorting;

                var offset = " OFFSET " + (pageNumber - 1) * pageSize + " ROWS";
                var take = " FETCH NEXT " + pageSize + " ROWS ONLY";
                query += offset;
                query += take;
            }

            if (queryType == "dynamicButton")
            {
                return query;
            }
            else
            {
                return selectQuery + query;
            }
        }

        public List<GenericSearchDto> GenerateGenericSearchObjList(string searchedData, string moduleName)
        {
            List<GenericSearchDto> gsDtoList = new List<GenericSearchDto>();

            if (moduleName == "contatti")
            {
                GenericSearchDto gsDto = new GenericSearchDto();
                gsDto.TableName = "utenti";
                gsDto.ClientColumn = "ute_cli_id";
                gsDto.ConditionedColumns = new string[2] { "ute_nome", "ute_ruolo" };
                gsDto.RetrievedColumns = new string[3] { "ute_nome", "ute_id", "ute_cli_id" };
                gsDto.SearchedData = searchedData;
                gsDtoList.Add(gsDto);


                GenericSearchDto gsDto1 = new GenericSearchDto();
                gsDto1.TableName = "risorse";
                gsDto1.ClientColumn = "ris_cli_id";
                gsDto1.ConditionedColumns = new string[1] { "ris_nome" };
                gsDto1.RetrievedColumns = new string[3] { "ris_nome", "ris_id", "ris_cli_id" };
                gsDto1.SearchedData = searchedData;
                gsDtoList.Add(gsDto1);
            }
            else if (moduleName == "aziende")
            {
                GenericSearchDto gsDto = new GenericSearchDto();
                gsDto.TableName = "utenti";
                gsDto.ClientColumn = "ute_cli_id";
                gsDto.ConditionedColumns = new string[2] { "ute_nome", "ute_ruolo" };
                gsDto.RetrievedColumns = new string[3] { "ute_nome", "ute_id", "ute_cli_id" };
                gsDto.SearchedData = searchedData;
                gsDtoList.Add(gsDto);

                GenericSearchDto gsDto1 = new GenericSearchDto();
                gsDto1.TableName = "aziende";
                gsDto1.ClientColumn = "az_cli_id";
                gsDto1.ConditionedColumns = new string[1] { "az_rag_sociale" };
                gsDto1.RetrievedColumns = new string[3] { "az_rag_sociale", "az_id", "az_cli_id" };
                gsDto1.SearchedData = searchedData;
                gsDtoList.Add(gsDto1);
            }

            return gsDtoList;
        }
        private string GenerateFetchWhereClause(string tableName, string clientId,
                                                    FilterSortingDto filterSortingDto, string queryType)
        {

            var sqlServerDateFormat = AppSettingsDto.SqlServerDateFormat;
            string whereQuery = "";
            var filters = filterSortingDto.ClientColumn + " = '" + clientId + "'";
            foreach (var filt in filterSortingDto.Filters)
            {
                //if (filt.DataType == "text")
                //{
                //    filters += " AND ( ISNULL(" + filt.ColumnName +",'') LIKE '%" + filt.Option1 + "%'";
                //    if (!string.IsNullOrEmpty(filt.Option2)) // Here option 2 will be used for the second column which may contain the same data provided in option 2 through column name field.
                //    {
                //        var allSecondaryColumns = filt.Option2.Split(';');
                //        foreach (var secondaryColumn in allSecondaryColumns)
                //        {
                //            filters += " OR ISNULL(" + secondaryColumn + ",'') LIKE '%" + filt.Option1 + "%'";
                //        }                        
                //    }
                //    filters += ")";
                //}
                if (filt.DataType == "text")
                {
                    switch (filt.FilterType)
                    {
                        case "like":
                            if (!string.IsNullOrEmpty(filt.Option1))
                            {
                                filters += " AND ( ISNULL(" + filt.ColumnName + ",'') LIKE '%" + filt.Option1 + "%'";

                                if (!string.IsNullOrEmpty(filt.Option2)) // Here option 2 will be used for the second column which may contain the same data provided in option 2 through column name field.
                                {
                                    var allSecondaryColumns = filt.Option2.Split(';');
                                    foreach (var secondaryColumn in allSecondaryColumns)
                                    {
                                        filters += " OR ISNULL(" + secondaryColumn + ",'') LIKE '%" + filt.Option1 + "%'";
                                    }
                                }
                                filters += ")";
                            }
                            break;
                        case "range":
                            if (!string.IsNullOrEmpty(filt.Option1) && queryType != "dynamicButton")
                            {
                                var firstChar = filt.Option1[0];
                                filters += " AND ( ISNULL(" + filt.ColumnName + ",'') LIKE '" + firstChar + "%'";

                                if (filt.Option1.Length > 1)
                                {
                                    var lastChar = filt.Option1[2];
                                    for (char a = ++firstChar; a <= lastChar; a++)
                                    {
                                        filters += " OR ISNULL(" + filt.ColumnName + ",'') LIKE '" + a + "%'";
                                    }
                                }

                                filters += ")";
                            }
                            break;
                        case "equal":
                            filters += " AND ( ISNULL(" + filt.ColumnName + ",'') = '" + filt.Option1 + "')";
                            break;
                        default:
                            break;
                    }
                }
                else if (filt.DataType == "datetime" && !string.IsNullOrEmpty(filt.Option1))
                {
                    DateTime option1;
                    DateTime option2;
                    switch (filt.FilterType)
                    {
                        case "range":
                            option1 = FromStringToDate(filt.Option1);
                            if (string.IsNullOrEmpty(filt.Option2))
                            {
                                option2 = DateTime.Now;
                            }
                            else
                            {
                                option2 = FromStringToDate(filt.Option2);
                                option2 = option2.AddDays(1);
                            }
                            filters += " AND " + filt.ColumnName + " >= '" + option1.ToString(sqlServerDateFormat) + "'";
                            filters += " AND " + filt.ColumnName + " < '" + option2.ToString(sqlServerDateFormat) + "'";
                            break;
                        case "equal":

                            option1 = FromStringToDate(filt.Option1);
                            option2 = option1.AddDays(1);
                            filters += " AND " + filt.ColumnName + " >= '" + option1.ToString(sqlServerDateFormat) + "'";
                            filters += " AND " + filt.ColumnName + " < '" + option2.ToString(sqlServerDateFormat) + "'";
                            break;
                        case "greater":
                            option1 = FromStringToDate(filt.Option1);
                            filters += " AND " + filt.ColumnName + " >= '" + option1.ToString(sqlServerDateFormat) + "'";
                            break;
                        case "smaller":
                            option1 = FromStringToDate(filt.Option1);
                            filters += " AND " + filt.ColumnName + " < '" + option1.ToString(sqlServerDateFormat) + "'";
                            break;
                        default:
                            break;
                    }
                }

                else if (filt.DataType == "number" && !string.IsNullOrEmpty(filt.Option1))
                {
                    switch (filt.FilterType)
                    {
                        case "range":
                            filters += " AND " + filt.ColumnName + " >= " + filt.Option1;
                            if (string.IsNullOrEmpty(filt.Option2))
                            {
                                filters += " AND " + filt.ColumnName + " <= " + filt.Option1;
                            }
                            else
                            {
                                filters += " AND " + filt.ColumnName + " <= " + filt.Option2;
                            }

                            break;
                        case "equal":
                            filters += " AND " + filt.ColumnName + " = " + filt.Option1;
                            break;
                        case "not_equal":
                            filters += " AND " + filt.ColumnName + " != " + filt.Option1;
                            break;
                        case "greater":
                            filters += " AND " + filt.ColumnName + " > " + filt.Option1;
                            break;
                        case "greater_or_equal":
                            filters += " AND " + filt.ColumnName + " >= " + filt.Option1;
                            break;
                        case "smaller":
                            filters += " AND " + filt.ColumnName + " < " + filt.Option1;
                            break;
                        case "smaller_or_equal":
                            filters += " AND " + filt.ColumnName + " <= " + filt.Option1;
                            break;
                        default:
                            break;
                    }
                }

            }



            //if (!String.IsNullOrEmpty(filterSortingDto.Sorting.ColumnName))
            //{
            //    sorting = " ORDER BY " + filterSortingDto.Sorting.ColumnName + " " + filterSortingDto.Sorting.Type;
            //}
            whereQuery += filters;

            return whereQuery;
        }

        // Convert datetime string to datetime object.
        private DateTime FromStringToDate(string dateString)
        {
            var dateObj = DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            return dateObj;
        }

        private string GetClientColumnNameByTable(string tableName)
        {

            List<string> tableNameList = tableName.Split(',').ToList<string>();
            tableName = tableNameList[0];

            string ccn = "";
            if (tableName == "log_operazioni" || tableName == "visualizza_lista_operazioni") { ccn = "log_cli_id"; }
            if (tableName == "aziende") { ccn = "az_cli_id"; }
            if (tableName == "azioni") { ccn = "azione_cli_id"; }

            if (tableName == "risorse") { ccn = "ris_cli_id"; }
            if (tableName == "richieste") { ccn = "rich_cli_id"; }
            if (tableName == "sedi_aziende") { ccn = "azsede_cli_id"; }

            if (tableName == "contatti") { ccn = "cont_cli_id"; }
            if (tableName == "utenti") { ccn = "ute_cli_id"; }
            if (tableName == "aziende_clienti_finali") { ccn = "clifin_cli_id"; }

            if (tableName == "termini" || tableName == "gestione_termini") { ccn = "ter_cli_id"; }

            if (tableName == "ruoli_utenti" || tableName == "gestione_ruoli") { ccn = "ruolo_cli_id"; }
            return ccn;
        }

        private string GetFixedWhereConditionByTable(string tableName, string langName)
        {

            List<string> tableNameList = tableName.Split(',').ToList<string>();
            tableName = tableNameList[0];

            string fixedCondition = "";
            if (tableName == "azioni")
            {
                fixedCondition = "tipi_azione_categoria_descr.tpazcatdescr_lingua = '" + langName + "' AND tipi_azione_descr.tpazdescr_lingua = '" + langName + "'" + ") AND(";
            }

            if (tableName == "termini" || tableName == "gestione_termini")
            {
                //fixedCondition = "stati_termine_descr.sterdescr_lingua = '" + langName + "' AND tipi_termine_descr.tipterdescr_lingua = '" + langName + "'" + ") AND(";
                fixedCondition = "";
            }


            if (tableName == "ruoli_utenti" || tableName == "gestione_ruoli")
            {
                fixedCondition = "ruoli_utenti_descr.ruolodescr_lingua = '" + langName + "'" + ") AND(";
                
            }

            return fixedCondition;
        }


        private string returnActualTableName(string pageName)
        {
            string tableName = pageName;
            if (pageName == "visualizza_lista_operazioni")
            {
                tableName = "log_operazioni";
            }
            return tableName;
        }

        private string returnSelectFieldListByPageName(string pageName)
        {
            var fieldNames = "";
            pageName = returnActualTableName(pageName);
            if (pageName == "azioni")
            {
                fieldNames = "azioni.*, tipi_azione_categoria_descr.tpazcatdescr_descrizione,tipi_azione_descr.tpazdescr_descrizione, tipazionecat_descrizione,tpazdescr_tipazione_tipo_azione, az_rag_sociale,contatti.cont_id,contatti.cont_cognome,contatti.cont_nome,richieste.rich_citta,richieste.rich_comp_principale,rich_descrizione,risorse.ris_cognome,risorse.ris_nome,utenti.ute_nome";
            }
            else if (pageName == "log_operazioni")
            {
                fieldNames = " log_operazioni.* ";
            }
            else if (pageName == "termini" || pageName == "gestione_termini")
            {
                fieldNames = " termini.* , sterdescr_descrizione , tipterdescr_descrizione ";
            }

            else if (pageName == "ruoli_utenti" || pageName == "gestione_ruoli")
            {
                fieldNames = " ruoli_utenti.* , ruolodescr_descrizione , ruolodescr_descrizione_breve, ruolodescr_descrizione_estesa, ruolodescr_lingua, ( Select Count(*) As NoOfPermission from talent_ruoli_tipi_abilitazione Where ruoltipab_ruolo = ruoli_utenti.ruolo AND ruoltipab_uteab_abilitato = 'S'and ruoltipab_cli_id = ruoli_utenti.ruolo_cli_id) as NoOfPermission,(SELECT COUNT(DISTINCT(uteab_ute_id)) FROM utenti_abilitazioni LEFT JOIN utenti ON utenti_abilitazioni.uteab_ute_id = utenti.ute_id WHERE utenti.ute_attivo = 'S'and uteab_abilitato = 'S'and uteab_procedura IN (SELECT [ruoltipab_uteab_procedura] FROM [talent_ruoli_tipi_abilitazione] WHERE [ruoltipab_ruolo] = ruoli_utenti.ruolo and [ruoltipab_uteab_abilitato] = 'n'and [ruoltipab_cli_id] = ruoli_utenti.ruolo_cli_id)) As NoOfActiveUser";
            }
            return fieldNames;
        }
    }
}