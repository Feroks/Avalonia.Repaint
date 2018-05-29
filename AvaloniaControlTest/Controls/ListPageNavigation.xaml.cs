using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace AvaloniaControlTest.Controls
{
	public class ListPageNavigation : UserControl
	{
		private readonly TextBlock _textBlock;
		private readonly TextBox _textBox;
		private int _value;

		public ListPageNavigation()
		{
			_value = 0;
			AvaloniaXamlLoaderPortableXaml.Load(this);
			_textBlock = this.FindControl<TextBlock>("TextBlockField");
			_textBox = this.FindControl<TextBox>("TextBoxField");
		}

		public void OnPrevious(object sender, RoutedEventArgs args)
		{
			var value = (--_value).ToString();
			_textBlock.Text = value;
			_textBox.Text = value;
		}

		public void OnNext(object sender, RoutedEventArgs args)
		{
			var value = (++_value).ToString();
			_textBlock.Text = value;
			_textBox.Text = value;
		}
	}
}