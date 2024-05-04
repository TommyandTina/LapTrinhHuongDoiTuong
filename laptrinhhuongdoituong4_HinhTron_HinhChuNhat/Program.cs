using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhhuongdoituong4_HinhTron_HinhChuNhat
{
   
    internal class Program
    {
        public static void PlaySounds(IAnimalSound o)
        {
            o.animalSound();
        }
        static void Main(string[] args)
        {
            Bird a = new Bird();
            a.fly();
            a.animalSound();

            Dog d = new Dog();
            d.animalSound();
            d.run();

            PlaySounds(a);
            PlaySounds(d);
        }
    }
}
