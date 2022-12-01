using System;
using Microsoft.JSInterop;

namespace Blazor_Server_App.Helper
{
	public static class JSRuntimeExtension
	{
		public static async ValueTask ToastrSuccess(this IJSRuntime jsRuntime, string message)
		{
			await jsRuntime.InvokeVoidAsync("ShowToastr", "success", message);
		}		
		public static async ValueTask ToastrFailure(this IJSRuntime jsRuntime, string message) => 
			await jsRuntime.InvokeVoidAsync("ShowToastr", "error", message);
		

		public static async ValueTask SweetAlertSuccess(this IJSRuntime jsRuntime, string message) =>
			await jsRuntime.InvokeVoidAsync("ShowSweetAlert", "success", message);

		public static async ValueTask SweetAlertError(this IJSRuntime jsRuntime, string message) =>
			await jsRuntime.InvokeVoidAsync("ShowSweetAlert", "error", message);
	}
}

