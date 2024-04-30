using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;

namespace Bookshelf
{
    /// <summary>
    /// Allows for interaction with Google Books API
    /// </summary>
    public class GoogleBooksAPI
    {
        static private string apiKey = "AIzaSyCrOKlzeWwLvVhCuxr7ldmaHUxNaypsoyI";
        static private BooksService service = new BooksService(new BaseClientService.Initializer
            {
                ApiKey = apiKey,
                ApplicationName = "Bookshelf"
            });


        /// <summary>
        /// Search for given book name in Google Books API.
        /// </summary>
        /// <param name="name">Name of book.</param>
        /// <param name="maxResults">Maximum result count returned.</param>
        /// <returns>List of Google Books API volumes.</returns>
        public static System.Collections.Generic.IList<Volume>? SearchBooks(string name, long maxResults = 5)
        {
            try
            {
                var listRequest = service.Volumes.List(name);
                listRequest.MaxResults = maxResults;

                var response = listRequest.Execute();
                if (response == null || response.Items == null)
                {
                    // Possible error handling here
                    return null;
                }

                return response.Items;

                // RETURN VALUE USAGE EXAMPLES:
                // - volume.VolumeInfo.Title
                // - volume.VolumeInfo.Authors
                // - volume.VolumeInfo.Publishe
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            return null;
        }
    }
}
