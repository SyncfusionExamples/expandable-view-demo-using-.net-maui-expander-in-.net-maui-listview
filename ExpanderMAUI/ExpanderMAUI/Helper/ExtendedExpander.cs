using Syncfusion.Maui.Expander;
using Syncfusion.Maui.ListView;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpanderMAUI
{
public class ExtendedExpander: SfExpander
{
    #region Fields
    public SfListView ListView { get; set; }
    #endregion

    #region Constructor
    public ExtendedExpander()
    {
        this.Expanded += ExtendedExpander_Expanded;
    }

    #endregion

    #region Call back

    private void ExtendedExpander_Expanded(object sender, ExpandedAndCollapsedEventArgs e)
    {
        var item = (sender as SfExpander).BindingContext as Contact;
        var itemIndex = ListView.DataSource.DisplayItems.IndexOf(item);

        ListView.Dispatcher.Dispatch(async () =>
        {
            await Task.Delay(200);
            ListView.ItemsLayout.ScrollToRowIndex(itemIndex, ScrollToPosition.MakeVisible, false);
        });
    }
    #endregion
}
}
