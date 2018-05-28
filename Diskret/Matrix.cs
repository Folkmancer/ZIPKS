using System;

namespace Folkmancer.OSU.ZIPKS.Diskret
{
    class Matrix
    {   
        Random rnd = new Random();
        private string[] right = { "Запрет", "Чтение", "Чтение, Запись", "Чтение, Передача прав", "Полный доступ" };
        private string[] user;
        private string[] obj;
        private int[,] matrix;
        
        public Matrix(string[] userList, string[] objList)
        {
            user = userList;
            obj = objList;
            matrix = new int[user.Length, obj.Length];
            for (int i = 0; i < obj.Length; i++)
            {
                matrix[0, i] = 4;
            }

            for (int i = 1; i < user.Length; i++)
            {
                for (int j = 0; j < obj.Length; j++)
                {
                    matrix[i, j] = rnd.Next(5);
                }
            }
        }

        public void Menu()
        {
            while (true)
            {
                int choice;
                bool end = false;
                Console.Write("Введите логин: ");
                int login = this.GetLoginID();
                while (end != true)
                {
                    if (login != -1)
                    {
                        Console.WriteLine("Вы успешно авторизованы!");
                        this.GetLoginInfo(login);
                        Console.WriteLine("Какую операцию вы хотите выполнить?");
                        Console.WriteLine("1 Чтение \n2 Запись \n3 Передача прав \n4 Выход");
                        int.TryParse(Console.ReadLine(), out choice);
                        switch (choice)
                        {
                            case 1:
                                this.Read(login, this.GetObject(login));
                                Console.ReadLine();
                                break;
                            case 2:
                                this.Write(login, this.GetObject(login));
                                Console.ReadLine();
                                break;
                            case 3:
                                this.Grant(login, this.GetObject(login));
                                Console.ReadLine();
                                break;
                            case 4:
                                end = true;
                                break;
                            default:
                                Console.WriteLine("Такой операции не существует!");
                                Console.ReadLine();
                                break;
                        }
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Ошибка, такого пользователя не существует!");
                        Console.Write("Нажмите любую клавишу, чтобы продолжить.");
                        Console.ReadLine();
                        Console.Clear();
                        end = true;
                    }
                }
            }
        }

        public int GetLoginID()
        {
            int index = Array.IndexOf(user, Console.ReadLine());
            if (index >= 0 && index < user.Length) return index;
            else return -1;
        }

        public void GetLoginInfo(int currentLogin)
        {

            Console.WriteLine(String.Format("user = {0} \nСписок ваших прав: ", user[currentLogin]));
            for (int j = 0; j < right.Length; j++)
            {
                Console.WriteLine("{0}: {1}", obj[j], right[matrix[currentLogin, j]]);
            }
        }

        public int GetObject(int currentLogin)
        {
            Console.WriteLine("Объект для операции?");
            for (int i = 0; i < obj.Length; i++)
            {
                Console.WriteLine("{0} {1}", i + 1, obj[i]);
            }
            int currentObj;
            int.TryParse(Console.ReadLine(), out currentObj);
            if (currentObj > 0 && currentObj <= user.Length) return currentObj - 1;
            else return -1;
        }

        public void Read(int login, int Obj)
        {
            if (matrix[login, Obj] > 0) Console.WriteLine("Операция прошла успешно!");
            else Console.WriteLine("У вас отсутствуют права чтения!");
        }

        public void Write(int login, int Obj)
        {
            if (matrix[login, Obj] == 2 || matrix[login, Obj] == 4) Console.WriteLine("Операция прошла успешно!");
            else Console.WriteLine("У вас отсутствуют права записи!");
        }

        public void Grant(int login, int Obj)
        {
            int loginRight = matrix[login, Obj];
            if (loginRight > 2)
            {
                Console.Write("Введите имя пользователя для передачи прав: ");
                int grantLogin = this.GetLoginID();
                if (grantLogin != -1)
                {
                    int grantLoginRight = matrix[grantLogin, Obj];
                    Console.WriteLine("Какие права вы хотите передать?");
                    Console.WriteLine("1 Чтение \n2 Запись \n3 Передача прав");
                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            if (grantLoginRight == 0)
                            {
                                matrix[grantLogin, Obj] = 1;
                                Console.WriteLine("Права чтения успешно предоставлены.");
                            }
                            else Console.WriteLine("Пользователь уже обладает такими правами.");
                            break;
                        case 2:
                            if (loginRight == 4)
                            {
                                if (grantLoginRight < 2)
                                {
                                    matrix[grantLogin, Obj] = 2;
                                    Console.WriteLine("Права успешно предоставлены.");
                                }
                                else if (grantLoginRight == 3)
                                {
                                    matrix[grantLogin, Obj] = 4;
                                    Console.WriteLine("Права успешно предоставлены.");
                                }
                                else Console.WriteLine("Пользователь уже обладает такими правами.");
                            }
                            else Console.WriteLine("У вас отсутствуют права передачи записи!");
                            break;
                        case 3:
                            if (grantLoginRight == 1)
                            {
                                matrix[grantLogin, Obj] = 3;
                                Console.WriteLine("Права успешно предоставлены.");
                            }
                            else if (grantLoginRight == 2)
                            {
                                matrix[grantLogin, Obj] = 4;
                                Console.WriteLine("Права успешно предоставлены.");
                            }
                            else if (grantLoginRight == 3 || grantLoginRight == 4)
                            {
                                Console.WriteLine("Пользователь уже обладает такими правами.");
                            }
                            else Console.WriteLine("У пользователя отсутствуют права чтения или записи.");
                            break;
                        default:
                            Console.WriteLine("Такой операции не существует!");
                            break;
                    }
                }
                else Console.WriteLine("Такой пользователь не существует!");
            }
            else Console.WriteLine("У вас отсутствуют права передачи!");
        }
    }
}