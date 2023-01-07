/*
    Lucas Fernando Gomez Carmona
    07/01/2022
    #1 Desafio entregable - Primeros pasos
    Creacion de Clases
 */
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    static void Main(string[] args)
    {
        
    }
}

public class User
{
    private int id;
    private string name;
    private string surname;
    private string username;
    private string password;
    private string mail;

    public User()
    {
        id = 0;
        name = String.Empty;
        surname = String.Empty;
        username = String.Empty;
        password = String.Empty;
        mail = String.Empty;
    }

    public User(int id, string name, string surname, string username, string password, string mail)
    {
        this.id = id;
        this.name = name;
        this.surname = surname;
        this.username = username;
        this.password = password;
        this.mail = mail;
    }

    public int Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public string Surname { get => surname; set => surname = value; }
    public string Username { get => username; set => username = value; }
    public string Password { get => password; set => password = value; }
    public string Mail { get => mail; set => mail = value; }
}

public class Product
{
    private int id;
    private string description;
    private double cost;
    private double price;
    private int stock;
    private int userId;

    public Product()
    {
        id = 0;
        description = String.Empty;
        cost = 0;
        price = 0;
        stock = 0;
        userId = 0;
    }

    public Product(int id, string description, double cost, double price, int stock, int userId)
    {
        this.id = id;
        this.description = description;
        this.cost = cost;
        this.price = price;
        this.stock = stock;
        this.userId = userId;
    }

    public int Id { get => id; set => id = value; }
    public string Description { get => description; set => description = value; }
    public double Cost { get => cost; set => cost = value; }
    public double Price { get => price; set => price = value; }
    public int Stock { get => stock; set => stock = value; }
    public int UserId { get => userId; set => userId = value; }
}

public class SoldProduct
{
    private int id;
    private int productId;
    private int stock;
    private int saleId;

    public SoldProduct()
    {
        id = 0;
        productId = 0;
        stock = 0;
        saleId = 0;
    }

    public SoldProduct(int id, int productId, int stock, int saleId)
    {
        this.id = id;
        this.productId = productId;
        this.stock = stock;
        this.saleId = saleId;
    }

    public int Id { get => id; set => id = value; }
    public int ProductId { get => productId; set => productId = value; }
    public int Stock { get => stock; set => stock = value; }
    public int SaleId { get => saleId; set => saleId = value; }
}

public class Sale
{
    private int id;
    private string comments;
    private int userId;

    public Sale()
    {
        id = 0;
        Comments = String.Empty;
        UserId = 0;
    }

    public Sale(int id, string comments, int userId)
    {
        this.Id = id;
        this.Comments = comments;
        this.UserId = userId;
    }

    public int Id { get => id; set => id = value; }
    public string Comments { get => comments; set => comments = value; }
    public int UserId { get => userId; set => userId = value; }
}