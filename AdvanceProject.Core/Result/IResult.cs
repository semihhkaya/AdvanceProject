namespace AdvanceProject.Core.Result
{
	public interface IResult
	{
		//Consructor'da bu interface'i kullanan classlara yollayacağım 
		//Immutability 
		bool Success { get; } //True-False
		string Message { get; } //True-False olma durumuna göre kullanıcıyı bilgilendiren mesaj içerikleri
	}
}
