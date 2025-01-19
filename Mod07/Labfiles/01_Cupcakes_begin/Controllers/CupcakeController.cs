using Microsoft.AspNetCore.Mvc;
using Cupcakes.Models;

namespace Cupcakes.Controllers
{
  public class CupcakeController : Controller
  {
    private IWebHostEnvironment _environment;

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult GetImage(int id)
    {
      Cupcake requestedCupcake = null;
      if (requestedCupcake != null)
      {
        string webRootpath = _environment.WebRootPath;
        string folderPath = "\\images\\";
        string fullPath = webRootpath + folderPath + requestedCupcake.ImageName;
        if (System.IO.File.Exists(fullPath))
        {
          FileStream fileOnDisk = new FileStream(fullPath, FileMode.Open);
          byte[] fileBytes;
          using (BinaryReader br = new BinaryReader(fileOnDisk))
          {
            fileBytes = br.ReadBytes((int)fileOnDisk.Length);
          }
          return File(fileBytes, requestedCupcake.ImageMimeType);
        }
        else
        {
          if (requestedCupcake.PhotoFile.Length > 0)
          {
            return File(requestedCupcake.PhotoFile, requestedCupcake.ImageMimeType);
          }
          else
          {
            return NotFound();
          }
        }
      }
      else
      {
        return NotFound();
      }
    }
  }
}