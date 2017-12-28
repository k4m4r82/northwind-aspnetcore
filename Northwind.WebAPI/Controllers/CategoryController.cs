using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Model;
using Northwind.Repository;
using Northwind.WebAPI.Model;

namespace Northwind.WebAPI.Controllers
{
    //[Produces("application/json")] // The [Produces] filter will force all actions within the AuthorsController to return JSON-formatted
    [Route("api/[controller]")]
    public class CategoryController : BaseApiController
    {
        private IDapperContext _context;

        //public CategoryController(IDapperContext context)
        //{
        //    this._context = context;
        //}

        public CategoryController()
        {
            //this._context = context;

            _context = new DapperContext();
        }

        [HttpGet, Route("get_by_id")]
        public IActionResult GetById(int id)
        {
            ResponsePackage response = null;

            try
            {
                ICategoryRepository repo = new CategoryRepository(_context);
                var result = repo.GetByID(id);

                response = GenerateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                //_log.Error("Error:", ex);
            }

            return Ok(response);
        }

        [HttpGet, Route("get_all")]
        public IActionResult GetAll()
        {
            ResponsePackage response = null;

            //try
            //{

                ICategoryRepository repo = new CategoryRepository(_context);
                var results = repo.GetAll();

                response = GenerateResponse(HttpStatusCode.OK, results);
            //}
            //catch (Exception ex)
            //{
            //    //_log.Error("Error:", ex);
            //}
            
            return Ok(response);
        }

        [HttpGet, Route("get_by_name")]
        public IActionResult GetByName(string name)
        {
            ResponsePackage response = null;

            try
            {
                ICategoryRepository repo = new CategoryRepository(_context);
                var results = repo.GetByName(name);

                response = GenerateResponse(HttpStatusCode.OK, results);
            }
            catch (Exception ex)
            {
                //_log.Error("Error:", ex);
            }

            return Ok(response);
        }


        [HttpPost, Route("save")]
        public IActionResult Save([FromBody] Category obj)
        {
            ResponsePackage response = null;

            if (obj == null)
            {
                response = GenerateResponse(HttpStatusCode.BadRequest, new { Message = "request format not valid" });
                return BadRequest(response);
            }

            try
            {
                ICategoryRepository repo = new CategoryRepository(_context);
                var result = repo.Save(obj);

                response = GenerateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                //_log.Error("Error:", ex);
            }

            return Ok(response);
        }

        [HttpPost, Route("update")]
        public IActionResult Update([FromBody] Category obj)
        {
            ResponsePackage response = null;

            if (obj == null)
            {
                response = GenerateResponse(HttpStatusCode.BadRequest, new { Message = "request format not valid" });
                return BadRequest(response);
            }

            try
            {
                ICategoryRepository repo = new CategoryRepository(_context);
                var result = repo.Update(obj);

                response = GenerateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                //_log.Error("Error:", ex);
            }

            return Ok(response);
        }

        [HttpPost, Route("delete")]
        public IActionResult Delete([FromBody] Category obj)
        {
            ResponsePackage response = null;

            if (obj == null)
            {
                response = GenerateResponse(HttpStatusCode.BadRequest, new { Message = "request format not valid" });
                return BadRequest(response);
            }

            try
            {
                ICategoryRepository repo = new CategoryRepository(_context);
                var result = repo.Delete(obj);

                response = GenerateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                //_log.Error("Error:", ex);
            }

            return Ok(response);
        }
    }
}