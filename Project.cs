namespace TaskSeven;

/// <summary>
/// A class representing a project.
/// </summary>
public class Project
{
	public readonly string Name;
	public readonly TechnicalSpecification TechnicalSpecification;
	/// <summary>
	/// A hashset of developers working on this project.
	/// </summary>
	public readonly HashSet<Developer> Developers;
	public readonly float Cost;

	public int HoursSpent = 0;

	public Project(string name,
				   TechnicalSpecification technicalSpecification,
				   HashSet<Developer> developers,
				   float cost)
	{
		Name = name;
		TechnicalSpecification = technicalSpecification;
		Developers = developers;
		Cost = cost;
		
		foreach (var dev in developers)
		{
			dev.CurrentProject = this;
		}
	}
}