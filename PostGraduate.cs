namespace Project;

public class PostGraduate : Student
{
    public String DissertationTopic { get; set; }

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

    public override string ToString()
    {
        return base.ToString() + $"Dissertation topic: \"{DissertationTopic}\"";
    }
}