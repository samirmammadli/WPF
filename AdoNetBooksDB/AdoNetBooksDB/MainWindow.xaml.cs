using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdoNetBooksDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Book> Books { get; set; }
        public BooksRepository repo { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            repo = new BooksRepository(@"Data Source=ADMINRG-SP93NVE;Initial Catalog=booksSQL;Integrated Security=True");
            DataContext = this;
            Books = new List<Book>();
            Books.Add(new Book("Salam", 1, "ay brat", DateTime.Now));
            Books = repo.GetBooksByCriterion("", "", "", 2001, 2001).ToList();
        }
    }

    public class Book
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Pressrun { get; set; }
        public DateTime Date { get; set; }

        public Book(string name, double price, string pressrun, DateTime date)
        {
            Name = name;
            Price = price;
            Pressrun = pressrun;
            Date = date;
        }
    }

    public interface IBooksRepository
    {
        string ConnectionString { get; set; }
        IEnumerable<Book> GetBooksByCriterion(string bookName, string price, string izd, int yearFrom, int yearTo);
    }

    public class BooksRepository : IBooksRepository
    {
        public string ConnectionString { get; set; }

        public BooksRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public IEnumerable<Book> GetBooksByCriterion(string bookName, string bookPrice, string bookIzd, int yearFrom, int yearTo)
        {
            string query = "select Name, Price, Izd, Date from Books where Name like @name" +
            " and price like @price" +
            " and izd like @izd" +
            " and year(Date) >= @from" +
            " and year(Date) <= @to";
            List<Book> books = new List<Book>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var sqlCommand = new SqlCommand(query, connection);

                var name = new SqlParameter("@name", $"%{bookName}%");
                var price = new SqlParameter("@price", $"%{bookPrice}%");
                var izd = new SqlParameter("@izd", $"%{bookIzd}%");
                var from = new SqlParameter("@from", $"{yearFrom}");
                var to = new SqlParameter("@to", $"{yearTo}");
                sqlCommand.Parameters.Add(name);
                sqlCommand.Parameters.Add(price);
                sqlCommand.Parameters.Add(izd);
                sqlCommand.Parameters.Add(from);
                sqlCommand.Parameters.Add(to);

                SqlDataReader data = sqlCommand.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        double.TryParse(data.GetDecimal(1).ToString(), out double result); 
                        books.Add(new Book(data.GetString(0), result, data.GetString(2), data.GetDateTime(3)));
                    }
                }
            }
            return books;
        }

    }
}
