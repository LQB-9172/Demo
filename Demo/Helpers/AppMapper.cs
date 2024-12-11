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
            CreateMap<Data.Video, VideoModel>().ReverseMap();
            CreateMap<Data.Exercise, ExerciseModel>().ReverseMap();
            CreateMap<Data.Progress, ProgressModel>().ReverseMap();
            CreateMap<Data.Student, StudentModel>().ReverseMap();
            CreateMap<Data.Lesson, LessonModel>().ReverseMap();

            CreateMap<StudentLesson, StudentLessonModel>()
            .ForMember(dest => dest.LessonID, opt => opt.MapFrom(src => src.Lesson.LessonID))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Lesson.Title))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Lesson.TitleUrl))
            .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => src.IsCompleted))
            .ForMember(dest => dest.CompletedDate, opt => opt.MapFrom(src => src.CompletedDate));

            CreateMap<Student, StudentModel>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
            .ForMember(dest => dest.Progress, opt => opt.MapFrom(src => src.Progress.CompletionPercentage));
        }
    }
}
