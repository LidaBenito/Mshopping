namespace Petshop.Utility.Paginations;

public class PageInfo
{
	private int pageSize = 10;
	public int TotalCount { get; set; }
	const int maxPageSize = 20;
	public int PageNumber { get; set; } = 1;
	public int PageSize
	{
		get
		{
			return pageSize;
		}
		set
		{
			pageSize = (value > maxPageSize) ? maxPageSize : value;
		}
	}
	public int PageCount => (int)Math.Ceiling((double)TotalCount / pageSize);

}
