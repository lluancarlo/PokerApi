namespace PokerApi.Model.Dto.Financial
{
    public class FinancialPutDto
    {
        public int PlayerId { get; set; }
        public int PlaceId { get; set; }
        public float Balance { get; set; }
    }
}
