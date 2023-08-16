using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyEventt.Services
{
    public class DecorationProductService : IDecorationProduct
    {
        protected readonly FamilyEventContext context;
        public DecorationProductService(FamilyEventContext context)
        {
            this.context = context;
        }
        public async Task<bool> AddDecorationProduct(DecorationProductDto decorationProduct)
        {
            try
            {
                var existedObject = await this.context.DecorationProduct
                    .FirstOrDefaultAsync(x => x.ProductId == decorationProduct.ProductId
                            && x.DecorationId== decorationProduct.DecorationId);
                if ( existedObject != null)
                    return false;

                DecorationProduct newDecorationProduct = new DecorationProduct();
                //newDecorationProduct.ProductId = "DPId" + Guid.NewGuid().ToString().Substring(0, 19);
                //newDecorationProduct.DecorationId = "DecordId" + Guid.NewGuid().ToString().Substring(0, 15);
                newDecorationProduct.ProductId = decorationProduct.ProductId;
                newDecorationProduct.DecorationId = decorationProduct.DecorationId;
                newDecorationProduct.Quantity = decorationProduct.Quantity;
                newDecorationProduct.Price = decorationProduct.Price;

                await this.context.DecorationProduct.AddAsync(newDecorationProduct);
                await this.context.SaveChangesAsync();

                var decopro = await this.context.DecorationProduct.Where(x=>x.DecorationId.Equals(newDecorationProduct.DecorationId)).ToListAsync();
                var deco = await this.context.Decoration.Where(x=>x.DecorationId.Equals(newDecorationProduct.DecorationId)).FirstOrDefaultAsync();
                decimal tmp = 0;
                foreach(var item in decopro)
                {
                    tmp += item.Price*item.Quantity;
                }
                deco.DecorationPrice = tmp;

                await this.context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Process went wrong");
            }
        }

        public async Task<bool> DeleteDecorationProductById(List<string> decorationProductId)
        {
            try
            {
                var decorationProducts = await this.context.DecorationProduct
                    .Where(x => decorationProductId.Contains(x.DecorationId)).ToListAsync();
               if (decorationProducts != null && decorationProducts.Count() >= 1)
              {
                    this.context.RemoveRange(decorationProducts);
                    await this.context.SaveChangesAsync();
                }
                else return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            throw new NotImplementedException();
        }

        public async Task<List<DecorationProductDto>> FilterDecorationProducts(string? decorationId, string? productId, decimal? minPrice, decimal? maxPrice, int? quantity, bool? quantityOption = true)
        {
            try
            {
                var data = await this.context.DecorationProduct
                    .Where(x => decorationId == null || x.DecorationId == decorationId)
                    .Where(x => productId == null || x.ProductId == productId)
                    .Where(x => minPrice == null || x.Price >= minPrice)
                    .Where(x => maxPrice == null || x.Price <= maxPrice)
                    .Where(x => quantity == null || (quantityOption == true ? x.Quantity >= quantity : x.Quantity <= quantity))
                    .Select(x => new DecorationProductDto
                    {
                        DecorationId = x.DecorationId,
                        ProductId = x.DecorationId,
                        Price = x.Price,
                        Quantity = x.Quantity,
                        Decoration = new DecorationDto
                        {
                            DecorationId = x.Decoration.DecorationId,
                            DecorationName = x.Decoration.DecorationName,
                            DecorationPrice = x.Decoration.DecorationPrice,
                            DecorationImage = x.Decoration.DecorationImage,
                        },
                        Product = new ProductDto
                        {
                            ProductId = x.Product.ProductId,
                            DecorationProductName= x.Product.DecorationProductName,
                            ProductPrice= x.Product.ProductPrice,
                            ProductQuantity= x.Product.ProductQuantity,
                            ProductDetails= x.Product.ProductDetails,
                            ProductImage= x.Product.ProductImage,
                            ProductSupplier= x.Product.ProductSupplier,
                            Status= x.Product.Status,
                            
                        }
                    }).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Process went wrong");
            }
        }

        public async Task<List<DecorationProductDto>> GetAllDecorationProduct()
        {
            try
            {
                var decorationProduct = await this.context.DecorationProduct.Select(x => new DecorationProductDto
                {
                    DecorationId = x.DecorationId,
                    ProductId = x.ProductId,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    Decoration = new DecorationDto
                    {
                        DecorationId = x.Decoration.DecorationId,
                        DecorationName = x.Decoration.DecorationName,
                        DecorationPrice = x.Decoration.DecorationPrice,
                        DecorationImage = x.Decoration.DecorationImage,
                    },
                    Product = new ProductDto
                    {
                        ProductId = x.Product.ProductId,
                        DecorationProductName = x.Product.DecorationProductName,
                        ProductImage = x.Product.ProductImage,
                        ProductDetails = x.Product.ProductDetails,
                        ProductPrice = x.Product.ProductPrice,
                        ProductQuantity = x.Product.ProductQuantity,
                        ProductSupplier = x.Product.ProductSupplier,
                        Status= x.Product.Status,
                    },
                }).ToListAsync();
                return decorationProduct;

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Process went wrong");
            }
        }

        public async Task<List<DecorationProduct>> GetDecorationProductById(string? decorationId, string? productId)
        {
            try
            {
                 var data = await this.context.DecorationProduct
                    .Where(x => decorationId == null || x.DecorationId == decorationId)
                    .Where(x => productId == null || x.ProductId == productId)
                    .Select(x => new DecorationProduct
                    {
                        DecorationId = x.DecorationId,
                        ProductId = x.ProductId,
                        Price = x.Price,
                        Quantity = x.Quantity,
                        Decoration = new Decoration
                        {
                            DecorationId = x.Decoration.DecorationId,
                            DecorationName = x.Decoration.DecorationName,
                            DecorationPrice = x.Decoration.DecorationPrice,
                            DecorationImage = x.Decoration.DecorationImage,
                        },
                        Product = new Product
                        {
                            ProductId = x.Product.ProductId,
                            DecorationProductName = x.Product.DecorationProductName,
                            ProductImage = x.Product.ProductImage,
                            ProductDetails = x.Product.ProductDetails,
                            ProductPrice = x.Product.ProductPrice,
                            ProductQuantity = x.Product.ProductQuantity,
                            ProductSupplier = x.Product.ProductSupplier,
                            Status= x.Product.Status,
                        },
                    }).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Process went wrong");
            }
        }

        public async Task<bool> UpdateDecorationProduct(DecorationProductDto decorationProduct)
        {
            try
            {
                var existData = await this.context.DecorationProduct
                    .FirstAsync(x => x.ProductId == decorationProduct.ProductId
                                    && x.DecorationId == decorationProduct.DecorationId);
                if (existData == null)
                {
                    throw new ArgumentException("DecorationProductId not found");
                }
                existData.ProductId = decorationProduct.ProductId;
                existData.DecorationId = decorationProduct.DecorationId;
                existData.Price = decorationProduct.Price;
                existData.Quantity = decorationProduct.Quantity;

                var decopro = await this.context.DecorationProduct.Where(x => x.DecorationId.Equals(existData.DecorationId)).ToListAsync();
                var deco = await this.context.Decoration.Where(x => x.DecorationId.Equals(existData.DecorationId)).FirstOrDefaultAsync();
                decimal tmp = 0;
                foreach (var item in decopro)
                {
                    tmp += item.Price * item.Quantity;
                }
                deco.DecorationPrice = tmp;

                await this.context.SaveChangesAsync();
                await this.context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("This DecorationPorduct doesn't exist or Process went wrong");
            }
        }

        public async Task<bool> UpdateProduct(DecoProductUpdate decorationProduct)
        {
            try
            {
                var existData = await this.context.DecorationProduct.Where(x => x.ProductId.Equals(decorationProduct.OldProductId)
                && x.DecorationId.Equals(decorationProduct.DecorationId)).FirstOrDefaultAsync();
                if (existData == null)
                {
                    throw new ArgumentException("DecorationProductId not found");
                }
                this.context.DecorationProduct.Remove(existData);
                await this.context.SaveChangesAsync();

                existData.ProductId = decorationProduct.newProductId;
                existData.DecorationId = decorationProduct.DecorationId;
                existData.Price = decorationProduct.Price;
                existData.Quantity = decorationProduct.Quantity;
                
                this.context.DecorationProduct.AddAsync(existData);
                await this.context.SaveChangesAsync();

                var decopro = await this.context.DecorationProduct.Where(x => x.DecorationId.Equals(existData.DecorationId)).ToListAsync();
                var deco = await this.context.Decoration.Where(x => x.DecorationId.Equals(existData.DecorationId)).FirstOrDefaultAsync();
                decimal tmp = 0;
                foreach (var item in decopro)
                {
                    tmp += item.Price * item.Quantity;
                }
                deco.DecorationPrice = tmp;

                
                await this.context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("This DecorationPorduct doesn't exist or Process went wrong");
            }
        }
    }
}
