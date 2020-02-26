using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Talent.DataModel.Models;

namespace Talent.BLL.DTO
{
    public class GlobalGridPostDto
    {
        public string TableName { get; set; }
        public string CliId { get; set; }
        public string UteId { get; set; }
        public bool AccessLevel { get; set; }
    }


    public class GlobalGridMasterDto
    {
        public string SearchName { get; set; }
        public string SearchDesciption { get; set; }
        public bool AccessLevel { get; set; }
        public string UteId { get; set; }

        public string TableName { get; set; }
        public string PageURL { get; set; }
        public string CliId { get; set; }


        public DateTime InsTimestamp { get; set; }
        public DateTime ModTimestamp { get; set; }

        public string FilterData { get; set; }
        public string SortingData { get; set; }



       


        public GridFiltriMaster MapDtoToGridFiltriMaster(GlobalGridMasterDto grilMasterDto, GridFiltriMaster gridMaster)
        {
           
            gridMaster.GridfilmaNome = grilMasterDto.SearchName;
            gridMaster.GridfilmaDescrizione = grilMasterDto.SearchDesciption;
            gridMaster.GridfilmaAccessLevel = grilMasterDto.AccessLevel;
            gridMaster.GridfilmaUteId = grilMasterDto.UteId;
            gridMaster.GridfilmaGridtabNome = grilMasterDto.TableName;
            gridMaster.GridfilmaPageUrl = grilMasterDto.PageURL;
            gridMaster.GridfilmaFiltroDefault = grilMasterDto.AccessLevel;

            //gridMaster.GridfilmaInsTimestamp = grilMasterDto.InsTimestamp;
            gridMaster.GridfilmaInsUteId = grilMasterDto.UteId; // this is willingly set as ute_ins_id
            //gridMaster.GridfilmaModTimestamp = grilMasterDto.ModTimestamp;
            gridMaster.GridfilmaModUteId = grilMasterDto.UteId; // this is willingly set as ute_ins_id

            gridMaster.GridfilmaCliId = grilMasterDto.CliId;


            gridMaster.GridfilmaFilterString = grilMasterDto.FilterData;
            gridMaster.GridfilmaSortingString = grilMasterDto.SortingData;

            return gridMaster;
        }

        public GridFiltriMaster MapForInsert(GlobalGridMasterDto grilMasterDto)
        {
            GridFiltriMaster gridMaster = new GridFiltriMaster();
            return MapDtoToGridFiltriMaster(grilMasterDto, gridMaster);
        }

        public GridFiltriMaster MapForUpdate(GlobalGridMasterDto grilMasterDto, GridFiltriMaster gridMaster)
        {
            return MapDtoToGridFiltriMaster(grilMasterDto, gridMaster);
        }


    }



    public class GlobalGridDetailsDto
    {
        public string FieldName { get; set; }
        public string FieldSearchedCritetia { get; set; }
        public string OrderBy { get; set; }
    }


    public class SavedFilterSortingDto
    {
        public string SearchName { get; set; }
        public string CliId { get; set; }
        public int FilterOrder { get; set; }
    }



}
