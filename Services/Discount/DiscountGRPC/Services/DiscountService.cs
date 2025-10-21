using DiscountGRPC.Data;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Mapster;
using DiscountGRPC.Models;

namespace DiscountGRPC.Services
{
    public class DiscountService (DiscountContext dbContext, ILogger<DiscountService> logger) : DiscountProtoService.DiscountProtoServiceBase
    {
        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await dbContext.Coupons.FirstOrDefaultAsync(c => c.ProductName == request.ProductName);
            if (coupon is null) {
                coupon = new Models.Coupon
                {
                    ProductName = "No Discount",
                    Amount = 0,
                    Description = "No Discount",
                };
            }

            logger.LogInformation("Discount is retrieved for ProductName : {ProductName}, Amount : {Amount}", coupon.ProductName, coupon.Amount);

            var couponModel = coupon.Adapt<CouponModel>();
            return couponModel;
        }
        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();
            if (coupon is null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request data"));
            }

            dbContext.Coupons.Add(coupon);
            await dbContext.SaveChangesAsync();

            logger.LogInformation("Discount is successfully created. ProductName : {ProductName}", coupon.ProductName);

            var couponModel = coupon.Adapt<CouponModel>();
            return couponModel;
        }
        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();
            if (coupon is null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request data"));
            }
            dbContext.Coupons.Update(coupon);
            await dbContext.SaveChangesAsync();

            logger.LogInformation("Discount is successfully update. ProductName : {ProductName}", coupon.ProductName);

            var couponModel = coupon.Adapt<CouponModel>();
            return couponModel;
        }
        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var coupon = await dbContext.Coupons.FirstOrDefaultAsync(c => c.Id == request.Id);
            if (coupon is null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount with Id={request.Id} is not found."));
            }

            dbContext.Coupons.Remove(coupon);
            var deleted = await dbContext.SaveChangesAsync();

            logger.LogInformation("Discount is deleted successfully. Id : {Id}", request.Id);

            return new DeleteDiscountResponse { Success = true };
        }
    }
}
