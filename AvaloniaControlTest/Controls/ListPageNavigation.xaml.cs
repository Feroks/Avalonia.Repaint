using System.Reactive.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ReactiveUI;

namespace AvaloniaControlTest.Controls
{
	public class ListPageNavigation : UserControl
	{
		public ListPageNavigation()
		{
			AvaloniaXamlLoader.Load(this);
			PageNumber = 1;

			var canExecutePreviousPage = this.WhenAnyValue(x => x.PageNumber)
				.ObserveOn(RxApp.MainThreadScheduler)
				.Select(x => x > 1);
			PreviousPage = ReactiveCommand.Create(() =>
			{
				PageNumber--;
			}, canExecutePreviousPage);

			var canExecuteNextPage = this.WhenAnyValue(x => x.PageNumber)
				.ObserveOn(RxApp.MainThreadScheduler)
				.Select(x => x < 3);
			NextPage = ReactiveCommand.Create(() =>
			{
				PageNumber++;
			}, canExecuteNextPage);
		}

		public ReactiveCommand PreviousPage { get; }

		public ReactiveCommand NextPage { get; }
		
		public bool DisplayProgressBar { get; set; }

		public static readonly StyledProperty<int> PageNumberProperty =
			AvaloniaProperty.Register<ListPageNavigation, int>(nameof(PageNumber));

		public int PageNumber
		{
			get => GetValue(PageNumberProperty);
			set => SetValue(PageNumberProperty, value);
		}
	}
}