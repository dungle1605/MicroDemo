using AutoMapper;

namespace Discount.Grpc.Config;

public class MappingProfileConfig<T, TResult> : Profile
{
    public MappingProfileConfig()
    {
        CreateMap<T, TResult>().ReverseMap();
    }
}