namespace PRM392_Backend.Domain.Exceptions
{
	public class StoreLocationNotFoundException : NotFoundException
	{
		public StoreLocationNotFoundException(Guid storeLocationId) : base($"The store location with id: {storeLocationId} doesn't exist in the database")
		{
		}
	}
}
