using System.Collections.Generic;
using System.Linq;

public class JohnMeeting
{
    public static string Meeting(string s)
    {
        var list = s.ToUpper()
        .Split(';')
        .Select(x => x.Split(':'))
        .OrderBy(x => x[1])
        .ThenBy(x => x[0])
        .Select(x => string.Format("({0}, {1})", x[1], x[0]))
        .ToList();
        return string.Join("", list);
    }
}