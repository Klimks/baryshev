namespace TaskSeven;

/// <summary>
/// A class responsible for running
/// a developer's session.
/// </summary>
public class DeveloperSession : UserSession
{
	public DeveloperSession(Developer _developer) : base(_developer)
	{
		CommandsToActions.Add("set-hours", SetHours);
		developer = _developer;
	}

	private readonly Developer developer;

	protected override List<string> CommandExplanations { get; } =
	[
		"\"set-hours\" - Sets the hours spent on a project."
	];

	private void SetHours()
	{
		if (developer.CurrentProject is null)
		{
			Console.WriteLine("Error: you are not working on any project.");
			return;
		}
		Console.Write("Please enter the hour count: ");
		var input = Utils.ReadLineInt();
		developer.CurrentProject.HoursSpent += input;
		Console.WriteLine("Successfully set spent hour count!");
	}
}