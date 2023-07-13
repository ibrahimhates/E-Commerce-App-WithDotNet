
namespace Entity.RequestFeatures
{
    public abstract class PaginationParams
    {
        const int maxPageNumber = 50;

        private int _pageSize;
        public int PageNumber { get; set; } = 1;
        public int PageSize 
        { 
            get { return _pageSize; } 
            set { _pageSize = value < maxPageNumber ? value : maxPageNumber; } 
        }
        public String? OrderBy { get; set; }
    }
}
