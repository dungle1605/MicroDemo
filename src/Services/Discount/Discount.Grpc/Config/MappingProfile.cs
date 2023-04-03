using AutoMapper;

namespace Discount.Grpc.Config;

public class MappingProfile<T, TResult> where T : class
{
    public MappingProfile() { }

    public TResult MapperHandler(T originalData)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MappingProfileConfig<T, TResult>());
        });

        var mapper = config.CreateMapper();

        var result = mapper.Map<T, TResult>(originalData);

        return result;
    }
}