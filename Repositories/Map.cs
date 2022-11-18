using AutoMapper;
using JPFigure.Entities;
using JPFigure.Repositories.Data.Inputs;

namespace JPFigure.Repositories
{
	public class Map
	{
		private static Mapper _mapper;

		static Map()
		{
			_mapper = new Mapper(new MapperConfiguration(config =>
			{
				config.CreateMap<FigureInput, Figure>();
				config.CreateMap<Figure, Models.Figure>();

				config.CreateMap<GundamFigureInput, Figure>();
				config.CreateMap<Figure, Models.GundamFigure>();

				config.CreateMap<ScaleFigureInput, Figure>();
				config.CreateMap<Figure, Models.ScaleFigure>();

				config.CreateMap<CharacterInput, Character>();
				config.CreateMap<Character, Models.Character>();

				config.CreateMap<SeriesInput, Series>();
				config.CreateMap<Series, Models.Series>();

				config.CreateMap<ManufactureInput, Manufacture>();
				config.CreateMap<Manufacture, Models.Manufacture>();
			}));
		}

		public static T To<T>(object source) => _mapper.Map<T>(source);

		public static DestT To<SrcT, DestT>(SrcT source, DestT destination) => _mapper.Map(source, destination);

	}
}
