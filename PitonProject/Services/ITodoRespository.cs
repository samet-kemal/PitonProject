using PitonProject.Models;
using System.Collections.Generic;

namespace PitonProject.Services
{
    public interface ITodoRespository
    {
        List<Todo> GetAllTodoWithUsers();
        List<Todo> GetTodosByUserId(int userId);
        Todo GetUsersTodoById(int userId,int todoId);
        List<Todo> GetTodosByType(string todoType);
    }
}
