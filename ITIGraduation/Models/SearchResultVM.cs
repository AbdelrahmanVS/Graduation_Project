namespace ITIGraduation.Models;

public class SearchResultVM
{
    public IEnumerable<Prouduct>? Products { get; set; }
    public IEnumerable<Sport>? Sports { get; set; } 
    public IEnumerable<Boot>? Boots { get; set; } 
    public IEnumerable<TrendingSelling>? TrendingSellings { get; set; } 
    public IEnumerable<Oxford>? Oxfords { get; set; } 
}
