using System;

namespace Folkmancer.OSU.ZIPKS.Diskret
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] user = { "Алекс", "Гордон", "Джонни", "Ганс", "Энакин", "Мэй" };
            string[] obj = { "объект1", "объект2", "объект3", "объект4", "объект5" };
            Matrix newMatrix = new Matrix(user, obj);
            newMatrix.Menu();
        }
    }
}