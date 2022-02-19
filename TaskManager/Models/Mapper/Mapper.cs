using AutoMapper;
using ToDoListService;

namespace TaskManager
{
    public static class Map
    {
        public static IMapper TaskMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TaskEntity, Task>());

            return new Mapper(config);
        }
    }
}