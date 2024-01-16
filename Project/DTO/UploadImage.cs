namespace Project.DTO
{
    public class UploadImage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long PhoneNo { get; set; }
        public string PanNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string City { get; set; }
        public int PinCode { get; set; }
        public IFormFile ImageFilePath { get; set; }
    }
}
