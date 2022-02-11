using Microsoft.Xaml.Behaviors;
using System.Windows.Controls;

namespace SLS.Infrastucture.Behaviors
{
    internal class ListBoxScrollIntoView : Behavior<ListBox>
    {
        protected override void OnAttached() => AssociatedObject.SelectionChanged += AssociatedObject_SelectionChanged;

        protected override void OnDetaching() => AssociatedObject.SelectionChanged -= AssociatedObject_SelectionChanged;

        private void AssociatedObject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;

            if (listBox?.SelectedItem != null)
            {
                listBox.Dispatcher.Invoke(() =>
                {
                    listBox.UpdateLayout();
                    listBox.ScrollIntoView(listBox.SelectedItem);
                });
            }
        }
    }
}
