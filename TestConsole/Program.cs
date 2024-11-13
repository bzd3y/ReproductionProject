namespace TestConsole
{
	internal class Program
	{
		private static async Task MakeRequestAsync(string url, HttpMessageHandler handler = null)
		{
			using HttpRequestMessage request = new(HttpMethod.Head, url);
			HttpClient client = handler switch
			{
				null => new(),
				_ => new(handler)
			};
			using HttpResponseMessage response = await client.SendAsync(request);

			Console.WriteLine($"--- Request ---");
			Console.WriteLine(response.RequestMessage);
			Console.WriteLine($"--- Response ---");
			Console.WriteLine(response);
		}

		private static async Task MakeRequestsAsync()
		{
			Console.WriteLine("--- using default HttpMessageHandler ---");

			await MakeRequestAsync("https://github.com/dotnet/android/raw/refs/heads/main/.editorconfig"); // redirects, gets converted to GET
			await MakeRequestAsync("https://raw.githubusercontent.com/dotnet/android/refs/heads/main/.editorconfig"); // target of redirect, stays HEAD

			Console.WriteLine("--- using SocketsHttpHandler ---");

			await MakeRequestAsync("https://github.com/dotnet/android/raw/refs/heads/main/.editorconfig", new SocketsHttpHandler()); // redirects, gets stays HEAD
			await MakeRequestAsync("https://raw.githubusercontent.com/dotnet/android/refs/heads/main/.editorconfig", new SocketsHttpHandler()); // target of redirect, stays HEAD
		}

		static async Task Main(string[] args)
		{
			await MakeRequestsAsync();
		}
	}
}
