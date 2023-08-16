using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyEventt.Services
{
    public class ProductService : IProduct
    {
        protected readonly FamilyEventContext context;
        public ProductService(FamilyEventContext context)
        {
            this.context = context;
        }   
        public async Task<bool> DeleteProduct(List<string> id)
        {
            try
            {
                List<Product> products = await this.context.Product
                    .Where(x => id.Contains(x.ProductId))
                    .ToListAsync();
                if (products != null && products.Count > 0)
                {

                    for (int i = 0; i < products.Count; i++)
                    {
                        products[i].Status = false;
                    }
                    await this.context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    throw new ArgumentException("No Product found");
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Process went wrong");
            }
        }

        public async Task<List<ProductDto>> FilterProductByManyOption(string? name, decimal? minPrice, decimal? maxPrice, string? supplier, int? qty, bool? qtyOption = true)
        {
            try
            {
                if (name == null) name = "";
                name = DataHelper.RemoveUnicode(name).ToLower();
                
                var data = await this.context.Product
                   // .Where(x => name == null || x.DecorationProductName.Contains(name))
                    .Where(x => minPrice == null || x.ProductPrice >= minPrice)
                    .Where(x => maxPrice == null || x.ProductPrice <= maxPrice)
                    //.Where(x => string.IsNullOrEmpty(supplier) || DataHelper.RemoveUnicode(x.ProductSupplier.ToLower()).Contains(supplier))
                    .Where(x => qty == null ? true: x.ProductQuantity == qty)
                    .Where(x => x.Status == qtyOption)
                    .ToListAsync();
                data = data.Where(x => name == null ? true: DataHelper.RemoveUnicode(x.DecorationProductName).ToLower().Contains(name)).ToList();
                data = data.Where(x => supplier == null?true: DataHelper.RemoveUnicode(x.ProductSupplier).ToLower().Contains(supplier)).ToList();
                
                    var products = data.Select(x => new ProductDto
                    {
                        ProductId = x.ProductId,
                        DecorationProductName = x.DecorationProductName,
                        ProductQuantity = x.ProductQuantity,
                        ProductDetails = x.ProductDetails,
                        ProductImage = x.ProductImage,
                        ProductPrice = x.ProductPrice,
                        ProductSupplier = x.ProductSupplier,
                        Status = x.Status,
                    }).ToList();
                return products;
                
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Process went wrong");
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            try
            {
                var data = await this.context.Product.Where(x => x.Status)
                    .OrderBy(x => x.DecorationProductName)
                    .Select(x => new Product
                    {
                        ProductId = x.ProductId,
                        DecorationProductName = x.DecorationProductName,
                        ProductDetails = x.ProductDetails,
                        Status = x.Status,
                        ProductImage = x.ProductImage,
                        ProductPrice = x.ProductPrice,
                        ProductQuantity = x.ProductQuantity,
                        ProductSupplier = x.ProductSupplier,
                    })
                    .ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<bool> InsertProduct(ProductDto iProduct)
        {
            try
            {
                var _product = new Product();
                _product.ProductId = "PId" + Guid.NewGuid().ToString().Substring(0,20);
                _product.Status = iProduct.Status;
                _product.DecorationProductName = iProduct.DecorationProductName;
                _product.ProductPrice = iProduct.ProductPrice;
                _product.ProductQuantity = iProduct.ProductQuantity;
                _product.ProductDetails = iProduct.ProductDetails;
                _product.ProductImage = iProduct.ProductImage;
                _product.ProductSupplier = iProduct.ProductSupplier;
                _product.Status = iProduct.Status;
                await this.context.Product.AddAsync(_product);
                this.context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Process went wrong");
            }

        }

        public async Task<List<ProductDto>> SearchByNameProducts(string name)
        {
            try
            {
                var data = await this.context.Product.Where(x => x.Status && x.DecorationProductName.Contains(name)).
                    Select(x => new ProductDto
                    {
                        ProductDetails = x.ProductDetails,
                        ProductId = x.ProductId,
                        ProductImage = x.ProductImage,
                        DecorationProductName = x.DecorationProductName,
                        ProductPrice = x.ProductPrice,
                        ProductQuantity = x.ProductQuantity,
                        ProductSupplier = x.ProductSupplier,
                        Status = x.Status,
                    }).ToListAsync();
                if (data.Count > 0 && data != null)
                    return data;
                else throw new ArgumentException();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Process went wrong");
            }
        }

        public async Task<bool> UpdateProduct(ProductDto upProduct)
        {
            try
            {
                Product product = await this.context.Product.FirstAsync(x => x.ProductId == upProduct.ProductId);
                if (product != null)
                {
                    product.DecorationProductName = upProduct.DecorationProductName;
                    product.ProductPrice = upProduct.ProductPrice;
                    product.ProductQuantity = upProduct.ProductQuantity;
                    product.ProductDetails = upProduct.ProductDetails;
                    product.ProductImage = upProduct.ProductImage;
                    product.ProductSupplier = upProduct.ProductSupplier;
                    product.Status = upProduct.Status;
                    this.context.SaveChanges();
                    return true;

                }
                else
                {
                    throw new ArgumentException("Product not found");
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Process went wrong");
            }
        }

        public async Task<List<ProductDto>> SearchByIDProducts(string id)
        {
            try
            {
                var data = await this.context.Product.Where(x => x.Status && x.ProductId.Equals(id)).
                    Select(x => new ProductDto
                    {
                        ProductDetails = x.ProductDetails,
                        ProductId = x.ProductId,
                        ProductImage = x.ProductImage,
                        DecorationProductName = x.DecorationProductName,
                        ProductPrice = x.ProductPrice,
                        ProductQuantity = x.ProductQuantity,
                        ProductSupplier = x.ProductSupplier,
                        Status = x.Status,
                    }).ToListAsync();
                if (data.Count > 0 && data != null)
                    return data;
                else throw new ArgumentException();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Process went wrong");
            }
        }
    }
}
