using amdLINQ;
using System;
using System.ComponentModel.Design;
using System.Security.Cryptography;

var students = new List<Student>
{
    new Student { Id=1, Name = "Anton Raul", Nationality="Romanian", Debt = 0},
    new Student { Id=2, Name = "Voica Vlad", Nationality = "American", Debt = 100},
    new Student { Id=3, Name = "Branza Alex", Nationality = "Bulgarian", Debt = 50},
    new Student { Id=4, Name = "Moisa Tudor", Nationality = "English", Debt = 200},
    new Student { Id=5, Name = "Anton Bianca", Nationality = "Romanian", Debt = 70}
};

// filtering operators

var filteredStudents = students.Where(p =>
{
    return p.Name.Contains("Anton");
});

Console.WriteLine("Our students are:");
foreach (Student student in filteredStudents.ToList()) // conversion method ToList()
{
    Console.WriteLine(student.ToString());
}


// project operators

var selectedStudents = students.Select(p => p.Name);

Console.WriteLine();
Console.WriteLine("Our selected students names are:");
foreach (string studentName in selectedStudents.ToList())
{
    Console.WriteLine(studentName);
}


// Joins

IList<Cars> carList = new List<Cars>()
{
    new Cars {CarId = 1, CarName = "Awesome Car", CarSecurityCode=23},
    new Cars {CarId = 2, CarName = "Okey Car", CarSecurityCode = 67},
    new Cars {CarId = 3, CarName = "I'm not good with cars", CarSecurityCode = 99}
};

IList<Security> securityList = new List<Security>()
{
    new Security {CarSecurityCode = 23, SecurityCodeName="Awesome Security"},
    new Security {CarSecurityCode = 67, SecurityCodeName="Alright Security"},
    new Security {CarSecurityCode = 99, SecurityCodeName="Okeymage"}
};

Cars car = carList.First(); // element operator
Security security = securityList.First(); // element operator

var innerJoin = carList.Join(
    securityList,
    car => car.CarSecurityCode,
    security => security.CarSecurityCode,
    (car, security) => new
    {
        CarName = car.CarName,
        SecurityCodeName = security.SecurityCodeName
    });

foreach (var v in innerJoin.ToList())
{
    Console.WriteLine(v);
}


// Order By

var orderedBy = from s in students where s.Nationality == "Romanian" orderby s.Debt select s;

Console.WriteLine();
Console.WriteLine("The order by debt of students with the nationality romanian is:");
foreach (Student s in orderedBy.ToList())
{
    Console.WriteLine(s.ToString());
}


// Group By

var groupedStudents = from s in students group s by s.Debt;

Console.WriteLine();
foreach (var debtGroup in groupedStudents.ToList())
{
    Console.WriteLine("Debt group {0}", debtGroup.Key);
    foreach (Student s in debtGroup)
    {
        Console.WriteLine(s.ToString());
    }
}


// Set operators

var students2 = new List<Student>
{
    new Student { Id=1, Name = "Caia Anton", Nationality="Romanian", Debt = 10},
    new Student { Id=2, Name = "Barlea Alex", Nationality = "Bulgarian", Debt = 110},
    new Student { Id=3, Name = "Chifor Bogdan", Nationality = "American", Debt = 60},
    new Student { Id=4, Name = "Grigor Andrei", Nationality = "Romanian", Debt = 210},
    new Student { Id=5, Name = "Maxim Georgiana", Nationality = "English", Debt = 80}
};

var concatStudents = students.Concat(students2);

Console.WriteLine();
Console.WriteLine("The final list of student is:");
foreach (Student s in concatStudents)
{
    Console.WriteLine(s.ToString());
}


// LINQ aggregation methods

int overallDebt = concatStudents.Sum(student => student.Debt);

Console.WriteLine();
Console.WriteLine("The overall debt of all the students is {0}", overallDebt);


// LINQ quantifiers

string name = "Paul Sina";

var containsStudent = (from s in concatStudents select s.Name).Contains(name);

Console.WriteLine();
if (containsStudent)
    Console.WriteLine("The list of students list contains the name {0}", name);
else
    Console.WriteLine("The list of students list doesn't contain the name {0}",name);


// LiNQ generation methods

IEnumerable<int> numberSequence = Enumerable.Range(1, 10);

Console.WriteLine();
Console.WriteLine("The range generated is:");
foreach (int i in numberSequence)
{
    Console.Write(i + " ");
}

