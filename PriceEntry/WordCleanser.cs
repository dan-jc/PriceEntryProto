namespace PriceEntry;

public interface IWordCleanser
{
    string CleanseWord(string word);
}

public class WordCleanser : IWordCleanser
{
    public string CleanseWord(string word) => word.ToUpper();
}