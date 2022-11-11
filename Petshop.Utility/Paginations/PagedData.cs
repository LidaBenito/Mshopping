namespace Petshop.Utility.Paginations
{
    public class PagedData<T>
    {
        public List<T> Data{ get; set; }
        public PageInfo PageInfo{ get; set; }
    }
}
