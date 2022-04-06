using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PitonProject.Models;
using PitonProject.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PitonProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Todo> _todoRepository;
        private readonly ITodoRespository _todoRepo;

        public HomeController(ILogger<HomeController> logger, IRepository<User> userRepository, IRepository<Todo> todoRepository,ITodoRespository todoRepo)
        {
            _logger = logger;
            _userRepository = userRepository;
            _todoRepository = todoRepository;
            _todoRepo = todoRepo;
        }

        public IActionResult Index()
        {
            var list = _todoRepo.GetAllTodoWithUsers();
            return View(list);
        }


        public IActionResult TodoListByType(string type)
        {
            var list = _todoRepo.GetTodosByType(type);
            return View(list);
        }

        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            _userRepository.Create(user);
            return RedirectToAction("Index");
        }

        public IActionResult CreateTodo()
        {
            var users = _userRepository.GetAll();
            var model = new CreateTodoViewModel()
            {
                User = users
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult CreateTodo(Todo todo)
        {
            _todoRepository.Create(todo);
            var list = _todoRepo.GetAllTodoWithUsers();
            return View("Index",list);
        }

        public IActionResult UpdateTodo(int id)
        {
            var todo = _todoRepository.GetById(id);
            if(todo!= null)
                return View(todo);
            else
            {
                var list = _todoRepo.GetAllTodoWithUsers();
                return View("Index", list);
            }
        }
        [HttpPost]
        public IActionResult UpdateTodo(Todo todo)
        {
            if(todo != null)
            {
                _todoRepository.Update(todo);
            }
            var list = _todoRepo.GetAllTodoWithUsers();
            return View("Index", list);
        }
        public IActionResult DeleteTodo(int id)
        {
            var todo = _todoRepository.GetById(id);
            if (todo != null)
            {
                _todoRepository.Delete(todo);
            }
            var list = _todoRepo.GetAllTodoWithUsers();
            return View("Index", list);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
