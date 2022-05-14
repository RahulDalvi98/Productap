using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using productapp.Models;
using System;
using System.Linq;
using System.Web.ModelBinding;
using System.Threading.Tasks;
using PagedList;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading;

namespace productapp.Controllers
{
    public class productController
    {
        private readonly prodcontext _Db;
     

        public productController(prodcontext Db)
        {
            _Db = Db;
        }
        public IActionResult ProductList(int? page)
        {
            try
            {
                var prolist = from a in _Db.products
                              join b in _Db.category
                              on a.categoryID equals b.categoryID into productData
                              from b in productData.DefaultIfEmpty()

                              select new products
                              {
                                  productID = a.productID,
                                  productName = a.productName,
                                  categoryID = a.categoryID,

                                  Category = b == null ? "" : b.categoryName
                              };
                return View(prolist.ToList().ToPagedList(page ?? 1, 10));
            }
            catch (Exception ex)
            {

                return View();
            }
        }

        private IActionResult View(IPagedList<products> pagedList)
        {
            throw new NotImplementedException();
        }

        public IActionResult Create(products obj)
        {
            loadDDL();
            return View(obj);
        }

        private IActionResult View(products obj)
        {
            throw new NotImplementedException();
        }

        private void loadDDL()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(products obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.productID == 0)
                    {
                        _Db.products.Add(obj);
                        await _Db.SaveChangesAsync();
                    }
                    else
                    {
                        _Db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _Db.SaveChangesAsync();
                    }

                    return RedirectToAction("ProductList");
                }
                return View();
            }
            catch (Exception ex)
            {

                return RedirectToAction("ProductList");
            }
        }

        private IActionResult View()
        {
            throw new NotImplementedException();
        }

        private IActionResult RedirectToAction(string v)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> DeleteProduct(int ID)
        {
            try
            {
                var pro = await _Db.products.MinAsync(id);
                if (pro != null)
                {
                    _Db.products.Remove(pro);
                    await _Db.SaveChangesAsync();
                }
                return RedirectToAction("ProductList");
            }
            catch (Exception ex)
            {

                return RedirectToAction("ProductList");
            }
        }
    }
}
