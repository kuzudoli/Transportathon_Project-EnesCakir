namespace Transportathon_Project_EnesCakir.Helpers
{
    public interface IImageHelper
    {
        Task<string> PhotoSave(IFormFile photo);
        Task<string> PhotoUpdate(string oldUrl, IFormFile photo);

        Task<bool> PhotoDelete(string photoUrl);
    }
}
