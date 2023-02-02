namespace Petshop.Utility.MediatRHelper.Results;

public static class ResultExtensions
{

	public static bool IsEmpty<T>(this IEnumerable<T> ts)
	{
		if (ts == null || !ts.Any())
		{
			return true;
		}
		return false;
	}
	public static bool IsNotEmpty<T>(this IEnumerable<T> ts)
	{
		if (ts == null)
		{
			return false;
		}
		if (ts != null && ts.Any())
		{
			return true;
		}
		return false;
	}






	public static bool IsNull(this object obj) => obj == null;
	public static bool IsNotNull(this object obj) => obj != null;




	public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);


	public static bool IsNullOrWhiteSpace(this string str) => string.IsNullOrWhiteSpace(str);


	public static bool IsNotNullOrEmpty(this string str) => !string.IsNullOrEmpty(str);


	public static bool IsNotNullOrWhiteSpace(this string str) => !string.IsNullOrWhiteSpace(str);
}
