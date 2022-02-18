using Microsoft.Xaml.Behaviors;
using System;
using System.Windows.Controls;

namespace SLS.Infrastucture.Behaviors
{
    internal class ListBoxScrollIntoView : Behavior<ListBox>
    {
        protected override void OnAttached() => AssociatedObject.Loaded += AssociatedObject_Loaded;
        

        protected override void OnDetaching() => AssociatedObject.Loaded -= AssociatedObject_Loaded;

        private void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!(sender is ListBox listBox)) throw new TypeAccessException($"{sender} is not ListBox.");

            listBox.SelectedItem = listBox.Items[listBox.Items.Count - 1];
            listBox.ScrollIntoView(listBox.SelectedItem);
        }
    }
}
