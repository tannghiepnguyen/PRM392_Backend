using AutoMapper;
using PRM392_Backend.Domain.Constant;
using PRM392_Backend.Domain.Exceptions;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Domain.Repository;
using PRM392_Backend.Service.IService;
using PRM392_Backend.Service.Products.DTO;

namespace PRM392_Backend.Service.Products
{
	internal sealed class ProductService : IProductService
	{
		private readonly IRepositoryManager repositoryManager;
		private readonly IMapper mapper;
		private readonly IBlobService blobService;

		public ProductService(IRepositoryManager repositoryManager, IMapper mapper, IBlobService blobService)
		{
			this.repositoryManager = repositoryManager;
			this.mapper = mapper;
			this.blobService = blobService;
		}

		private async Task CheckIfCategoryExists(Guid categoryId)
		{
			var category = await repositoryManager.CategoryRepository.GetCategoryById(categoryId, false);
			if (category == null) throw new CategoryNotFoundException(categoryId);
		}

		public async Task<ProductForReturnDto> CreateProduct(ProductForCreationDto productForCreationDto)
		{
			string filename = $"{Guid.NewGuid()}{Path.GetExtension(productForCreationDto.File.FileName)}";

			var product = mapper.Map<Product>(productForCreationDto);
			product.ID = Guid.NewGuid();
			product.IsActive = true;
			product.ImageURL = await blobService.UploadBlob(filename, StorageContainer.STORAGE_CONTAINER, productForCreationDto.File);

			repositoryManager.ProductRepository.CreateProduct(product);
			await repositoryManager.Save();

			return mapper.Map<ProductForReturnDto>(product);
		}

		public async Task<IEnumerable<ProductForReturnDto>> GetActiveProducts(bool trackChange)
		{
			var activeProducts = await repositoryManager.ProductRepository.GetActiveProducts(trackChange);
			return mapper.Map<IEnumerable<ProductForReturnDto>>(activeProducts);
		}

		public async Task<IEnumerable<ProductForReturnDto>> GetAllProducts(bool trackChange)
		{
			var products = await repositoryManager.ProductRepository.GetProducts(trackChange);
			return mapper.Map<IEnumerable<ProductForReturnDto>>(products);
		}

		public async Task<ProductForReturnDto?> GetProduct(Guid id, bool trackChange)
		{
			var product = await repositoryManager.ProductRepository.GetProductById(id, trackChange);
			if (product == null) throw new ProductNotFoundException(id);

			return mapper.Map<ProductForReturnDto>(product);
		}

		public async Task<IEnumerable<ProductForReturnDto>> GetProductsByCategory(Guid categoryId, bool trackChange)
		{
			await CheckIfCategoryExists(categoryId);

			var products = await repositoryManager.ProductRepository.GetProductsByCategory(categoryId, trackChange);
			return mapper.Map<IEnumerable<ProductForReturnDto>>(products);
		}

		public async Task UpdateProduct(Guid id, ProductForUpdateDto productForUpdateDto, bool trackChange)
		{
			var product = await repositoryManager.ProductRepository.GetProductById(id, trackChange);
			if (product == null) throw new ProductNotFoundException(id);
			mapper.Map(productForUpdateDto, product);

			if (productForUpdateDto.File is not null && productForUpdateDto.File.Length > 0)
			{
				await blobService.DeleteBlob(product.ImageURL.Split('/').Last(), StorageContainer.STORAGE_CONTAINER);
				string filename = $"{Guid.NewGuid()}{Path.GetExtension(productForUpdateDto.File.FileName)}";
				product.ImageURL = await blobService.UploadBlob(filename, StorageContainer.STORAGE_CONTAINER, productForUpdateDto.File);
			}

			await repositoryManager.Save();

		}
	}
}
