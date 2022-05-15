using System.Text;
using Microsoft.AspNetCore.Mvc;
using SendPicWebApp.Models;
using SendPicWebApp.Views.Image;

namespace SendPicWebApp.Controllers;

public class ImageController : Controller
{
	private readonly IHostEnvironment _environment;

	public ImageController(IWebHostEnvironment environment)
	{
		_environment = environment;
	}
	public IActionResult Base()
	{
		return View();
	}

	public async Task<IActionResult> Enter(ImageEntriesModel rawmodel)
	{
		try
		{
			if (rawmodel.File != null && rawmodel.File.Length >0) 
			{
				string root = _environment.ContentRootPath;
				root += $"/wwwroot/Images/{rawmodel.File.Name}.jpg";
				using (FileStream stream = new FileStream( root,FileMode.OpenOrCreate,FileAccess.Write))
				{
					await rawmodel.File.CopyToAsync(stream);
				}

				var model = new ImageModel()
				{
					FileName = rawmodel.File.Name,
					Description = rawmodel.Description
				};
				return RedirectToAction("Review",model);
			}
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
		return BadRequest();
	}

	public IActionResult Review(ImageModel model)
	{
		return View(new ImageModel(){Description = model.Description,FileName = model.FileName});
	}

	public IActionResult Back()
	{
		return RedirectToAction("Base");
	}
}