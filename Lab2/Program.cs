using System.Net.Security;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab2
{
    public class Auth()
    {
        public string _login;
        string _password;
        string _buffer;
        StreamReader _streamReader = new StreamReader("D:\\Labs\\PromProg\\Lab2\\users.txt");

        void WriteData()
        {
            Console.WriteLine("Введите логин и пароль");
            _login = Console.ReadLine();
            _password = Console.ReadLine();
        }
        void CheckData()
        {
            while(string.IsNullOrWhiteSpace(_login) || string.IsNullOrWhiteSpace(_password))//на второй попытке авторизации инста входит, без проверок
            {
                Console.WriteLine("Недопустим ввод пустых строк");
                WriteData();
            }
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] data = sha256.ComputeHash(Encoding.UTF8.GetBytes(_password));
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    stringBuilder.Append(data[i].ToString("x2"));
                }
                _password = stringBuilder.ToString();
            }
            while (!_streamReader.EndOfStream)
            {
                _buffer = _streamReader.ReadLine();//proverka login+pass
                while(_buffer != (_login + ":" + _password))//net proverki na null
                {
                    Console.WriteLine("Неправильный логин или пароль");
                    WriteData();
                }
            }
        }
        public void Autotization()
        {
            WriteData();
            CheckData();
            _streamReader.Close();
        }
    }

    class Reg()
    {
        string _buffer;
        public string _login;
        string _password;
        bool _check;
        void WriteData()
        {
            Console.WriteLine("Введите логин");
            _login = Console.ReadLine();
            Console.WriteLine("Введите пароль");
            _password = Console.ReadLine();
        }
        void CheckData()
        {
            StreamReader _streamReader = new StreamReader("D:\\Labs\\PromProg\\Lab2\\users.txt");

            while (string.IsNullOrWhiteSpace(_login) || string.IsNullOrWhiteSpace(_password))//на второй попытке авторизации инста входит, без проверок
            {
                Console.WriteLine("Недопустим ввод пустых строк");
                WriteData();
            }
            while (!_streamReader.EndOfStream)
            {
                _buffer = _streamReader.ReadLine();
                Match match = Regex.Match(_buffer, @":");
                if( _login.Equals(match))
                {
                    Console.WriteLine("Такой логин уже используется");
                    WriteData();                                        //если есть такой логин
                    _streamReader.Close();
                    return;
                }
            }
            _streamReader.Close();
        }
        
        public void Register()
        {
            WriteData();
            CheckData();
            StreamWriter _streamWriter = new StreamWriter("D:\\Labs\\PromProg\\Lab2\\users.txt");
            using(SHA256 sha256 = SHA256.Create())
            {
                byte[] data = sha256.ComputeHash(Encoding.UTF8.GetBytes(_password));
                StringBuilder stringBuilder = new StringBuilder();
                for(int i =0; i < data.Length; i++)
                {
                    stringBuilder.Append(data[i].ToString("x2"));
                }
                _password = stringBuilder.ToString();
            }
            _streamWriter.WriteLine(_login+":"+_password);
            _streamWriter.Close();
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте! Вы запустили тест на банан. Чтобы пройти тест, вам нужно авторизоваться.");
            Console.WriteLine("1. Авторизация");
            Console.WriteLine("2. Регистрация");
            int num = Convert.ToInt16(Console.ReadLine());
            string login = null;
            
            switch(num)
            {
                case 1:
                    Auth auth = new Auth();
                    auth.Autotization();
                    login = auth._login;
                    break;
                case 2:
                    Reg reg = new Reg();
                    reg.Register();
                    login = reg._login;
                    break;
                default: 
                    Console.WriteLine("Неправильный выбор...");
                    break;
            }
            Console.WriteLine("Вы успешно авторизовались как " + login);
            if (login.Contains("banana") || login.Contains("Banana"))// v ideale dictionary nada
            {
                Console.WriteLine("Вы банан");
            }
            else
            {
                Console.WriteLine("Вы не банан");
            }
        }
    }
}
