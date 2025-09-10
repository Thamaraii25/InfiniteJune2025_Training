﻿using System.Linq;
using System.Web.Http;
using System.Data.Entity; 
using IKart_ServerSide.Models;
using IKart_Shared.DTOs; 

namespace IKart_ServerSide.Controllers
{
    [RoutePrefix("api/search")]
    public class ProductSearchController : ApiController
    {
        private readonly IKartEntities db = new IKartEntities();

        // GET api/search/products?query=mobile
        [HttpGet]
        [Route("products")]
        public IHttpActionResult SearchProducts(string query = "")
        {
            var products = db.Products.Include(p => p.Stock).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query))
            {
                var lowered = query.ToLower();
                products = products.Where(p =>
                    p.ProductName.ToLower().Contains(lowered) ||
                    p.ProductDetails.ToLower().Contains(lowered) ||
                    p.Stock.CategoryName.ToLower().Contains(lowered) ||
                    p.Stock.SubCategoryName.ToLower().Contains(lowered));
            }

            var result = products
                .Select(p => new ProductDto
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Cost = (decimal)p.Cost,
                    ProductDetails = p.ProductDetails,
                    ProductImage = p.ProductImage,
                    CategoryName = p.Stock.CategoryName,
                    SubCategoryName = p.Stock.SubCategoryName
                })
                .ToList();

            return Ok(result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }
    }
}