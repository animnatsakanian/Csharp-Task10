using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace LocalDataStorageApp
{
    public partial class MainWindow : Window
    {
        private readonly List<Person> _people;
        private int _currentIndex;

        public MainWindow()
        {
            InitializeComponent();
            _people = new List<Person>();
            _currentIndex = 0;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(IdTextBox.Text);
            string name = NameTextBox.Text;
            int age = int.Parse(AgeTextBox.Text);

            _people.Add(new Person { Id = id, Name = name, Age = age });
            _currentIndex++;

            RefreshListBox();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            int idToRemove = int.Parse(IdTextBox.Text);

            var personToRemove = _people.FirstOrDefault(p => p.Id == idToRemove);
            if (personToRemove != null)
            {
                _people.Remove(personToRemove);
                _currentIndex--;
                RefreshListBox();
            }
            else
            {
                MessageBox.Show($"Record with ID {idToRemove} not found.");
            }
        }

        private void SearchByNameButton_Click(object sender, RoutedEventArgs e)
        {
            string nameToSearch = NameTextBox.Text;
            var results = _people.Where(p => p.Name == nameToSearch);

            DisplaySearchResults(results);
        }

        private void SearchByAgeButton_Click(object sender, RoutedEventArgs e)
        {
            int ageToSearch = int.Parse(AgeTextBox.Text);
            var results = _people.Where(p => p.Age == ageToSearch);

            DisplaySearchResults(results);
        }

        private void SortByNameButton_Click(object sender, RoutedEventArgs e)
        {
            var sortedPeople = _people.OrderBy(p => p.Name);
            DisplaySortedResults(sortedPeople);
        }

        private void SortByAgeButton_Click(object sender, RoutedEventArgs e)
        {
            var sortedPeople = _people.OrderBy(p => p.Age);
            DisplaySortedResults(sortedPeople);
        }

        private void DisplaySearchResults(IEnumerable<Person> results)
        {
            ResultListBox.Items.Clear();
            foreach (var person in results)
            {
                ResultListBox.Items.Add(person);
            }
        }

        private void DisplaySortedResults(IEnumerable<Person> sortedPeople)
        {
            ResultListBox.Items.Clear();
            foreach (var person in sortedPeople)
            {
                ResultListBox.Items.Add(person);
            }
        }

        private void RefreshListBox()
        {
            ResultListBox.Items.Clear();
            foreach (var person in _people)
            {
                ResultListBox.Items.Add(person);
            }
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name}, {Age}";
        }
    }
}
