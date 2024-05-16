namespace Buttons
{
	public partial class TestPage : ContentPage
	{
		public TestPage()
		{
			InitializeComponent();
		}

		private void OnCounterClicked(object sender, EventArgs e)
		{
			if (sender == CounterBtn2)
			{
				if (CounterBtn.LineBreakMode != LineBreakMode.WordWrap)
				{
					CounterBtn.LineBreakMode = LineBreakMode.WordWrap;
				}
				else
				{
					CounterBtn.LineBreakMode = LineBreakMode.CharacterWrap;
				}
			}
			else
			{
				CounterBtn.CharacterSpacing += 1;
			}

			SemanticScreenReader.Announce(CounterBtn.Text);
		}
	}

}
