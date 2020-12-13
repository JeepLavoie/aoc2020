namespace ShuttleSearch
{
    public record Bus(string Id, int Position)
    {
        public bool IsABus => Id != "x";
        public int BusIdAsInt => Id == "x" ? 0 : int.Parse(Id);
    }
}
