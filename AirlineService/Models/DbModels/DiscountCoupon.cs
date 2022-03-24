using System;

namespace AirlineService.Models.DbModels
{
    public class DiscountCoupon
    {
        public Guid Id { get; set; }

        public string CouponCode { get; set; }

        public DateTime ValidUpto { get; set; }

        public int DiscountPercent { get; set; }
    }
}
