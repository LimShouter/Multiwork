using System.Text;
using System.Text.Json.Serialization;
using AsyncFormUploader.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AsyncFormUploader.Controllers;

[Route("{controller}")]
public class FormLoadController : ControllerBase
{
	[HttpPost]
	public async Task<IActionResult> UploadForm([FromForm]Form form)
	{
		await Task.Delay(5000);
		if (Validate(form,out string responseString))
		{
			SaveForm(form);
		}
		return Ok(responseString);
	}

	private void SaveForm(Form form)
	{
		//Save data in database	
	}

	private bool Validate(Form form,out string responseString)
	{
		var response = new Dictionary<string, object>();
		var failureTags = new List<string>();
		bool status = true;
		if (form.FirstName == null)
		{
			failureTags.Add("Имя");
			status = false;
		}
		
		if (form.LastName == null)
		{
			failureTags.Add("Фамилия");
			status = false;
		}
		
		if (form.Email == null || !form.Email.Contains('@'))
		{
			failureTags.Add("Email");
			status = false;
		}
		
		StringBuilder sb = new StringBuilder();
		sb.Append("Введите данные в поля:");
		foreach (var tag in failureTags)
		{
			sb.Append(tag + ",");
		}
		sb[sb.Length - 1] = '.';
		response.Add("status",status);
		response.Add("failureTags",sb.ToString());

		responseString = JsonConvert.SerializeObject(response);
		return status;
	}
}