namespace ItStepHomework;

public class Menu
{
    /// <summary>
    /// Group :D
    /// </summary>
    private StudentsGroup Group { get; }

    /// <summary>
    /// Add student to group
    /// </summary>
    private delegate void Add(Student student);

    /// <summary>
    /// Remove student from group
    /// </summary>
    private delegate void Remove(int index);

    /// <summary>
    /// Show group name, course, amount of students 
    /// </summary>
    private delegate void Show();

    /// <summary>
    /// Public constructor with params
    /// </summary>
    /// <param name="group">group to use</param>
    public Menu(ref StudentsGroup group)
    {
        Group = new StudentsGroup(group);
    }
    /// <summary>
    /// Start menu in console.
    /// User should enter the digit from 0 to 3 to interact with it
    /// </summary>
    public void Start()
    {
        int value;
        do
        {
            value = OutputChoice();
        } while (value != 0);
    }
    
    /**
     * Returns user choice from console menu
     */
    private int OutputChoice()
    {
        Add add = Group.AddStudent;
        Remove remove = Group.RemoveStudent;
        Show show = Group.Show;

        Console.Clear();
        Console.WriteLine("~Menu~");
        Console.Write("1.Add Student\n2.Remove Student\n3.Show Student in Group\n0.Exit\n=> ");
        int value = int.Parse(Console.ReadLine());

        switch (value)
        {
            case 1:
                Console.Clear();
                add(Group.RandomStudentInfo());
                break;
            case 2:
                Console.Clear();
                show();
                Console.Write("\nEnter student's index: ");
                var index = int.Parse(Console.ReadLine());
                remove(index);
                break;
            case 3:
                Console.Clear();
                show();
                Thread.Sleep(10000);
                break;
        }

        return value;
    }
}