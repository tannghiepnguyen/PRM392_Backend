using Microsoft.AspNetCore.Http;

namespace PRM392_Backend.Service.IService
{
	public interface IBlobService
	{
		Task<string> GetBlob(string blobName, string containerName);
		Task<bool> DeleteBlob(string blobName, string containerName);
		Task<string> UploadBlob(string blobName, string containerName, IFormFile file);
	}
}
