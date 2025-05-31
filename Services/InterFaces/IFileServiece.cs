using System.ComponentModel.DataAnnotations;
namespace MCV_Empity.Services.InterFaces
{
    public interface IFileServiece
    {
        public  Task<string> Upload(IFormFile formFile,string Location);

        public bool DeleteSource(string? path);
    }
}
