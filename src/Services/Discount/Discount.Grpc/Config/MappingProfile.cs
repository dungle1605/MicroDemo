using AutoMapper;
using Discount.Grpc.Entities;
using Discount.Grpc.Protos;

namespace Discount.Grpc.Config;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<Coupon, CouponModel>().ReverseMap();
	}
}