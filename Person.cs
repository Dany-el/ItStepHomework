namespace ItStepHomework;

/// <summary>
/// My Date contains day, month, year (without any checking of right entering)
/// </summary>
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

public class Person
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public string Patronymic { get; set; }

    public MyDate Birthday { get; set; }

    public int Age
    {
        get
        {
            int year = Birthday.Year;
            int currentYear = DateTime.Now.Year;

            return currentYear - year;
        }
    }

    protected Person(string name, string surname, string patronymic,int day, int month, int year)
    {
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
        Birthday = new MyDate(day,month,year);
    }

    public override string ToString()
    {
        string info =
            $"Fullname: {Name} {Surname} {Patronymic}\n" +
            $"Birthday: {Birthday.Day}.{Birthday.Month}.{Birthday.Year}\n";
        
        return info;
    }
    
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