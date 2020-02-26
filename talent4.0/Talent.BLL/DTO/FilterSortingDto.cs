namespace Talent.BLL.DTO
{
    public class FilterSortingDto
    {
        public FilterDto[] Filters { get; set; }
        public SortingDto Sorting { get; set; }
        public string ClientColumn { get; set; }
        //public string DefaultSortingColumn { get; set; }
        public JoinTableQueryDto JoinTableQueryDto { get; set; }
    }

    public class JoinTableQueryDto
    {
        public JoinTableDto[] JoinTable { get; set; }
        public string[] JoinTableRetreivedFields { get; set; }
    }

    public class JoinTableDto
    {
        public string JoinTableName { get; set; }
        public JoinTableFieldDto[] JoinFields { get; set; }
    }

    public class JoinTableFieldDto
    {
        public string BaseTableJoinFieldName { get; set; }
        public string JoinTableJoinFieldName { get; set; }
    }
}
