using AutoMapper;

namespace AdvanceProject.Bll.Mapper
{
	public class MyMapper
	{
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
                //cfg.CreateMap<TSource, TDestination>().ReverseMap();           
            });

            var mapper = config.CreateMapper();

            return mapper.Map<TSource, TDestination>(source);
        }
    }
}
