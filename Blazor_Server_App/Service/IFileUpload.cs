using System;
using Microsoft.AspNetCore.Components.Forms;

namespace Blazor_Server_App.Service
{
	public interface IFileUpload
	{
		Task<string> UploadFile(IBrowserFile file);

		bool DeleteFile(string file);
	}
}

