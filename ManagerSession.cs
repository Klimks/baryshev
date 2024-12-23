namespace TaskSeven;

/// <summary>
/// A class responsible for running
/// a manager's session.
/// </summary>
public class ManagerSession : UserSession
{
	public ManagerSession(User user) : base(user)
	{
		CommandsToActions.Add("see-tech-spec", SeeTechnicalSpecifications);
		CommandsToActions.Add("developer-status", SeeDeveloperStatus);
		CommandsToActions.Add("create-project", CreateProject);
	}

	protected override List<string> CommandExplanations { get; } =
	[
		"\"see-tech-spec\" - List new technical specifications.",
		"\"developer-status\" - List all developers and whether they are currently working on a project.",
		"\"create-project\" - Begin creating a project."
	];

	private void SeeTechnicalSpecifications()
	{
		Console.WriteLine("Current technical specifications:");
		Utils.WriteDashLine();
		var list = SystemState.TechnicalSpecifications.Values.ToList();
		for (int i = 0; i < list.Count; i++)
		{
			Console.WriteLine(list[i].ToString());
			if (i != list.Count - 1)
			{
				Utils.WriteDashLine();
			}
		}
	}

	private void SeeDeveloperStatus()
	{
		Console.WriteLine("Developers:");
		foreach (var dev in SystemState.Developers.Values)
		{
			Console.WriteLine($"{dev}");
		}
	}

	private void CreateProject()
	{
		Console.WriteLine("Select technical specification: ");
		var techSpecs = SystemState.TechnicalSpecifications.ToList();
		for (int i = 0; i < techSpecs.Count; i++)
		{
			Console.WriteLine($"{i}: {techSpecs[i].Key}");
		}
		
		Console.Write($"Type [0-{techSpecs.Count - 1}] to select the technical specification: ");

		int input = Utils.ReadLineInt();
		var techSpec = techSpecs[input];
		
		Console.WriteLine();

		Console.WriteLine("Select developers: ");
		var devs = SystemState.Developers.Values.ToList();
		for (int i = 0; i < devs.Count; i++)
		{
			Console.WriteLine($"{i}: {devs[i]}");
		}

		Console.WriteLine($"Type [0-{devs.Count - 1}] to select a developer");
		HashSet<Developer> developers = new(techSpec.Value.RequiredDevCount);
		for (int i = 0; i < techSpec.Value.RequiredDevCount; i++)
		{
			Console.Write($"({i + 1}/{techSpec.Value.RequiredDevCount}): ");
			input = Utils.ReadLineInt();
			if (developers.Contains(devs[input]))
			{
				Console.WriteLine("Error: developer already selected");
				i--;
				continue;
			}
			developers.Add(devs[input]);
		}
		
		Console.WriteLine();

		Console.Write("Please set the cost of the project: ");
		float cost = Utils.ReadLineSingle();

		Project project = new
		(
			techSpec.Key,
			techSpec.Value,
			developers,
			cost
		);

		SystemState.UploadProject(project);
		Console.WriteLine("Project successfully created!");
	}
}