namespace PRM392_Backend.Domain.Exceptions
{
	public abstract class BadRequestException : Exception
	{
		protected BadRequestException(string message) : base(message)
		{
		}
	}
}
