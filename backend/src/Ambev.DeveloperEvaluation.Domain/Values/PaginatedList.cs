using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.Domain.Values;

public class PageList<T> 
{
   public PageList(List<T> items, int count, int pageNumber, int pageSize)
   {
      TotalCount = count;
      PageSize = pageSize;
      CurrentPage = pageNumber;
      Data = items;
   }

   public static async Task<PageList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
   {
      var count = await source.CountAsync();
      var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

      return new PageList<T>(items, count, pageNumber, pageSize);
   }

   public List<T> Data { get; set; }

   public int CurrentPage { get; private set; }

   public int PageSize { get; private set; }

   public int TotalCount { get; private set; }

   public bool HasPrevious => CurrentPage > 1;

   public bool HasNext => CurrentPage < TotalPages;

   public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
}