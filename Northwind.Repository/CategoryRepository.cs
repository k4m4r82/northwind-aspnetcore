using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using Northwind.Model;
using Dapper.Contrib.Extensions;

namespace Northwind.Repository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Category GetByID(int id);
        IList<Category> GetByName(string name);
    }

    public class CategoryRepository : ICategoryRepository
    {
        private IDapperContext _context;

        public CategoryRepository(IDapperContext context)
        {
            _context = context;
        }

        public IList<Category> GetAll()
        {
            IList<Category> oList = new List<Category>();

            try
            {
                oList = _context.db.GetAll<Category>()
                                .OrderBy(f => f.categoryname)
                                .ToList();
            }
            catch (Exception ex)
            {
                //_log.Error("Error:", ex);
            }

            return oList;
        }

        public Category GetByID(int id)
        {
            Category obj = null;

            try
            {
                obj = _context.db.Get<Category>(id);
            }
            catch (Exception ex)
            {
                //_log.Error("Error:", ex);
            }

            return obj;
        }

        public IList<Category> GetByName(string name)
        {
            IList<Category> oList = new List<Category>();

            try
            {
                oList = _context.db.GetAll<Category>()
                                .Where(f => f.categoryname.ToLower().Contains(name.ToLower()) || f.description.ToLower().Contains(name.ToLower()))
                                .OrderBy(f => f.categoryname)
                                .ToList();

            }
            catch (Exception ex)
            {
                //_log.Error("Error:", ex);
            }

            return oList;
        }

        public int Save(Category obj)
        {
            var result = 0;

            try
            {
                _context.db.Insert<Category>(obj);
                result = 1;
            }
            catch (Exception ex)
            {
                //_log.Error("Error:", ex);
            }

            return result;
        }

        public int Update(Category obj)
        {
            var result = 0;

            try
            {
                result = _context.db.Update<Category>(obj) ? 1 : 0;
            }
            catch (Exception ex)
            {
                //_log.Error("Error:", ex);
            }

            return result;
        }

        public int Delete(Category obj)
        {
            var result = 0;

            try
            {
                result = _context.db.Delete<Category>(obj) ? 1 : 0;
            }
            catch (Exception ex)
            {
                //_log.Error("Error:", ex);
            }

            return result;
        }
    }
}
