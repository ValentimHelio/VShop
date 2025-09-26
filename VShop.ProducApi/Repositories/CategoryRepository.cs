using Microsoft.EntityFrameworkCore;
using VShop.ProducApi.Context;
using VShop.ProducApi.Models;

namespace VShop.ProducApi.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        return await _context.Categores.ToListAsync();
    }

    public async Task<IEnumerable<Category>> GetCategoriesProductus()
    {
        return await _context.Categores.Include(c => c.Products).ToListAsync();
    }

    public async Task<Category> GetById(int id)
    {
        return await _context.Categores.Where(c => c.CategoryId == id).FirstOrDefaultAsync();
    }

    public async Task<Category> Create(Category category)
    {
        _context.Categores.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> Update(Category category)
    {
        _context.Entry(category).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> Delete(int id)
    {
        var category = await GetById(id);
        _context.Categores.Remove(category);
        await _context.SaveChangesAsync();
        return category;
    }

}
