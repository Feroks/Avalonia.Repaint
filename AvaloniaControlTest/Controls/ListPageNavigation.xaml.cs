using System.Reactive.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
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
			PageCount = 2;

			var canExecutePreviousPage = this.WhenAnyValue(x => x.PageNumber)
				.ObserveOn(RxApp.MainThreadScheduler)
				.Select(x => x > 1);
			PreviousPage = ReactiveCommand.Create(() =>
			{
				PageNumber--;
			}, canExecutePreviousPage);

			var canExecuteNextPage = this.WhenAnyValue(x => x.PageNumber)
				.ObserveOn(RxApp.MainThreadScheduler)
				.Select(x => x < PageCount);
			NextPage = ReactiveCommand.Create(() =>
			{
				PageNumber++;
			}, canExecuteNextPage);
		}

		public ReactiveCommand PreviousPage { get; }

		public ReactiveCommand NextPage { get; }

		public static readonly StyledProperty<int> PageCountProperty =
			AvaloniaProperty.Register<ListPageNavigation, int>(nameof(PageCount),
				defaultBindingMode: BindingMode.TwoWay);

		public int PageCount
		{
			get => GetValue(PageCountProperty);
			set => SetValue(PageCountProperty, value);
		}

		public static readonly StyledProperty<int> PageNumberProperty =
			AvaloniaProperty.Register<ListPageNavigation, int>(nameof(PageNumber));

		public int PageNumber
		{
			get => GetValue(PageNumberProperty);
			set => SetValue(PageNumberProperty, value);
		}
	}
}