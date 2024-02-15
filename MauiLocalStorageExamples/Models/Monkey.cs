namespace MauiLocalStorageExamples.Models
{
    public class Monkey
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public string ImageUrl { get; set; }
        public bool IsFavorite { get; set; }
    }

    public class MonkeyRootobject
    {
        public List<Monkey> Monkeys { get; set; }
    }
}
