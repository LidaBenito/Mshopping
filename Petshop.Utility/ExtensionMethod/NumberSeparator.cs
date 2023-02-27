namespace Petshop.Utility.ExtensionMethod;
public static class NumberSeparator
{
	public static string SeparatorNum(this int value)
	{
		var result = value.ToString("N0");
		return result;
	}
}