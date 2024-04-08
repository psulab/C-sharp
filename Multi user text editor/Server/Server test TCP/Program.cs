using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server_test_TCP
{
    class Program
    {
        static Mutex mutexRead = new Mutex();
        static Mutex mutexWrite = new Mutex();

        static List<Thread> customerAssistant;
        static StringBuilder writeMessage;
        static int isWrite;
        static bool isRead;
        static void Main(string[] args)
        {
            try
            {
                const int PORT = 8080;
                TcpListener server = new TcpListener(IPAddress.Any, PORT);

                Console.WriteLine("\t\t      +----------------+");
                Console.WriteLine("\t\t      | Сервер запущен |");
                Console.WriteLine("\t\t      +----------------+");
                server.Start();

                ConsoleKeyInfo cki;
                customerAssistant = new List<Thread>();
                writeMessage = new StringBuilder();
                isWrite = 0;
                isRead = true;

                do
                {
                    Console.WriteLine("+- Ассистент ----------------------------------------------+");
                    Console.WriteLine("| Нажмите любую клавишу   ->  [ добавить клиента ]         |");
                    Console.WriteLine("| Нажмите клавишу Escape  ->  [ завершить работу сервера ] |");
                    Console.WriteLine("+----------------------------------------------------------+");
                    Console.WriteLine("\t\tОжидание подключения клиента..\n\t\t[ Запустите программу клиент ]");

                    TcpClient client = server.AcceptTcpClient(); //ожидания подключения клиента
                    customerAssistant.Add(new Thread(() => CustomerAssistant(client))); //создание потока для обработки клиента
                    customerAssistant[customerAssistant.Count - 1].IsBackground = true;
                    customerAssistant[customerAssistant.Count - 1].Start();

                    Console.WriteLine("\t\t       Клиент подключен");
                    cki = Console.ReadKey(true);
                    Console.Clear();

                    int length = customerAssistant.Count;

                    for (int i = length - 1; i >= 0; i--)
                    {
                        if (customerAssistant[i].ThreadState == ThreadState.Stopped)
                        {
                            customerAssistant[i].Abort(); //остановка потока
                            customerAssistant[i].Join(); //ожидание завершения потока
                            customerAssistant.RemoveAt(i);
                        }
                    }

                } while (cki.Key != ConsoleKey.Escape);

                foreach (var ca in customerAssistant)
                {
                    ca.Abort();
                }

                server.Stop();
                Console.WriteLine("\t\t      +-------------------+");
                Console.WriteLine("\t\t      | Сервер остановлен |");
                Console.WriteLine("\t\t      +-------------------+");

                //Environment.Exit(0);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }

        static void CustomerAssistant(TcpClient client)
        {
            NetworkStream stream = client.GetStream(); //поток для чтения и записи

            /*Поток для чтения данных*/
            string readMessage = string.Empty;
            Thread readData = new Thread(() => ReadData(ref stream, ref readMessage));
            readData.IsBackground = true;
            readData.Start();
            BinaryWriter writer = new BinaryWriter(stream); //поток бинарных данных [запись]

            while (readMessage != "disconnection")
            {
                if (isWrite != 0)
                {
                    mutexWrite.WaitOne();

                        /*Запись данных*/
                        if (readMessage.Length > 0)
                        {
                            if ((int.TryParse(string.Join("", readMessage.Where(c => char.IsDigit(c))), out int value)) && (value < writeMessage.Length))
                            {
                                if (readMessage[0] == '\b')
                                {
                                    writeMessage.Remove(value, 1); //удаление
                                }
                                else
                                {
                                    writeMessage.Insert(value, readMessage[0]); //вставить
                                }
                            }                        
                            else
                            {
                                writeMessage.Append(readMessage[0]); //добавить
                            }
                        }                            

                        writer.Write(writeMessage.ToString());
                        writer.Flush();
                        readMessage = string.Empty;
                        isWrite--;

                    mutexWrite.ReleaseMutex();

                    while (isWrite != 0)
                    {
                        Thread.Sleep(20);
                    }
                }

                Thread.Sleep(20);
            }

            readData.Abort(); //закрытие потока
            readData.Join(); //закрытие потока

            writer.Close(); //закрытие потока
            stream.Close(); //закрытие потока
            client.Close(); //закрытие подключение с клиентом
        }

        static void ReadData(ref NetworkStream stream, ref string readMessage)
        {
            BinaryReader reader = new BinaryReader(stream); //поток бинарных данных [чтение]

            try
            {
                while (true)
                {
                    /*Чтение данных*/
                    string rm = reader.ReadString();

                    mutexRead.WaitOne(); //захват мьютекса

                        readMessage = rm;
                        int count = 0;

                        foreach (var ca in customerAssistant)
                        {
                            if (ca.IsAlive)
                            {
                                count++;
                            }
                        }

                        isWrite = count;

                        while (isWrite != 0)
                        {
                            Thread.Sleep(20);
                        }

                    mutexRead.ReleaseMutex(); //освобождение мьютекса

                    Thread.Sleep(20);
                }
            }
            catch (Exception)
            {
                readMessage = "disconnection";
                reader.Close(); //закрытие потока
            }
        }
    }
}

/* Рабочий сервер [удаление только последнего символа + запись в конец] */
//namespace Server_test_TCP
//{
//    class Program
//    {
//        static Mutex mutexRead = new Mutex();
//        static Mutex mutexWrite = new Mutex();

//        static List<Thread> customerAssistant;
//        static StringBuilder writeMessage;
//        static int isWrite;
//        static bool isRead;
//        static void Main(string[] args)
//        {
//            try
//            {
//                const int PORT = 8080;
//                TcpListener server = new TcpListener(IPAddress.Any, PORT);

//                Console.WriteLine("\t\t      +----------------+");
//                Console.WriteLine("\t\t      | Сервер запущен |");
//                Console.WriteLine("\t\t      +----------------+");
//                server.Start();

//                ConsoleKeyInfo cki;
//                customerAssistant = new List<Thread>();
//                writeMessage = new StringBuilder();
//                isWrite = 0;
//                isRead = true;

//                do
//                {
//                    Console.WriteLine("+- Ассистент ----------------------------------------------+");
//                    Console.WriteLine("| Нажмите любую клавишу   ->  [ добавить клиента ]         |");
//                    Console.WriteLine("| Нажмите клавишу Escape  ->  [ завершить работу сервера ] |");
//                    Console.WriteLine("+----------------------------------------------------------+");
//                    Console.WriteLine("\t\tОжидание подключения клиента..\n\t\t[ Запустите программу клиент ]");

//                    TcpClient client = server.AcceptTcpClient(); //ожидания подключения клиента
//                    customerAssistant.Add(new Thread(() => CustomerAssistant(client))); //создание потока для обработки клиента
//                    customerAssistant[customerAssistant.Count - 1].IsBackground = true;
//                    customerAssistant[customerAssistant.Count - 1].Start();

//                    Console.WriteLine("\t\t       Клиент подключен");
//                    cki = Console.ReadKey(true);
//                    Console.Clear();

//                    int length = customerAssistant.Count;

//                    for (int i = length-1; i >= 0; i--)
//                    {
//                        if (customerAssistant[i].ThreadState == ThreadState.Stopped)
//                        {
//                            customerAssistant[i].Abort(); //остановка потока
//                            customerAssistant[i].Join(); //ожидание завершения потока
//                            customerAssistant.RemoveAt(i);
//                        }
//                    }

//                } while (cki.Key != ConsoleKey.Escape);

//                foreach (var ca in customerAssistant)
//                {
//                    ca.Abort();
//                }

//                server.Stop();
//                Console.WriteLine("\t\t      +-------------------+");
//                Console.WriteLine("\t\t      | Сервер остановлен |");
//                Console.WriteLine("\t\t      +-------------------+");

//                //Environment.Exit(0);
//            }
//            catch (Exception error)
//            {
//                Console.WriteLine(error.Message);
//            }
//        }

//        static void CustomerAssistant(TcpClient client)
//        {
//            NetworkStream stream = client.GetStream(); //поток для чтения и записи

//            /*Поток для чтения данных*/
//            string readMessage = string.Empty;
//            Thread readData = new Thread(() => ReadData(ref stream, ref readMessage));
//            readData.IsBackground = true;
//            readData.Start();
//            BinaryWriter writer = new BinaryWriter(stream); //поток бинарных данных [запись]

//            while (readMessage != "disconnection")
//            {
//                if (isWrite != 0)
//                {
//                    mutexWrite.WaitOne();

//                        /*Запись данных*/
//                        if (readMessage == "\b")
//                        {
//                            writeMessage.Remove(writeMessage.Length - 1, 1);
//                        }
//                        else if (readMessage == "\r")
//                        {
//                            writeMessage.AppendLine();
//                        }
//                        else
//                        {
//                            writeMessage.Append(readMessage);
//                        }

//                        writer.Write(writeMessage.ToString());
//                        writer.Flush();
//                        readMessage = string.Empty;
//                        isWrite--;

//                    mutexWrite.ReleaseMutex();

//                    while (isWrite != 0)
//                    {
//                        Thread.Sleep(20);
//                    }
//                }

//                Thread.Sleep(20);
//            }

//            readData.Abort(); //закрытие потока
//            readData.Join(); //закрытие потока

//            writer.Close(); //закрытие потока
//            stream.Close(); //закрытие потока
//            client.Close(); //закрытие подключение с клиентом
//        }

//        static void ReadData(ref NetworkStream stream, ref string readMessage)
//        {
//            BinaryReader reader = new BinaryReader(stream); //поток бинарных данных [чтение]

//            try
//            {
//                while (true)
//                {
//                    /*Чтение данных*/
//                    string rm = reader.ReadString();
//                    //readMessage = reader.ReadString();
//                    //Console.Write(readMessage); //сообщение клиента

//                    mutexRead.WaitOne(); //захват мьютекса

//                        readMessage = rm;

//                        int count = 0;

//                        foreach (var ca in customerAssistant)
//                        {
//                            if (ca.IsAlive)
//                            {
//                                count++;
//                            }
//                        }

//                        isWrite = count;

//                        while (isWrite != 0)
//                        {
//                            Thread.Sleep(20);
//                        }

//                    mutexRead.ReleaseMutex(); //освобождение мьютекса

//                    Thread.Sleep(20);
//                }


//            }
//            catch (Exception)
//            {
//                readMessage = "disconnection";
//                reader.Close(); //закрытие потока
//            }            
//        }
//    }
//}
/* Доработанный [поток для обработки каждого клиента + поток чтения данных + глобальная динамич строка для хранения данных + чтение/запись(обновленно) + удаление последнего символа] */
//namespace Server_test_TCP
//{
//    class Program
//    {
//        static StringBuilder writeMessage;
//        static void Main(string[] args)
//        {
//            try
//            {
//                const int PORT = 8080;
//                TcpListener server = new TcpListener(IPAddress.Any, PORT);

//                Console.WriteLine("\t\t      +----------------+");
//                Console.WriteLine("\t\t      | Сервер запущен |");
//                Console.WriteLine("\t\t      +----------------+");
//                server.Start();

//                ConsoleKeyInfo cki;
//                List<Thread> customerAssistant = new List<Thread>();
//                writeMessage = new StringBuilder();

//                do
//                {
//                    Console.WriteLine("+- Ассистент ----------------------------------------------+");
//                    Console.WriteLine("| Нажмите любую клавишу   ->  [ добавить клиента ]         |");
//                    Console.WriteLine("| Нажмите клавишу Escape  ->  [ завершить работу сервера ] |");
//                    Console.WriteLine("+----------------------------------------------------------+");
//                    Console.WriteLine("\t\tОжидание подключения клиента..\n\t\t[ Запустите программу клиент ]");

//                    TcpClient client = server.AcceptTcpClient();//ожидания подключения клиента
//                    customerAssistant.Add(new Thread(() => CustomerAssistant(client)));//создание потока для обработки клиента
//                    customerAssistant[customerAssistant.Count - 1].Start();

//                    Console.WriteLine("\t\t       Клиент подключен");
//                    cki = Console.ReadKey(true);
//                    Console.Clear();

//                } while (cki.Key != ConsoleKey.Escape);

//                foreach (var cas in customerAssistant)
//                {
//                    cas.Abort();//остановка потока
//                    cas.Join();//ожидание завершения потока
//                }

//                server.Stop();
//                Console.WriteLine("\t\t      +-------------------+");
//                Console.WriteLine("\t\t      | Сервер остановлен |");
//                Console.WriteLine("\t\t      +-------------------+");
//            }
//            catch (Exception error)
//            {
//                Console.WriteLine(error.Message);
//            }
//        }

//        static void CustomerAssistant(TcpClient client)
//        {
//            NetworkStream stream = client.GetStream();//поток для чтения и записи

//            /*Поток для чтения данных*/
//            string readMessage = string.Empty;
//            Thread readData = new Thread(() => ReadData(ref stream, ref readMessage)); readData.Start();
//            BinaryWriter writer = new BinaryWriter(stream);//поток бинарных данных [запись]

//            while (true)
//            {
//                if (readMessage != string.Empty)
//                {
//                    /*Запись данных*/
//                    if (readMessage == "\b")
//                    {
//                        writeMessage.Remove(writeMessage.Length - 1, 1);
//                    }
//                    else
//                    {
//                        writeMessage.Append(readMessage);
//                    }                    
//                    writer.Write(writeMessage.ToString());
//                    writer.Flush();
//                    readMessage = string.Empty;
//                }

//                Thread.Sleep(20);
//            }

//            writer.Close();//закрытие потока
//            stream.Close();//закрытие потока
//            client.Close();//закрытие подключение с клиентом
//        }

//        static void ReadData(ref NetworkStream stream, ref string readMessage)
//        {
//            BinaryReader reader = new BinaryReader(stream);//поток бинарных данных [чтение]

//            while (true)
//            {
//                /*Чтение данных*/
//                readMessage = reader.ReadString();
//                Console.Write(readMessage);//сообщение клиента

//                Thread.Sleep(20);
//            }

//            reader.Close();//закрытие потока
//        }
//    }
//}
/* Доработанный [поток для обработки каждого клиента + поток чтения данных + глобальная динамич строка для хранения данных] */
//namespace Server_test_TCP
//{
//    class Program
//    {
//        static StringBuilder writeMessage;
//        static void Main(string[] args)
//        {
//            try
//            {
//                const int PORT = 8080;
//                TcpListener server = new TcpListener(IPAddress.Any, PORT);

//                Console.WriteLine("\t\t      +----------------+");
//                Console.WriteLine("\t\t      | Сервер запущен |");
//                Console.WriteLine("\t\t      +----------------+");
//                server.Start();

//                ConsoleKeyInfo cki;
//                List<Thread> customerAssistant = new List<Thread>();
//                writeMessage = new StringBuilder();

//                do
//                {
//                    Console.WriteLine("+- Ассистент ----------------------------------------------+");
//                    Console.WriteLine("| Нажмите любую клавишу   ->  [ добавить клиента ]         |");
//                    Console.WriteLine("| Нажмите клавишу Escape  ->  [ завершить работу сервера ] |");
//                    Console.WriteLine("+----------------------------------------------------------+");
//                    Console.WriteLine("\t\tОжидание подключения клиента..\n\t\t[ Запустите программу клиент ]");

//                    TcpClient client = server.AcceptTcpClient();//ожидания подключения клиента
//                    customerAssistant.Add(new Thread(() => CustomerAssistant(client)));//создание потока для обработки клиента
//                    customerAssistant[customerAssistant.Count - 1].Start();

//                    Console.WriteLine("\t\t       Клиент подключен");
//                    cki = Console.ReadKey(true);
//                    Console.Clear();

//                } while (cki.Key != ConsoleKey.Escape);

//                foreach (var cas in customerAssistant)
//                {
//                    cas.Abort();//остановка потока
//                    cas.Join();//ожидание завершения потока
//                }

//                server.Stop();
//                Console.WriteLine("\t\t      +-------------------+");
//                Console.WriteLine("\t\t      | Сервер остановлен |");
//                Console.WriteLine("\t\t      +-------------------+");
//            }
//            catch (Exception error)
//            {
//                Console.WriteLine(error.Message);
//            }
//        }

//        static void CustomerAssistant(TcpClient client)
//        {
//            NetworkStream stream = client.GetStream();//поток для чтения и записи

//            /*Поток для чтения данных*/
//            string readMessage = string.Empty;
//            Thread readData = new Thread(() => ReadData(ref stream, ref readMessage)); readData.Start();

//            while (true)
//            {
//                if (readMessage != string.Empty)
//                {
//                    /*Запись данных*/
//                    writeMessage.Append(readMessage);
//                    byte[] cmtb = Encoding.UTF8.GetBytes(writeMessage.ToString());//конвертируем строку в байты для отправки
//                    stream.Write(cmtb, 0, cmtb.Length);
//                    readMessage = string.Empty;
//                }

//                Thread.Sleep(20);
//            }

//            stream.Close();//закрытие потока
//            client.Close();//закрытие подключение с коиентом
//        }

//        static void ReadData(ref NetworkStream stream, ref string readMessage)
//        {
//            while (true)
//            {
//                /*Чтение данных*/
//                byte[] buffer = new byte[256];
//                int nob = stream.Read(buffer, 0, buffer.Length);//возвращает колличество прочитанных байтов
//                readMessage = Encoding.UTF8.GetString(buffer, 0, nob);
//                Console.Write(readMessage);//сообщение клиента

//                Thread.Sleep(20);
//            }
//        }
//    }
//}
/* Доработанный [поток для обработки каждого клиента + поток чтения данных] */
//namespace Server_test_TCP
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            try
//            {
//                const int PORT = 8080;
//                TcpListener server = new TcpListener(IPAddress.Any, PORT);

//                Console.WriteLine("\t\t      +----------------+");
//                Console.WriteLine("\t\t      | Сервер запущен |");
//                Console.WriteLine("\t\t      +----------------+");
//                server.Start();

//                ConsoleKeyInfo cki;
//                List<Thread> customerAssistant = new List<Thread>();

//                do
//                {
//                    Console.WriteLine("+- Ассистент ----------------------------------------------+");
//                    Console.WriteLine("| Нажмите любую клавишу   ->  [ добавить клиента ]         |");
//                    Console.WriteLine("| Нажмите клавишу Escape  ->  [ завершить работу сервера ] |");
//                    Console.WriteLine("+----------------------------------------------------------+");
//                    Console.WriteLine("\t\tОжидание подключения клиента..\n\t\t[ Запустите программу клиент ]");

//                    TcpClient client = server.AcceptTcpClient();//ожидания подключения клиента
//                    customerAssistant.Add(new Thread(() => CustomerAssistant(client)));//создание потока для обработки клиента
//                    customerAssistant[customerAssistant.Count - 1].Start();

//                    Console.WriteLine("\t\t       Клиент подключен");
//                    cki = Console.ReadKey(true);
//                    Console.Clear();

//                } while (cki.Key != ConsoleKey.Escape);

//                foreach (var cas in customerAssistant)
//                {
//                    cas.Abort();//остановка потока
//                    cas.Join();//ожидание завершения потока
//                }                      

//                server.Stop();
//                Console.WriteLine("\t\t      +-------------------+");
//                Console.WriteLine("\t\t      | Сервер остановлен |");
//                Console.WriteLine("\t\t      +-------------------+");                
//            }
//            catch (Exception error)
//            {
//                Console.WriteLine(error.Message);
//            }
//        }

//        static void CustomerAssistant(TcpClient client)
//        {
//            NetworkStream stream = client.GetStream();//поток для чтения и записи

//            /*Поток для чтения данных*/
//            string readMessage = string.Empty;
//            Thread readData = new Thread(() => ReadData(stream, ref readMessage)); readData.Start();

//            while (true)
//            {
//                if (readMessage != string.Empty)
//                {
//                    /*Запись данных*/
//                    string writeMessage = readMessage;
//                    byte[] cmtb = Encoding.UTF8.GetBytes(writeMessage);//конвертируем строку в байты для отправки
//                    stream.Write(cmtb, 0, cmtb.Length);
//                    readMessage = string.Empty;
//                }
//            }

//            stream.Close();//закрытие потока
//            client.Close();//закрытие подключение с коиентом
//        }

//        static void ReadData(NetworkStream stream, ref string readMessage)
//        {
//            while (true)
//            {
//                /*Чтение данных*/
//                byte[] buffer = new byte[256];
//                int nob = stream.Read(buffer, 0, buffer.Length);//возвращает колличество прочитанных байтов
//                readMessage = Encoding.UTF8.GetString(buffer, 0, nob);
//                Console.Write(readMessage);//сообщение клиента
//            }
//        }
//    }
//}
/* Доработанный [поток чтения данных] */
//namespace Server_test_TCP
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            try
//            {
//                const int PORT = 8080;
//                TcpListener server = new TcpListener(IPAddress.Any, PORT);
//                Console.WriteLine("Сервер запущен\n\tОжидания подключения...");
//                server.Start();

//                TcpClient client = server.AcceptTcpClient();//ожидания подключения клиента
//                Console.WriteLine("Клиент подключен");
//                NetworkStream stream = client.GetStream();//поток для чтения и записи

//                /*Поток для чтения данных*/
//                string readMessage = string.Empty;
//                Thread readData = new Thread(() => ReadData(stream, ref readMessage)); readData.Start();

//                while (true)
//                {
//                    if (readMessage != string.Empty)
//                    {
//                        /*Запись данных*/
//                        string writeMessage = "Ваше сообщение: " + readMessage;
//                        byte[] cmtb = Encoding.UTF8.GetBytes(writeMessage);//конвертируем строку в байты для отправки
//                        stream.Write(cmtb, 0, cmtb.Length);
//                        readMessage = string.Empty;//очистить строку
//                    }                    

//                    Thread.Sleep(20);
//                }

//                stream.Close();//закрытие потока
//                client.Close();//закрытие подключение с коиентом

//                server.Stop();
//                Console.WriteLine("Сервер остановлен");
//            }
//            catch (Exception error)
//            {
//                Console.WriteLine(error.Message);
//            }
//        }

//        static void ReadData(NetworkStream stream, ref string readMessage)
//        {
//            while (true)
//            {
//                /*Чтение данных*/
//                byte[] buffer = new byte[256];
//                int nob = stream.Read(buffer, 0, buffer.Length);//возвращает колличество прочитанных байтов
//                readMessage = Encoding.UTF8.GetString(buffer, 0, nob);
//                Console.WriteLine(readMessage);//сообщение клиента

//                Thread.Sleep(20);
//            }           
//        }
//    }
//}
/* Original */
//namespace Server_test_TCP
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            try
//            {
//                const int PORT = 8080;
//                TcpListener server = new TcpListener(IPAddress.Any, PORT);
//                Console.WriteLine("Сервер запущен\n\tОжидания подключения...");
//                server.Start();

//                while (true)
//                {
//                    TcpClient client = server.AcceptTcpClient();//ожидания подключения клиента
//                    Console.WriteLine("Клиент подключен");
//                    NetworkStream stream = client.GetStream();//поток для чтения и записи

//                    /*Чтение данных*/
//                    byte[] buffer = new byte[256];
//                    int nob = stream.Read(buffer, 0, buffer.Length);//возвращает колличество прочитанных байтов
//                    string readMessage = Encoding.UTF8.GetString(buffer, 0, nob);
//                    Console.WriteLine(readMessage);//сообщение клиента

//                    /*Запись данных*/
//                    string writeMessage = "Ваше сообщение: " + readMessage;
//                    byte[] cmtb = Encoding.UTF8.GetBytes(writeMessage);//конвертируем строку в байты для отправки
//                    stream.Write(cmtb, 0, cmtb.Length);

//                    stream.Close();//закрытие потока
//                    client.Close();//закрытие подключение с коиентом
//                }

//                server.Stop();
//                Console.WriteLine("Сервер остановлен");
//            }
//            catch (Exception error)
//            {
//                Console.WriteLine(error.Message);
//            }           
//        }
//    }
//}
