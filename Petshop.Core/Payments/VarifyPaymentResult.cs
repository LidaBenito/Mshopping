namespace Petshop.Core.Payments;

public class VarifyPaymentResult
{
	public int Status { get; set; }
	public bool IsCorrect => Status == 1;
	public string Amount{ get; set; }
	public string TransId{ get; set; }
	public string FactorNumber{ get; set; }
	public string Mobile{ get; set; }
	public string Description{ get; set; }
	public string CardNumber{ get; set; }
	public string Message{ get; set; }
}
