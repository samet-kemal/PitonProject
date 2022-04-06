using Microsoft.EntityFrameworkCore;
using PitonProject.Context;
using PitonProject.Models;
using PitonProject.Services;
using System.Collections.Generic;
using System.Linq;

namespace PitonProject.Repository
{
    public class TodoRepository : ITodoRespository
    {
        private readonly PitonDbContext _context;

        public TodoRepository(PitonDbContext context)
        {
            _context = context;
        }
        public List<Todo> GetAllTodoWithUsers()
        {
            var list = _context.Todo.Include(x => x.User).ToList();
            return list;
        }

        public List<Todo> GetTodosByType(string todoType)
        {
            var list = _context.Todo.Where(x => x.TodoType == todoType).ToList();
            return list;
        }

        public List<Todo> GetTodosByUserId(int userId)
        {
            var list = _context.Todo.Where(x => x.UserId== userId).Include(x => x.User).ToList();
            return list;
        }

        public Todo GetUsersTodoById(int userId, int todoId)
        {
            var todo = _context.Todo.Where(x => x.UserId == userId && x.Id == todoId).FirstOrDefault();
            return todo;
        }


    }
}
