namespace Project;

public class Person
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public string Patronymic { get; set; }

    public DateTime Birthday { get; set; }

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
        Birthday = new DateTime(year,month,day);
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
            Birthday = new(year, month, day);
        }
        else
        {
            throw new Exception("Argument is out of range");
        }
    }
}