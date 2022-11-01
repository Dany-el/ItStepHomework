namespace ItStepHomework;

/// <summary>
/// My Date contains day, month, year (without any checking of right entering)
/// </summary>
[Serializable]
public struct MyDate
{
    public int Day { get; private set; }
    public int Month { get; private set; }
    public int Year { get; private set; }
    
    public MyDate(int day = 10, int month = 10, int year = 1991)
    {
        Day = day;
        Month = month;
        Year = year;
    }
}

[Serializable]
public class Person
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public string Patronymic { get; set; }

    public MyDate Birthday { get; set; }

    /// <summary>
    /// Returns current full age of person
    /// </summary>
    public int Age
    {
        get
        {
            int year = Birthday.Year;
            int currentYear = DateTime.Now.Year;

            return currentYear - year;
        }
    }

    /// <summary>
    /// Default Constructor with params 
    /// </summary>
    /// <param name="name">firstname</param>
    /// <param name="surname">lastname</param>
    /// <param name="patronymic">patronymic</param>
    /// <param name="day">day of birth</param>
    /// <param name="month">month of birth</param>
    /// <param name="year">year of birth</param>
    protected Person(string name, string surname, string patronymic,int day, int month, int year)
    {
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
        Birthday = new MyDate(day,month,year);
    }

    /// <summary>
    /// Overrides to show person data
    /// such as firstname, date of birth etc.
    /// </summary>
    /// <returns>string variable with person data</returns>
    public override string ToString()
    {
        string info =
            $"Fullname: {Name} {Surname} {Patronymic}\n" +
            $"Birthday: {Birthday.Day}.{Birthday.Month}.{Birthday.Year}\n";
        
        return info;
    }
    
    /// <summary>
    /// Sets birthday of person
    /// </summary>
    /// <param name="day">day of birth</param>
    /// <param name="month">month of birth</param>
    /// <param name="year">year of birth</param>
    /// <exception cref="Exception">User entered wrong data</exception>
    public void SetBirthday(int day, int month, int year)
    {
        if (day is > 0 and <= 31 && month is > 0 and <= 12)
        {
            Birthday = new(day, month, year);
        }
        else
        {
            throw new Exception("Argument is out of range");
        }
    }
}