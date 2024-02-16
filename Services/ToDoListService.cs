using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Avalonia.Controls;

namespace ToDoList.Avalonia;

public class ToDoListService
{
    public IEnumerable<ToDoItem> GetItems()
    {
        return LoadItems();
    }

    private static IEnumerable<ToDoItem> LoadItems()
    {
        try
        {
            var baseDir = AppContext.BaseDirectory;
            var jsonPath = baseDir + "/.data.json";
            if (File.Exists(jsonPath))
            {
                var text = File.ReadAllText(jsonPath);
                var json = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<ToDoItem>>(text);
                return json ?? [];
            }
            return [];
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while reading the list: " + ex.Message);
            return [];
        }
    }

    public static void UpdateItems(IEnumerable<ToDoItem> items)
    {
        try
        {
            var baseDir = AppContext.BaseDirectory;
            var jsonPath = baseDir + "/.data.json";

            var json = System.Text.Json.JsonSerializer.Serialize(items);

            File.WriteAllText(jsonPath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while saving the list: " + ex.Message);
        }
    }
}
