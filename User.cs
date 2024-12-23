namespace TaskSeven;

/// <summary>
/// A class that contains basic information about the user.
/// </summary>
/// <param name="_login"></param>
public class User(string _login)
{
	public readonly string Login = _login;
}