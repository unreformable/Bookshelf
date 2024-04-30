using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;

namespace Bookshelf
{
    public class GoogleBooksAPI
    {
        static private string apiKey = "AIzaSyCrOKlzeWwLvVhCuxr7ldmaHUxNaypsoyI";
        static private BooksService service = new BooksService(new BaseClientService.Initializer
            {
                ApiKey = apiKey,
                ApplicationName = "Bookshelf"
            });

        public class BookSearchInfo
        {
            public string? Title { get; set; }
        }

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
                // - item.VolumeInfo.Title
                // - item.VolumeInfo.Authors
                // - item.VolumeInfo.Publishe
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            return null;
        }
        
        public static void TestGoogleBooksApi()
        {
            try
            {
                // Call the API to search for books
                var listRequest = service.Volumes.List("flowers");
                listRequest.MaxResults = 5; // Limit to 5 results
                var response = listRequest.Execute();

                // Process the response
                if (response != null && response.Items != null)
                {
                    foreach (var item in response.Items)
                    {
                        Console.WriteLine("Title: " + item.VolumeInfo.Title);
                        Console.Write("Authors: ");
                        if (item.VolumeInfo.Authors != null)
                        {
                            Console.Write(string.Join(", ", item.VolumeInfo.Authors));
                        }
                        Console.WriteLine();
                        Console.WriteLine("Publisher: " + item.VolumeInfo.Publisher);
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("No results found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}
