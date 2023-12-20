# expandable-view-demo-using-.net-maui-expander-in-.net-maui-listview
This example demonstrates about how to create the expandable view demo using .NET MAUI Expander (SfExpander) in .NET MAUI ListView (SfListView).

You can bring the entire [ListViewItem](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.ListView.ListViewItem.html) to the view when expanding the [SfExpander](https://www.syncfusion.com/maui-controls/maui-expander) in .NET MAUI [SfListView](https://help.syncfusion.com/maui/listview/getting-started). 

C#

The **ExtendedExpander** is used to bring the entire item to the View. You can get the index of the item from the [DataSource.DisplayItems](). In the Expanded event, you can bring the item to view using the [ScrollToRowIndex](https://help.syncfusion.com/maui/listview/scrolling#scrolling-to-row-index) method.

```
public class ExtendedExpander: SfExpander
{
    public SfListView ListView { get; set; }
 
    public ExtendedExpander()
    {
        this.Expanded += ExtendedExpander_Expanded;
    }
    
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
}
```

XAML

The **ExtendedExpander** is loaded in the [SfListView.ItemTemplate](). Also, set the **ListView **reference to the Expander to perform scrolling.

```
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:syncfusion="clr-namespace:Syncfusion.Maui.Expander;assembly=Syncfusion.Maui.Expander"   
             xmlns:sflistview="clr-namespace:Syncfusion.Maui.ListView;assembly=Syncfusion.Maui.ListView"
             xmlns:local="clr-namespace:ExpanderMAUI"
             x:Class="ExpanderMAUI.MainPage">
    <ContentPage.BindingContext>
        <local:ViewModel />
    </ContentPage.BindingContext>

    <ContentPage.Content>
        <Grid x:Name="mainGrid" BackgroundColor="#F0F0F0" Padding="4">
            <sflistview:SfListView x:Name="listView" AutoFitMode="DynamicHeight" ItemsSource="{Binding ContactsInfo}">
                <sflistview:SfListView.ItemTemplate>
                    <DataTemplate>
                        <Frame x:Name="frame" CornerRadius="2" Padding="{OnPlatform Android=1, iOS=1,  WinUI=0}" Margin="{OnPlatform Android=1, iOS=1,  WinUI=0}"  HasShadow="{OnPlatform Android=true, iOS=false, WinUI=true}">
                            <Grid Padding="{OnPlatform Android=2, iOS=2, WinUI=0}" Margin="{OnPlatform Android=1, iOS=1,  WinUI=0}" BackgroundColor="Red" HeightRequest="50" >
                                <local:ExtendedExpander x:Name="expander" ListView="{x:Reference listView}" HeaderIconPosition="None" IsExpanded="{Binding IsExpanded, Mode=TwoWay}">
                                    <local:ExtendedExpander.Header>
                                       ....
                                    </local:ExtendedExpander.Header>
                                    <local:ExtendedExpander.Content>
                                       ....
                                    </local:ExtendedExpander.Content>
                                </local:ExtendedExpander>
                            </Grid>
                        </Frame>
                    </DataTemplate>
                </sflistview:SfListView.ItemTemplate>
            </sflistview:SfListView>
        </Grid>
    </ContentPage.Content>
</ContentPage>
```
