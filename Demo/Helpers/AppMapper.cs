using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Demo.Data;
using static System.Net.Mime.MediaTypeNames;
using Demo.Models;

namespace Demo.Helpers
{
    public class AppMapper : Profile
    {
        public AppMapper()
        {
            CreateMap<Data.Question, QuestionModel>().ReverseMap();
            CreateMap<Data.Image, ImageModel>().ReverseMap();
            CreateMap<Data.Audio, AudioModel>().ReverseMap();
            CreateMap<Data.Exercise, ExerciseModel>().ReverseMap();
            CreateMap<Data.Lesson, LessonModel>().ReverseMap();
            CreateMap<Data.Progress, ProgressModel>().ReverseMap();
            CreateMap<Data.Student, StudentModel>().ReverseMap();
            CreateMap<Data.Test, TestModel>().ReverseMap();
        }
    }
}
