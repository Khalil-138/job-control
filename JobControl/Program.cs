using JobControl.Services;

var service = new ApplicationService();

while (true)
{
    Console.WriteLine("\n=== Job Control ===");
    Console.WriteLine("1 - Adicionar candidatura");
    Console.WriteLine("2 - Listar candidaturas");
    Console.WriteLine("3 - Remover candidatura");
    Console.WriteLine("0 - Sair");

    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            Console.Write("Empresa: ");
            var company = Console.ReadLine() ?? "";

            Console.Write("Vaga: ");
            var position = Console.ReadLine() ?? "";

            service.AddApplication(company, position);
            break;

        case "2":
            service.ListApplications();
            break;

        case "3":
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            service.RemoveApplication(id);
            break;

        case "0":
            return;
    }
}
