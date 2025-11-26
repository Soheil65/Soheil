using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Pharmatrack.Client.Pages.TripDashboard;
public partial class TripDashboardFilterPannel : UiComponentBase
{
    [Parameter]
    public string Class { get; set; }

    IEnumerable<Item> Data { get; set; } = new List<Item> { new Item { Id = "1", Name = "InProgress" }, new Item { Id = "2", Name = "Complete" } };
    IEnumerable<Item> Values { get; set; } = new List<Item> { new Item { Id = "1", Name = "InProgress" }, new Item { Id = "2", Name = "Complete" } };

    DateTime DateTimeStart { get; set; } = DateTime.Today;
    DateTime DateTimeEnd { get; set; } = DateTime.Today.AddDays(7);

    protected override async Task OnInitializedCoreAsync()
    {

    }
}

public class Item
{
    public string Name { get; set; }
    public string Id { get; set; }


    public bool Visible { get; set; } = false;

}
