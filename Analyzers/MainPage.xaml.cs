namespace Analyzers
{
	public partial class MainPage : ContentPage
	{
		int count = 0;

		public MainPage()
		{
			InitializeComponent();
		}

		private void OnCounterClicked(object sender, EventArgs e)
		{
			count++;

			if (count == 1)
				CounterBtn.Text = $"Clicked {count} time";
			else
				CounterBtn.Text = $"Clicked {count} times";

			SemanticScreenReader.Announce(CounterBtn.Text);
		}

		protected override async void OnAppearing()
		{
			List<string> actions = new string[] { "Edit", "Copy", "Delete" }.ToList();

			actions.Insert(0, "One");
			actions.Insert(0, "Two");

			string selectedAction = await DisplayActionSheet("Some Actions", "Cancel", null, actions.ToArray());

			base.OnAppearing();
		}

		public void CollectionAnalyzers()
		{
			int[] array = new[] { 1, 2, 3 }; // IDE300
			List<int> list = new List<int>() { 1, 2, 3 }; // IDE0028, IDE0090

			List<int> list2 = new[] { 1, 2, 3 }.ToList(); // Should trigger IDE0028 and IDE300.
			List<int> list3 = new List<int> { 1, 2, 3 }.ToList(); // Should trigger IDE0028, IDE0090. Removing `ToList()` causes it to trigger both.
			int[] array2 = new List<int> { 1, 2, 3 }.ToArray(); // Should trigger IDE0028, IDE0090.

			// All 3 of the above lines should/could instead/in addition trigger a new rule; something like "Unnecessary collection copy".
			// The 1st and 3rd line obviously change the type, but there is no reason to be using the intermediate type in the first place, at least
			// in these cases. I suppose some types could have desired semantics, but I question how good that code would be anyway, considering that
			// the reason for doing it would probably not be obvious in most cases other than maybe something like `HashSet<T>`. The rule could "warn"
			// that it "Could change semantics" like IDE0028 sometimes does.

			// If a new rule isn't appropriate then maybe that should be configurable on IDE0305 so that it only triggers for initializations.
			// I don't really prefer the idea of IDE0305, but I WOULD use it if I could configure it to find redundant copying like this.

			List<int> list4 = new List<int>(array); // Should trigger IDE0028. Not passing in `array` causes it to trigger IDE0028.

			List<int> list5;

			list5 = new List<int>(array); // Should trigger IDE0028 and IDE0090. Not passing in `array` causes it to trigger IDE0028, but not IDE0090.
			list5 = new List<int>(array).ToList(); // Should trigger IDE0028, IDE0090 and IDE0305 and/or probably the new rule above. Not passing in `array` causes it to trigger IDE0305.

			object obj = new List<int> { 1, 2, 3 }.ToList(); // Should trigger IDE0305 and/or probably the new rule from above.
		}
	}
}
