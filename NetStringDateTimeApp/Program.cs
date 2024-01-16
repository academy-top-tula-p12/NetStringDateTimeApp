using System.Text;
using System.Text.RegularExpressions;

var months = new string[]
{
    "", "Январь", "Февраль", "Март", "Апрель"
};

DateTime dateTime = new(2021, 10, 23, 13, 45, 22);
DateTime dateNow = DateTime.Now;
DateTime dateNowUtc = DateTime.UtcNow;
DateTime dateNowDay = DateTime.Today;

Console.WriteLine(dateTime.ToString());
Console.WriteLine(dateNow.ToString());
Console.WriteLine(dateNowUtc.ToString());
Console.WriteLine(dateNowDay.ToString());

TimeSpan timeSpan = new(5, 7, 20, 5);

Console.WriteLine(dateNow.Add(-timeSpan));
Console.WriteLine(dateNow.AddDays(2.5));
Console.WriteLine(dateNow.AddHours(-2.5));
Console.WriteLine(dateNow.AddMonths(3));
Console.WriteLine(dateNow.AddYears(-15));
Console.WriteLine(dateNow.AddSeconds(3600));

var interval = dateNow.Subtract(dateTime);
Console.WriteLine(interval);

Console.WriteLine(new String('*', 20));

Console.WriteLine(dateNow.ToString());

Console.WriteLine(dateNow.ToLocalTime());
Console.WriteLine(dateNow.ToUniversalTime());

Console.WriteLine(dateNow.ToLongDateString());
Console.WriteLine(dateNow.ToLongTimeString());

Console.WriteLine(dateNow.ToShortDateString());
Console.WriteLine(dateNow.ToShortTimeString());

Console.WriteLine(new String('*', 20));



Console.WriteLine($"D: {dateNow.ToString("D")}");
Console.WriteLine($"d: {dateNow.ToString("d")}");
Console.WriteLine($"D: {dateNow:D}");
Console.WriteLine($"d: {dateNow:d}");

Console.WriteLine($"F: {dateNow:F}");
Console.WriteLine($"f: {dateNow:f}");

Console.WriteLine($"G: {dateNow:G}");
Console.WriteLine($"g: {dateNow:g}");

var month = dateNow.ToString("M").Substring(3);
Console.WriteLine($"Month: {months[dateNow.Month]}");

Console.WriteLine($"M: {dateNow:M}");
Console.WriteLine($"m: {dateNow:m}");

Console.WriteLine($"O: {dateNow:O}");
Console.WriteLine($"o: {dateNow:o}");

Console.WriteLine($"R: {dateNow:R}");
Console.WriteLine($"s: {dateNow:s}");

Console.WriteLine($"T: {dateNow:T}");
Console.WriteLine($"t: {dateNow:t}");

Console.WriteLine($"U: {dateNow:U}");
Console.WriteLine($"u: {dateNow:u}");

Console.WriteLine($"Y: {dateNow:Y}");
Console.WriteLine($"yy: {dateNow:yy}");
Console.WriteLine($"yyyy: {dateNow:yyyy}");

Console.WriteLine($"mm|dd|yyyy: {dateNow:MM|dd|yyyy}");
Console.WriteLine($"dd: {dateNow:dd}");
Console.WriteLine($"ddd: {dateNow:ddd}");
Console.WriteLine($"dddd: {dateNow:dddd}");
Console.WriteLine($"g: {dateNow:g}");
Console.WriteLine($"gg: {dateNow:gg}");

Console.WriteLine($"M: {dateNow:M}");
Console.WriteLine($"MM: {dateNow:MM}");
Console.WriteLine($"MMM: {dateNow:MMM}");
Console.WriteLine($"MMMM: {dateNow:MMMM}");

DateTime date1 = DateTime.Parse("25.11.1985");
Console.WriteLine(date1.ToString());

string numStr = "123";

if(int.TryParse(numStr, out int numInt))
    Console.WriteLine(numInt);

Convert.ToInt32(numStr);


void RegexExample()
{
    string[] phones = new[]
{
    @"+7 (999) 123-44-55", //
    @"+27 (113) 23-44-55",
    @"+7 (999) 123 44 55", //
    @"+ (999) 123-44-55",
    @"+7(999)123-44-55", //
    @"+3447 (999) 123-44-55",
    @"+7 (9299) 123-44-55",
    @"+7(555)1234455", //
};

    string str = "ехал Грека через реку, видит Грека в реке рак, сунул Грека руку в реку, рак за руку Грека - цап";
    string strDate = "10.05.1999 00.11.2001 21.13.2011 12.07.1867 33.06.2023";
    /*
    . - один любой символ
    \. - символ точка
    [ае] - один из символов а или е
    [аеo] - один из символов а или е или о
    [a-z\-] - все символы от a до z
    [d-r] - все символы от d до r

    */


    string pattern = @"р[а-яА-Я^ьъй]к\w*";
    string yearPattern = @"(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.[1-2][09][0-9][0-9]";
    string yearPatEasy = @"\d{2}\.\d{2}\.\d{2,4}";
    string varPattern = @"^[\w^\d]\w*_$";

    string phonePattern = @"^\+\d{1,3}\s*\(\d{3}\)\s*\d{3}[\-\s]*\d{2}[\-\s]*\d{2}";

    //Regex regex = new Regex(yearPattern, RegexOptions.IgnoreCase);

    //MatchCollection matches = regex.Matches(strDate);

    //if(matches.Count > 0)
    //{
    //    foreach(Match match in matches)
    //        Console.WriteLine(match.Value);
    //}
    //else
    //    Console.WriteLine("Matchaes not found");

    Regex regex = new(phonePattern);
    foreach (var phone in phones)
        if (Regex.IsMatch(phone, phonePattern, RegexOptions.IgnoreCase))
        {
            Console.WriteLine($"{phone} | {new Regex(@"\D*").Replace(phone, "")}");
        }
}

/*
void StringBuilderExample()
{
    StringBuilder sb = new StringBuilder("Hello");
    Console.WriteLine(sb.Length);
    Console.WriteLine(sb.Capacity);
    sb.Append("World");
    sb.Insert(5, " Happy ");
    sb.Remove(3, 5);
    sb.Replace('l', '*');

    string s = sb.ToString();
    Console.WriteLine(s);

    StringBuilder s1 = new("hello");
    s1.Append(" world");

    do
    {
        Console.Write("Input str: ");
        var str = Console.ReadLine();
        if (str == "~")
            break;
        s1.Append(str);
        Console.WriteLine($"Length: {s1.Length}, Capacity: {s1.Capacity}");
    } while (true);

    Console.WriteLine(s1.ToString());
}
void StringExample()
{
    string s1 = "Hello";
    string s2 = new string("Hello");
    string s3 = new string('*', 10);
    string s4 = new string(new char[] { 'H', 'e', 'l', 'l', 'o' });
    string s5 = new string(new char[] { 'H', 'e', 'l', 'l', 'o' }, 1, 3);
    Console.WriteLine(s1);
    Console.WriteLine(s2);
    Console.WriteLine(s3);
    Console.WriteLine(s4);
    Console.WriteLine(s5);

    for (int i = 0; i < s1.Length; i++)
        Console.Write(s1[i]);

    Console.WriteLine(s3);

    foreach (char c in s1)
        Console.Write(c);

    Console.WriteLine(s3);

    string file = "file.txt";
    string path = @$"D:\folder1\{file}";

    string multiLine = """
    lkfasdlfkasd
    asdfasdf asd
        asdf asdf
    sadf asdfasd fas
    asdf asd fasdf as
    """;
    Console.WriteLine(multiLine);
}
*/

