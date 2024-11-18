using AutoMapper;
using test.Data;
using test.Models;

namespace test.Helpers
{
    public class AppMapper : Profile
    {
        public AppMapper() 
        {
            CreateMap<Lesson,LessonModel>().ReverseMap();
            CreateMap<Image, ImageModel>().ReverseMap();
        }
    }
}
