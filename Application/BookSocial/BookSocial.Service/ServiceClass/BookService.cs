using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;
using BookSocial.Service.ServiceInterface;
using System.Net.Http.Json;

namespace BookSocial.Service.ServiceClass
{
    public class BookService : ConnectAPI, IBookService
    {
        public async Task<IEnumerable<Book>> GetByGenreId(int genreId)
        {
            var response = await GetClient().GetAsync($"Book/GetByGenreId?genreId={genreId}");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<Book>>() : null;
            return data;
        }

        public async Task<IEnumerable<BookStatistic>> GetBookStatistic()
        {
            var response = await GetClient().GetAsync($"Book/GetBookStatistic");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<BookStatistic>>() : null;
            return data;
        }

        public async Task<IEnumerable<SearchBook>> GetSearchBook()
        {
            var response = await GetClient().GetAsync($"Book/GetSearchBook");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<SearchBook>>() : null;
            return data;
        }

        public async Task<IEnumerable<BookListByAuthorId>> GetBookListByAuthorId(int authorId)
        {
            var response = await GetClient().GetAsync($"Book/GetBookListByAuthorId?authorId={authorId}");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<BookListByAuthorId>>() : null;
            return data;
        }

        public async Task<int> Create(Book book)
        {
            var response = await GetClient().PostAsJsonAsync($"Book/Create", book);
            var data = response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<int>() : 0;
            return data;
        }

        public async Task<int> Update(Book book)
        {
            var response = await GetClient().PutAsJsonAsync($"Book/Update", book);
            var data = response.IsSuccessStatusCode ? 1 : 0;
            return data;
        }

        public async Task<int> Delete(int bookId)
        {
            var response = await GetClient().DeleteAsync($"Book/Delete?id={bookId}");
            var data = response.IsSuccessStatusCode ? 1 : 0;
            return data;
        }

        public async Task<Book> GetByIsbn(string isbn)
        {
            var response = await GetClient().GetAsync($"Book/GetByIsbn?isbn={isbn}");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<Book>() : null;
            return data;
        }

        public async Task<Book> GetById(int id)
        {
            var response = await GetClient().GetAsync($"Book/GetById?id={id}");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<Book>() : null;
            return data;
        }

        public async Task<SingleBookCurrentlyReading> GetSingleBookCurrentlyReading(int userId)
        {
            var response = await GetClient().GetAsync($"Book/GetSingleBookCurrentlyReading?userId={userId}");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<SingleBookCurrentlyReading>() : null;
            return data;
        }
    }
}
