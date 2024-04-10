namespace Shared.Model
{
    public class PagingParameter
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public PagingParameter()
        {
            
        }

        public PagingParameter(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public override string ToString()
        {
            return string.Format("&{0}={1}&{2}={3}",nameof(Page),Page,nameof(PageSize),PageSize);
        }
    }
}
