namespace Demo.Models
{
    public class LessonDetailsModel
    {
        public int LessonID { get; set; }
        public string? Title { get; set; }
        public List<ImageModel> Images { get; set; }
        public List<VideoModel> Videos { get; set; }

        public LessonDetailsModel()
        {
            Images = new List<ImageModel>();
            Videos = new List<VideoModel>();
        }
    }
}
