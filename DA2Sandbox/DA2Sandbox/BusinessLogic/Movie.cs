namespace MoviesApi.BusinessLogic
{
    public class Movie
    {
        public Guid GUID { get; set; }
        public string Title { get; set; }
        public IEnumerable<string> Genres { get; set; }

        public Movie(string title, IEnumerable<string> genres)
        {
            GUID = Guid.NewGuid();
            Title = title;
            Genres = genres;
        }
    }
}
