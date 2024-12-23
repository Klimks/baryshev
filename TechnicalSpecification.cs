namespace TaskSeven;

public class TechnicalSpecification(string projectName,
									string requiredQualification,
									int requiredDevCount)
{
	public readonly string ProjectName = projectName;
	public readonly string RequiredQualifications = requiredQualification;
	public readonly int RequiredDevCount = requiredDevCount;

	public override string ToString()
	{
		return $"""
				"{ProjectName}"
				Required developer qualifications: {RequiredQualifications}
				Required developer count: {RequiredDevCount}
				""";
	}
}