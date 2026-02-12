using JobControl.Models;
using System.Text.Json;

namespace JobControl.Services;

public class ApplicationService
{
    private List<JobApplication> applications = new();
    private int nextId = 1;
    private readonly string filePath = "applications.json";

    public ApplicationService()
    {
        LoadData();
    }

    private void LoadData()
    {
        if (!File.Exists(filePath))
            return;

        var json = File.ReadAllText(filePath);
        var data = JsonSerializer.Deserialize<List<JobApplication>>(json);

        if (data != null)
        {
            applications = data;
            if (applications.Count > 0)
                nextId = applications.Max(a => a.Id) + 1;
        }
    }

    private void SaveData()
    {
        var json = JsonSerializer.Serialize(applications, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(filePath, json);
    }

    public void AddApplication(string company, string position)
    {
        var app = new JobApplication
        {
            Id = nextId++,
            Company = company,
            Position = position,
            Status = "Applied"
        };

        applications.Add(app);
        SaveData();
        Console.WriteLine("Candidatura adicionada!");
    }

    public void ListApplications()
    {
        if (applications.Count == 0)
        {
            Console.WriteLine("Nenhuma candidatura cadastrada.");
            return;
        }

        foreach (var app in applications)
        {
            Console.WriteLine($"{app.Id} - {app.Company} | {app.Position} | {app.Status}");
        }
    }

    public void RemoveApplication(int id)
    {
        var app = applications.FirstOrDefault(a => a.Id == id);

        if (app != null)
        {
            applications.Remove(app);
            SaveData();
            Console.WriteLine("Candidatura removida!");
        }
        else
        {
            Console.WriteLine("ID não encontrado.");
        }
    }
    public void UpdateApplication(int id, string newStatus)
{
    var app = applications.FirstOrDefault(a => a.Id == id);

    if (app != null)
    {
        app.Status = newStatus;
        SaveData();
        Console.WriteLine("Status atualizado!");
    }
    else
    {
        Console.WriteLine("ID não encontrado.");
    }
}

}
