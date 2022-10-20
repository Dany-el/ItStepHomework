using System.Text.RegularExpressions;

namespace ItStepHomework;

public class Menu
{
    private StudentsGroup Group { get; }

    // Пришлось создавать для каждого метода свой делегат
    private delegate void Add(Student student);
    private delegate void Remove(int index);
    private delegate void Show();

    public Menu(ref StudentsGroup group)
    {
        Group = new StudentsGroup(group);
    }
    
    public void Start()
    {
        Add add = Group.AddStudent;
        Remove remove = Group.RemoveStudent;
        Show show = Group.Show;
        
        int value;
        do
        {
            Console.Clear();
            Console.WriteLine("~Menu~");
            Console.Write("1.Add Student\n2.Remove Student\n3.Show Student in Group\n0.Exit\n=> ");
            value = int.Parse(Console.ReadLine());
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
                    int index = int.Parse(Console.ReadLine());
                    remove(index);
                    break;
                case 3:
                    Console.Clear();
                    show();
                    Thread.Sleep(10000);
                    break;
            }
        } while (value != 0);
    }
}