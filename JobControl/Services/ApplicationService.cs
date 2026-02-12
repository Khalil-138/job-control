using JobControl.Models;

namespace JobControl.Services;

public class ApplicationService
{
    private List<JobApplication> applications = new();
    private int nextId = 1;

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
            Console.WriteLine("Candidatura removida!");
        }
        else
        {
            Console.WriteLine("ID não encontrado.");
        }
    }
}
