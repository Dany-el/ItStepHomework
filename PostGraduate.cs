namespace ItStepHomework;

public class PostGraduate : Student
{
    /// <summary>
    /// Topic of dissertation
    /// </summary>
    public String DissertationTopic { get; set; }

    /// <summary>
    /// Constructor with|out params
    /// </summary>
    /// <param name="name">firstname</param>
    /// <param name="surname">lastname</param>
    /// <param name="patronymic">patronymic</param>
    /// <param name="phoneNumber">phone number</param>
    /// <param name="homeAddress">home address</param>
    /// <param name="year">year of birth</param>
    /// <param name="month">month of birth</param>
    /// <param name="day">day of birth</param>
    /// <param name="finalExamsAmount">amount of final exams</param>
    /// <param name="termPapersAmount">amount of term papers</param>
    /// <param name="creditsAmount">amount of credits</param>
    /// <param name="finalExamGrades">final exams grades</param>
    /// <param name="termPapersGrades">term papers grades</param>
    /// <param name="creditsGrades">credits grades</param>
    /// <param name="dissertationTopic">dissertation topic</param>
    public PostGraduate(string name = "Undefined", string surname = "Undefined",
        string patronymic = "Undefined", string phoneNumber = "Undefined", string homeAddress = "Undefined",
        int year = 1, int month = 1, int day = 1, int finalExamsAmount = 1, int termPapersAmount = 1,
        int creditsAmount = 1, int[]? finalExamGrades = null, int[]? termPapersGrades = null,
        int[]? creditsGrades = null, string dissertationTopic = "Topic") :
        base(name, surname, patronymic,
            phoneNumber, homeAddress,
            year, month, day,
            finalExamsAmount, termPapersAmount, creditsAmount,
            finalExamGrades, termPapersGrades, creditsGrades)
    {
        DissertationTopic = dissertationTopic;
    }

    /// <summary>
    /// Transform student's data to string 
    /// </summary>
    /// <returns>converted data</returns>
    public override string ToString()
    {
        return base.ToString() + $"Dissertation topic: \"{DissertationTopic}\"";
    }
}