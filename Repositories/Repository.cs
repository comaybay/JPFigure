namespace JPFigure.Repositories
{
	public abstract class Repository
	{
		protected JPFigureContext Context { get; private set; }

		protected Repository(JPFigureContext context)
		{
			Context = context;
		}
	}
}
