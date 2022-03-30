﻿using System.Net.Http.Json;
using BookSocial.EntityClass.Entity;
using BookSocial.Service.ServiceInterface;

namespace BookSocial.Service.ServiceClass
{
    public class AuthorBookService : ConnectAPI, IAuthorBookService
    {
        public async Task<IEnumerable<AuthorBook>> GetByBookId(int bookId)
        {
            var response = await GetClient().GetAsync($"AuthorBook/GetByBookId?bookId={bookId}");
            var data = response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<IEnumerable<AuthorBook>>() : null;
            return data;
        }

        public async Task<int> Delete(int bookId, int authorId)
        {
            var response = await GetClient().DeleteAsync($"AuthorBook/Delete?bookId={bookId}&authorId={authorId}");
            var data = response.IsSuccessStatusCode ? 1 : 0;
            return data;
        }
    }
}
