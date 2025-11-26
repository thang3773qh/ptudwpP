namespace LinguaCenter.Models
{
    public class CurriculumViewModel
    {
        public string ModuleTitle { get; set; }
        public string LessonsCount { get; set; }
        public List<LessonItemViewModel> Lessons { get; set; }
    }

    public class LessonItemViewModel
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Type { get; set; }
    }

}
