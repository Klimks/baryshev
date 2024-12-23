namespace TaskSeven;

/// <summary>
/// A class responsible for running a
/// client's session.
/// </summary>
public class ClientSession : UserSession
{
	public ClientSession(User user) : base(user)
	{
		CommandsToActions.Add("present-tech-spec", PresentTechnicalSpecification);
	}

	protected override List<string> CommandExplanations { get; } =
	[
		"\"present-tech-spec\" - Begin presenting a technical specification"
	];

	private void PresentTechnicalSpecification()
	{
		Console.Write("Please enter the project name: ");
		string projectName = Utils.NonNullReadLine();
		
		Console.Write("Please enter the required qualifications: ");
		string qualifications = Utils.NonNullReadLine();
		
		Console.Write("Please enter the required number of developers: ");
		int devCount = Utils.ReadLineInt();

		TechnicalSpecification technicalSpecification = new(projectName, qualifications, devCount);
		SystemState.UploadTechnicanSpecification(technicalSpecification);
		Console.WriteLine("Successfully uploaded a technical specification!");
	}
}