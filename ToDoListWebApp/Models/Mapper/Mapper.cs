using AutoMapper;
using TaskManager;

namespace ToDoListWebApp
{
    public static class ModelsMapper
    {
        public static IMapper Map()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Task, TaskView>();
                cfg.CreateMap<TaskView, Task>();
            });

            return new Mapper(config);
        }
    }
}