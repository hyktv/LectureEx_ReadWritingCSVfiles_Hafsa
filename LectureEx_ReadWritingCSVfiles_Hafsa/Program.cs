namespace LectureEx_ReadWritingCSVfiles_Hafsa
{
    internal class Program
    {
        static List<Student> student = new List<Student>();
        static string csvFilePath = "students.csv";

        static void Main(string[] args)
        {
            //1 - CSV stands for "Comma-Separated Values."

            //2 -  the System.IO namespace or libraries like CsvHelper.

            //3 - For reading files: read, open, fopen, FileInputStream, StreamReader, etc.
            //For saving files: write, save, fwrite, FileOutputStream, StreamWriter, etc.

            //4 - FileMode.Append is used to open a file for writing at the end of the file if it exists and FileMode.OpenOrCreate is used to open a file if it exists; otherwise, it creates a new file.

            //5 -  a configuration or settings class


            bool exit = false;
            do
            {
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Save, Open, or Create");
                Console.WriteLine("3. Append to CSV");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        SaveOpenOrCreateMenu();
                        break;
                    case "3":
                        AppendToCSV();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (!exit);


        }

        static void AddStudent()
        {
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter grade: ");
            int grade = int.Parse(Console.ReadLine());

            student.Add(new Student { FirstName = firstName, LastName = lastName, Grade = grade });
        }

        static void SaveOpenOrCreateMenu()
        {
            Console.WriteLine("1. Save");
            Console.WriteLine("2. Open");
            Console.WriteLine("3. Create");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    SaveToCSV();
                    break;
                case "2":
                    OpenCSV();
                    break;
                case "3":
                    CreateCSV();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
        static void SaveToCSV()
        {
            using (StreamWriter sw = new StreamWriter(csvFilePath))
            {
                foreach (var student in student)
                {
                    sw.WriteLine($"{student.FirstName},{student.LastName},{student.Grade}");
                }
            }
            Console.WriteLine("CSV file saved successfully.");
        }

        static void OpenCSV()
        {
            if (File.Exists(csvFilePath))
            {
                using (StreamReader sr = new StreamReader(csvFilePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            else
            {
                Console.WriteLine("CSV file does not exist.");
            }
        }

        static void CreateCSV()
        {
            File.Create(csvFilePath).Close();
            Console.WriteLine("CSV file created successfully.");
        }

        static void AppendToCSV()
        {
            using (StreamWriter sw = new StreamWriter(csvFilePath, true))
            {
                foreach (var student in student)
                {
                    sw.WriteLine($"{student.FirstName},{student.LastName},{student.Grade}");
                }
            }
            Console.WriteLine("Data appended to CSV file successfully.");
        }

        static void SaveStudentsToCSV(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Student student in student)
                {
                    writer.WriteLine($"{student.FirstName},{student.LastName},{student.Grade}");
                }
            }
        }

        static List<Student> ReadStudentsFromCSV(string filePath)
        {
            List<Student> students = new List<Student>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    students.Add(new Student { FirstName = parts[0], LastName = parts[1], Grade = int.Parse(parts[2]) });
                }
            }
            return students;
        }

    }
}