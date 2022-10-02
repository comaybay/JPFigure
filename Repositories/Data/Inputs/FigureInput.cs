using JPFigure.Entities.Enums;

namespace JPFigure.Repositories.Data.Inputs
{
    public class FigureInput
    {
        public int StockCount { get; set; }
        public string ProductName { get; set; } = null!;
        public int CharacterId { get; set; }
        public int ManufactureId { get; set; }
        public int Height { get; set; }
        public DateOnly ReleaseDate { get; set; }
    }
}
