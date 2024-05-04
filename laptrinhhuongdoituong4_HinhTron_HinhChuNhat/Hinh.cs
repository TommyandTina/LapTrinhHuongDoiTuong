using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhhuongdoituong4_HinhTron_HinhChuNhat
{
    public abstract class Hinh
    {
        public string MauSac { get; set; }
        public virtual void Nhap(string ghiChu)
        {
            Console.WriteLine(ghiChu);
            Console.Write("Nhap mau sac");
            MauSac = Console.ReadLine();
        }

        public abstract double TinhChuVi();
    }

    public class Animal
    {
        public string Name { get; set; }
    }
    public interface IAnimalSound
    {
        void animalSound();
    }

    public interface IAnimalRun
    {
        void run();
        void walk();
    }

    public interface IAnimalFly
    {
        void fly();

    }



}
