namespace ITIGraduation.Models
{
    public class BestAndTrend
    {        
        public BestAndTrend(List<TrendingSelling> trends, List<Prouduct> products)
        {
            this.trends = trends;
            this.products = products;
        }

        public List<TrendingSelling> trends;
        public List<Prouduct> products;
    }
}
