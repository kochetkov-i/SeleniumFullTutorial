using NUnit.Framework;
using SeleniumFullTutorial.Model;
using System;

namespace SeleniumFullTutorial.Tests
{
    [TestFixture]
    public class SortTests : AuthTestBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="count"> Указывает количество букв по которым проверяется сортировка, для сортировке по всем возможным
        /// буквам указать ноль или отрицательное значение</param>
        [TestCase(0)]
        public void AZCountrySortTest(int count)
        {
            app.Navigator.GoToAdminCountriesPage();
            var list = app.Sort.GetCountiesLists();
            Console.WriteLine($"Countries are sorted: {app.Sort.IsAZSorted(list.Item1.ToArray(), count)}");
            app.Sort.CheckZones(list.Item2, count);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="count"> Указывает количество букв по которым проверяется сортировка, для сортировке по всем возможным
        /// буквам указать ноль или отрицательное значение</param>
        [TestCase(0)]
        public void AZZonesSortTest(int count)
        {
            app.Navigator.GoToAdminZonesPage();
            var list = app.Sort.GetCountiesLists();
            app.Sort.CheckZones(list.Item2, count);
        }
    }
}
