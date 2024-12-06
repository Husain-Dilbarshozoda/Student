using Infastructure.Models;
using Infastructure.Services;
StudentService studentService = new StudentService();
for(;;)
{
    System.Console.WriteLine("1.Добавить студента\n2.Обновить студента\n3.Удалить Студента\n4.Вывести студента с помошью ID\n5.Вывести всех студентов\n6.Завершит работу");
    int n=Convert.ToInt32(Console.ReadLine());
    if(n==1)
    {
        Student student = new Student();
        System.Console.Write("Имя и вамилия студента: ");
        student.Fullname=Console.ReadLine();
        System.Console.Write("Возраст студента: ");
        student.Age=Convert.ToInt32(Console.ReadLine());
        System.Console.Write("Счёт: ");
        student.Score=Convert.ToDecimal(Console.ReadLine());
        bool res = studentService.InsertStudent(student);
         if(res==true)
         {
            System.Console.WriteLine("Успешное добавление!");
         }
         else 
         {
            System.Console.WriteLine("Неуспешное добавление!");
         }
    }
    else if(n==2)
    {
        Student student = new Student();
        System.Console.Write("Выведите id студента: ");
        student.Id=Convert.ToInt32(Console.ReadLine());
        System.Console.Write("Имя и фамилию студента: ");
        student.Fullname=Console.ReadLine();
        System.Console.Write("Возраст студента: ");
        student.Age=Convert.ToInt32(Console.ReadLine());
        System.Console.Write("Счёт студента: ");
        student.Score=Convert.ToDecimal(Console.ReadLine());
        bool res = studentService.UpdateStudent(student);
        if(res==true)
        {
            System.Console.WriteLine("Успешное обновление");
        }
        else 
        {
            System.Console.WriteLine("Неуспешное обновление");
        }
    }
    else if(n==3)
    {
        System.Console.Write("Введите Id студента: ");
        int m=Convert.ToInt32(Console.ReadLine());
        bool res = studentService.DeleteStudent(m);
        if(res==true)
        {
            System.Console.WriteLine("Успешное удаление");
        }
        else 
        {
            System.Console.WriteLine("Неуспешное удаление");
        }
    }
    else if(n==4)
    {
        System.Console.Write("Введите Id студента: ");
        int m=Convert.ToInt32(Console.ReadLine());
        Student student = studentService.GetStudentById(m);
        System.Console.WriteLine($"Fullname: {student.Fullname} || Age: {student.Age} || Score: {student.Score}");
    }
    else if(n==5)
    {
        List<Student> students = studentService.GetStudents();
        for(int i=0;i<students.Count;i++)
        {
         System.Console.WriteLine($"Fullname: {students[i].Fullname} || Age: {students[i].Age} || Score: {students[i].Score}");   
        }
    }
    else if(n==6)
    {
        return;
    }

}
