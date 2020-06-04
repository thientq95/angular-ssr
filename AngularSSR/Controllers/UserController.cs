using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AngularSSR.ApiModels;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.interfaces;

namespace AngularSSR.Controllers
{
    public class UserController : BaseAPIController
    {
        /*private readonly IRepository _repository;

        public UserController(IRepository repository)
        {
            _repository = repository;
        }*/

        [HttpGet("/info")]
        public ActionResult<string> Info()
        {
            var assembly = typeof(Startup).Assembly;

            var creationDate = System.IO.File.GetCreationTime(assembly.Location);
            var version = FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;

            return Ok($"Version: {version}, Last Updated: {creationDate}");
        }

        // GET: api/user
        [HttpGet]
        public IActionResult List()
        {
            List<User> listUser = new List<User>();
            listUser.Add(new User("thientq", "Trần Quốc Thiện", "thientq.spkt@gmail.com", true));
            listUser.Add(new User("tronghdh", "Hồ Đặng Hữu Trọng", "trong.spkt@gmail.com", true));
            listUser.Add(new User("vituong", "Đoàn Thị Trường Vi", "tuongvi@gmail.com", true));
            return Ok(new ResponseData<User>
            {
                StatusCode = 200,
                Message = "",
                Data = listUser
            });
        }
       /* public async Task<IActionResult> List()
        {
            var items = (await _repository.ListAsync<User>())
                            .Select(UserDTO.FromUser);
            return Ok(items);
        }*/

        // GET: api/ToDoItems
        /* [HttpGet("{id:int}")]
         public async Task<IActionResult> GetById(int id)
         {
             var item = UserDTO(await _repository.GetByIdAsync<User>(id));
             return Ok(item);
         }*/

        // POST: api/ToDoItems
        /*[HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDTO item)
        {
            User user = new User()
            {
                UserName = item.UserName,
                FullName = item.FullName,
                Email = item.Email,
                Gender = item.Gender
            };
            await _repository.AddAsync(user);
            return Ok(user);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromBody] UserDTO item, int id)
        {
            User user = await _repository.GetByIdAsync<User>(id);
            user.FullName = item.FullName;
            user.UserName = item.UserName;
            user.Email = item.Email;
            user.Gender = item.Gender;
            await _repository.UpdateAsync(user);

            return Ok(user);
        }*/
    }
}