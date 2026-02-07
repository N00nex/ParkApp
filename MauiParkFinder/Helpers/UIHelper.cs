using System.Collections.ObjectModel;


namespace MauiParkFinder.Helpers;

public static class UIHelper
{
    public static async Task LoadAsync<T>(
        this ObservableCollection<T> collection,
        Func<Task<List<T>>> fetchFunc)
    {
        var items = await fetchFunc();
        collection.Clear();
        foreach (var item in items)
        collection.Add(item);
    }
}

