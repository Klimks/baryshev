namespace TaskSeven;

public class Developer(string _login,
					   string qualification) : User(_login)
{
	public readonly string Qualification = qualification;

	public Project? CurrentProject;

	public override string ToString()
	{
		return $"{Login}: {Qualification}, {(CurrentProject is not null ? "Working" : "Not working")}";
	}
}