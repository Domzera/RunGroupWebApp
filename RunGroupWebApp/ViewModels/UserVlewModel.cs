namespace RunGroupWebApp.ViewModels
{
    public class UserVlewModel
    {
        public string  Id { get; set; }
        public string UserName { get; set; }
        public int? Pace { get; set; }
        public int? Mileage { get; set; }//Quanto você corre por semanas, por exemplo
        public string? ProfileImageUrl { get; set; }
    }
}
