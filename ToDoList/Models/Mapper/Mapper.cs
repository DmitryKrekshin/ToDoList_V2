using AutoMapper;

namespace ToDoList
{
    public static class Map
    {
        private static MapperConfiguration config = new (cfg => cfg.CreateMap<ToDoListService.Task, Task>());

        public static Mapper Mapper = new Mapper(config);
    }
}