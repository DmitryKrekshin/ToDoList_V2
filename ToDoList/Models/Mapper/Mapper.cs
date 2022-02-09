using AutoMapper;
using ToDoListService;

namespace ToDoList
{
    public static class Map
    {
        static Mapper TaskMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TaskEntity, Task>());

            return new Mapper(config);
        }
    }
}