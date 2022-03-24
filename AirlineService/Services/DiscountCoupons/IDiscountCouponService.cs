using AirlineService.Models.DbModels;
using System;
using System.Collections.Generic;

namespace AirlineService.Services.DiscountCoupons
{
    public interface IDiscountCouponService
    {
        DiscountCoupon AddCoupon(DiscountCoupon discountCoupon);

        DiscountCoupon GetByCode(string code);

        DiscountCoupon GetById(Guid id);

        List<DiscountCoupon> GetAll();

        DiscountCoupon Update(DiscountCoupon discountCoupon);

        void Delete(Guid id);
    }
}
