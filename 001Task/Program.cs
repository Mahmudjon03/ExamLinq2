using _001Task;
using _001Task.Data;
using System.Threading.Channels;

await using var dataContext = new DataContext();


Console.WriteLine(" Good look 😊😊😊 ");

//1
//Напишите запрос LINQ, чтобы получить всех людей, живущих в городе с населением более 3 человек.
//Write a LINQ query to retrieve all the people who live in a city with a population greater than 3 
var res1 = from ci in dataContext.Cities
           join p in dataContext.Peoples on ci.Id equals p.CityId
           where ci.Population > 3000000  
           select new
           {
               City=ci,
               Peoples=ci.Peoples

           };

foreach (var item in res1)
{
    Console.WriteLine(item.City.Name);
    foreach (var item1 in item.Peoples)
    {
        Console.WriteLine(item1.FirstName+" "+item1.LastName);
      
    }
    break;
}

//2
//Получите все города со средней численностью населения в соответствующей стране
//Retrieve all cities with their respective country's average population
//var res2= from c in dataContext.Cities
Console.WriteLine("-----------------------------------");
var res2 = from ci in dataContext.Cities
           select new
           {
               City = ci.Name,
               population=ci.Population
           };
foreach (var item in res2)
{
    Console.WriteLine(item.City+" "+item.population);
   
}
Console.WriteLine("------------------------------------");
//3
//Получите города с самым высоким населением в каждой стране
//Retrieve the cities with the highest population in each country
Console.WriteLine();
int max = dataContext.Cities.Select(c => c.Population).Max();
Console.WriteLine(max+"  ");

var res3 = from ci in dataContext.Cities
           where ci.Population == max
           select ci;
foreach (var item in res3)
{
    Console.WriteLine(item.Name);
}




Console.WriteLine("---------------------------------");
//4
//Получите среднее население городов в каждой стране
//Retrieve the average population of cities in each country



         

//5
//Получить все города, в которых есть человек по имени "Марк".
//Retrieve all cities that have a person with by name "Mark"
Console.WriteLine("----------------------------");
var res5 = from p in dataContext.Peoples
           join c in dataContext.Cities on p.CityId equals c.Id
           where p.FirstName == "Mark"
           select new
           {
               city=c.Name
           };
foreach (var item in res5)
{
    Console.WriteLine(item.city);
}
Console.WriteLine("-------------------------");



//6
//Получить всех людей вместе с соответствующими названиями городов и стран
//Retrieve all people along with their associated city and country names

var res6 = from c in dataContext.Countries
           join ci in dataContext.Cities on c.Id equals ci.CountryId
           join p in dataContext.Peoples on ci.Id equals p.CityId
           select new
           {
               Countries = c.Name,
               city = ci.Name,
               People = c.Cities.Select(c=>c.Peoples)
           };

int n=0;
foreach (var item in res6)
{
    Console.WriteLine(item.Countries+"  "+item.city);
    n++;
   
    foreach (var item1 in item.People.First())
    {
        Console.WriteLine(item1.FirstName);
    }
   
   
    
}
Console.WriteLine("7--------------------------------");
//7
//Получите все города вместе с соответствующими названиями стран, используя свойство навигации
//Retrieve all cities along with their associated country names using a navigation property

//8
//Получить всех людей вместе с связанными с ними городом и страной.
//Retrieve all people along with their associated city and country 
Console.WriteLine("===================================");
var res8 = from c in dataContext.Countries
           join ci in dataContext.Cities on c.Id equals ci.CountryId
           join p in dataContext.Peoples on ci.Id equals p.CityId
           select new
           {
               name=c.Cities.SelectMany(c=>c.Peoples.SelectMany(c=>c.FirstName)),
               city=c.Cities.Select(c=>c.Name),
               contry=c.Name
           };

         
//9
//Получить всех людей, живущих в "USA".
//Retrieve all people living in  "USA".

var res9 = from c in dataContext.Countries
           join ci in dataContext.Cities on c.Id equals ci.CountryId
           join p in dataContext.Peoples on ci.Id equals p.CityId
           where c.Name == "USA"
           select new
           {
               people=p

           };
    foreach (var item in res9)
    {
    Console.WriteLine(item.people.FirstName+" "+item.people.LastName);
}
//10
//Получить всех людей вместе с соответствующим населением города и страны
//Retrieve all people along with their associated city and country populations 





