namespace Post_EDU.Web.WebHostHelpers
{
    public class UploadFileHelper(IWebHostEnvironment webHost)
    {
        private readonly IWebHostEnvironment _webHost = webHost;

        public string? Active(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var uploadsDirectory = Path.Combine(_webHost.WebRootPath, "uploads");
                var fileName = Path.GetFileName(file.FileName);
                string? filePath = Path.Combine(uploadsDirectory, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return fileName;
            }
            return null;
        }

    }
}
