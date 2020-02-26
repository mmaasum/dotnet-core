using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Talent.BLL.DTO;
using Talent.DataModel.DataModels;
using Talent.DataModel.Models;

namespace Talent.BLL.Repositories
{
    public interface IGlobalGridManager
    {
        Task<IEnumerable<GridFiltriMaster>> FindByGridFiltriMasterDataAsync(GlobalGridPostDto gridPostDto);

        Task<string> InsertGridSearchesDataAsync(GlobalGridMasterDto gridMasterDto);
        Task<string> UpdateGridSearchesDataAsync(GlobalGridMasterDto gridMasterDto);
        Task<string> DeleteGridSearchesDataAsync(string searchName, string cliId);

        Task<GridFiltriMaster> FindByGridMasterDataAsync(string searchName, string clientId);

        Task<ReturnSearchDataDto> FindFilteredDataAsync(string tableName, string clientId, int pageIndex, int pageSize,
            FilterSortingDto filterSortingDto);

        Task<int> FindTotalRecordsAsync(string tableName, string clientId, FilterSortingDto filterSortingDto);

        Task<string> SortingSavedFilterDataAsync(List<SavedFilterSortingDto> savedFilterSortingDto);


        Task<IEnumerable<GenericSearchedDataDto>> GetGenericSearchedDataAsync(string searchedData, string moduleName, string clientId);

        Task<IEnumerable<string>> GetDynamicGroupButtonAsync(string tableName, string clientId, int pageNumber, int pageSize, FilterSortingDto filterSortingDto);

        Task<IEnumerable<MasterFilterFieldsDto>> GetFieldsByPageDataAsync(string pageName, string langName, string fieldType);

        Task<MasterFilterDto> GetMasterFilterDetailsByIdAsync(int filterId);
        Task<IEnumerable<MasterFilterDto>> GetMasterFilterListByUserAsync(string uteId, string pageName);

        Task<IEnumerable<MasterFilterCustomDto>> GetFilterListByUtentiDataAsync(ClaimsPrincipal User, string uteId, string pageName, string langName);


        Task<long> InsertMasterFilterDataAsync(MasterFilterDto masterFilterDto);
        Task<long> UpdateMasterFilterDataAsync(MasterFilterDto updatedMasterFilterDto, ClaimsPrincipal User);
        Task<long> DeleteMasterFilterDataAsync(int filterId);


        Task<ReturnSearchDataDto> GetMasterFilterAppliedDataAsync(int filterId, int pageSize, int pageIndex, bool forCount, FilterSortingDto filterSortingDto, string langName);
        Task<ReturnSearchDataDto> GetMasterFilterAppliedDataByObjAsync(MasterFilterDto masterFilterDto, int pageSize, int pageIndex, bool forCount, FilterSortingDto filterSortingDto, string langName);


        Task<MasterFilterCustomDto> GetMasterFilterUtentiDetailsByUtentiAsync(int filterId, string uteId);
        Task<int> CountMasterFilterUtentiByFilterIdAsync(int filterId);


        Task<IEnumerable<TalentFontNameDto>> GetAllFontListDataAsync();
        Task<IEnumerable<TalentFontSizeDto>> GetAllFontSizeListDataAsync();

        Task<IEnumerable<TalentGridFieldsUser>> GetGridFieldsDescrByPageBllAsync(string gridName, string langName);


        Task<TalentGridUser> GetTalentGridUserDetailsByUteInfoDataAsync(string uteId, string cliId, string gridName);
        Task<TalentGridFieldsUser> GetTalentGridFieldsUserDetailsDataAsync(string uteId, string cliId, string fieldName);


        Task<IEnumerable<TalentGridFieldsUser>> GetTalentGridFieldsUserListDataAsync(string uteId, string cliId);
        Task<TalentGridUserWIthFieldsDto> GetTalentGridUserDetailsWithFieldsDataAsync(string uteId, string cliId, string gridName, string langName);

        Task<int> InsertTalentGridFieldUserAsync(TalentGridFieldsUser talentGridFieldsUserDto);
        Task<int> UpdateTalentGridFieldUserDataAsync(TalentGridFieldsUser talentGridFieldsUserDto);

        Task<int> ManageTalentGridUserWithFieldsAsync(TalentGridUserWIthFieldsDto talentGridUserWIthFieldsDto);

        Task<int> DeleteAllCustomGridSettingByUserDataAsync(string uteId, string clientId, string gridName);

    }
}