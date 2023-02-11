namespace Petshop.Endpoint.Controllers;

public class BaseController : Controller
{
	protected IActionResult JsonSuccess()
	{

		return Json(JsonData.Success());
	}
	protected IActionResult JsonSuccess(object data)
	{

		return Json(JsonData.Success(data));
	}
	protected IActionResult JsonFail()
	{

		return Json(JsonData.Fail());
	}
	protected IActionResult JsonFail(string Msg)
	{

		return Json(JsonData.Fail(Msg));
	}



}
public class JsonData
{
	public static JsonData Success()
	{
		return new JsonData
		{
			Message = "عملیات با موفقیت انجام شد.",
			Status = true
		};
	}
	public static JsonData Success(object data)
	{
		return new JsonData
		{
			Data = data,
			Message = "عملیات با موفقیت انجام شد.",
			Status = true
		};
	}

	public static JsonData Fail()
	{
		return new JsonData
		{
			Message = "عملیات با خطا مواجه شد.",
			Status = false
		};
	}
	public static JsonData Fail(string Msg)
	{
		return new JsonData
		{
			Message = Msg,

			Status = false
		};
	}

	public bool Status { get; set; }


	public object Data { get; set; }
	public string Message { get; set; }
}

