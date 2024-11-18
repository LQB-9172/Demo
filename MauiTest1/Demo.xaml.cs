using System.Collections.Generic;
using MauiTest1.Services;

namespace MauiTest1
{
    public partial class Demo : ContentPage
    {
        public Demo()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var students = await ApiService.GetStudents(); // G?i ph??ng th?c m?i

            if (students != null)
            {
                // G�n danh s�ch sinh vi�n l�m BindingContext
                BindingContext = students;
            }
            else
            {
                await DisplayAlert("Error", "Failed to load student data", "OK");
            }
        }
    }
}
