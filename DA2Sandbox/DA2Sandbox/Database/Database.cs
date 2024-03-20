using MoviesApi.BusinessLogic;

namespace DA2Sandbox.Database
{
    public class Database
    {
        public List<Movie> Movies { get; set; }

        public Database()
        {
            Movies = new List<Movie>();
            Movies.Add(new Movie("Shrek 2", new List<string> { "Animation", "Adventure", "Comedy" }));
            Movies.Add(new Movie("Harry Potter 2", new List<string> { "Adventure", "Family", "Fantasy" }));
            Movies.Add(new Movie("Barbie", new List<string> { "Animation", "Family", "Fantasy" }));
            Movies.Add(new Movie("Oppenheimer", new List<string> { "Biography", "Drama", "History" }));
        }
    }
}
